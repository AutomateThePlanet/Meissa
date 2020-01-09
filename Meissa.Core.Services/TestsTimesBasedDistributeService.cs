// <copyright file="TestsTimesBasedDistributeService.cs" company="Automate The Planet Ltd.">
// Copyright 2020 Automate The Planet Ltd.
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
// <author>Anton Angelov</author>
// <site>https://bellatrix.solutions/</site>
using System;
using System.Collections.Generic;
using System.Linq;
using Meissa.Core.Contracts;
using Meissa.Core.Model;

namespace Meissa.Core.Services
{
    public class TestsTimesBasedDistributeService : ITestsTimesBasedDistributeService
    {
        private const int FallBackPercentage = 50;
        private readonly IJsonSerializer _jsonSerializer;
        private readonly ITestsCountsBasedDistributeService _testsCountsBasedDistributeService;
        private readonly ITestCasesHistoryService _testCasesHistoryService;
        private readonly IConsoleProvider _consoleProvider;

        public TestsTimesBasedDistributeService(
            IJsonSerializer jsonSerializer,
            ITestsCountsBasedDistributeService testsCountsBasedDistributeService,
            ITestCasesHistoryService testCasesHistoryService,
            IConsoleProvider consoleProvider)
        {
            _jsonSerializer = jsonSerializer;
            _testsCountsBasedDistributeService = testsCountsBasedDistributeService;
            _testCasesHistoryService = testCasesHistoryService;
            _consoleProvider = consoleProvider;
        }

        public List<string> GenerateDistributionLists(int testAgentsCount, bool sameMachineByClass, List<TestCase> testCasesToBeDistributed)
        {
            if (testAgentsCount <= 0)
            {
                throw new ArgumentException("Test Agents Count Must be Greater Than 0.");
            }

            var executedTestCases = _testCasesHistoryService.GetExecutedTestCasesAsync(testCasesToBeDistributed).Result;
            var executedTestCasesWithTime =
                executedTestCases.Where(x => x.WasExecuted.Equals(true) && x.AvgExecutionTime != null);
            var executedTestCasesWithoutTime =
                executedTestCases.Where(x => x.WasExecuted.Equals(false) && x.AvgExecutionTime == null);

            // Balance tests if more than 50% of the tests have been executed at least once. Otherwise, fall back to use distribution by count.
            var testCasesWithTime = executedTestCasesWithTime.ToList();
            var executedTestsPercentage = (double)testCasesWithTime.Count / testCasesToBeDistributed.Count * 100;

            _consoleProvider.WriteLine($"## Executed  tests % = {executedTestsPercentage}");
            if (executedTestsPercentage < FallBackPercentage)
            {
                _consoleProvider.WriteLine("## Distribute tests using COUNT BASED");
                return _testsCountsBasedDistributeService.GenerateDistributionLists(testAgentsCount, sameMachineByClass, testCasesToBeDistributed);
            }

            var testCasesWithoutTime = executedTestCasesWithoutTime.ToList();
            if (testCasesWithoutTime.Any() && sameMachineByClass)
            {
                return _testsCountsBasedDistributeService.GenerateDistributionLists(testAgentsCount, sameMachineByClass, testCasesToBeDistributed);
            }

            _consoleProvider.WriteLine("## Distribute tests using TIME BASED");
            _consoleProvider.WriteLine($"## Total Count of tests to be distributed = {testCasesToBeDistributed.Count}");

            var orderedByClassTestCases = testCasesWithTime.OrderBy(x => x.ClassName).ToList();
            var totalSecondsPerList = Math.Ceiling(orderedByClassTestCases.Sum(x =>
            {
                if (x.AvgExecutionTime != null)
                {
                    return x.AvgExecutionTime.Value.Milliseconds;
                }

                return 0;
            }) / (double)testAgentsCount);

            _consoleProvider.WriteLine(
                $"## Total seconds of all tests = {orderedByClassTestCases.Sum(x => x.AvgExecutionTime.Value.Milliseconds)}");
            _consoleProvider.WriteLine($"Total tests per list = {totalSecondsPerList}");

            var distributedTestCases = new List<List<TestCase>>();
            if (totalSecondsPerList > 0)
            {
                var distributedIndex = 0;
                var tempDistributedTestsSeconds = totalSecondsPerList;
                string previousClass = null;
                bool isListReset = false;
                for (var i = 0; i < orderedByClassTestCases.Count; i++)
                {
                    bool shouldResetTestsPerList = ShouldResetTestsPerList(sameMachineByClass, orderedByClassTestCases[i].ClassName, previousClass);
                    if (!isListReset && shouldResetTestsPerList)
                    {
                        isListReset = true;
                    }

                    if (tempDistributedTestsSeconds <= 0 && isListReset)
                    {
                        tempDistributedTestsSeconds = totalSecondsPerList;
                        distributedIndex++;
                        isListReset = false;
                    }

                    if (tempDistributedTestsSeconds.Equals(totalSecondsPerList))
                    {
                        distributedTestCases.Add(new List<TestCase>());
                    }

                    distributedTestCases[distributedIndex].Add(orderedByClassTestCases[i]);
                    previousClass = orderedByClassTestCases[i].ClassName;
                    var avgExecutionTime = orderedByClassTestCases[i].AvgExecutionTime;
                    if (avgExecutionTime != null)
                    {
                        tempDistributedTestsSeconds -= avgExecutionTime.Value.Milliseconds;
                    }
                }
            }
            else
            {
                distributedTestCases.Add(testCasesToBeDistributed);
            }

            var notDistributedTestCases = new List<List<TestCase>>();
            if (testCasesWithoutTime.Any())
            {
                var notExecutedTestCases = GetTestCasesFromExecutedTestCases(testCasesWithoutTime.ToList());
                notDistributedTestCases = _testsCountsBasedDistributeService.GenerateDistributionTestCasesLists(testAgentsCount, sameMachineByClass, notExecutedTestCases);
            }

            _consoleProvider.WriteLine($"## Total count of tests NOT distributed = {notDistributedTestCases.Count}");
            _consoleProvider.WriteLine($"## Total count of tests to be distributed = {distributedTestCases.Count}");

            // Merge time based and counts based lists.
            var distributedTestsLists = new List<string>();
            for (var i = 0; i < testAgentsCount; i++)
            {
                if (distributedTestCases.Count == i)
                {
                    break;
                }

                var mergedTestCasesList = distributedTestCases[i];

                if (notDistributedTestCases.Count > i && notDistributedTestCases[i] != null &&
                    notDistributedTestCases[i].Any())
                {
                    mergedTestCasesList.AddRange(notDistributedTestCases[i]);
                }

                distributedTestsLists.Add(_jsonSerializer.Serialize(mergedTestCasesList));
            }

            return distributedTestsLists;
        }

        private static bool ShouldResetTestsPerList(bool sameMachineByClass, string currentClass, string previousClass)
        {
            return !sameMachineByClass || previousClass != currentClass;
        }

        private List<TestCase> GetTestCasesFromExecutedTestCases(List<ExecutedTestCase> executedTestCases)
        {
            var testCases = new List<TestCase>();
            foreach (var executedTestCase in executedTestCases)
            {
                var currentTestCase = new TestCase(executedTestCase.FullName, executedTestCase.ClassName)
                                      {
                                          Categories = executedTestCase.Categories,
                                      };
                testCases.Add(currentTestCase);
            }

            return testCases;
        }
    }
}