// <copyright file="TestsTimesBasedDistributeService.cs" company="Automate The Planet Ltd.">
// Copyright 2018 Automate The Planet Ltd.
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
using System.Threading.Tasks;
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

        public async Task<List<string>> GenerateDistributionListsAsync(int testAgentsCount, bool sameMachineByClass, List<TestCase> testCasesToBeDistributed)
        {
            if (testAgentsCount <= 0)
            {
                throw new ArgumentException("Test Agents Count Must be Greater Than 0.");
            }

            var executedTestCases = await _testCasesHistoryService.GetExecutedTestCasesAsync(testCasesToBeDistributed);
            var executedTestCasesWithTime = executedTestCases.Where(x => x.WasExecuted.Equals(true) && x.AvgExecutionTime != null);
            var executedTestCasesWithoutTime = executedTestCases.Where(x => x.WasExecuted.Equals(false) && x.AvgExecutionTime == null);

            // Balance tests if more than 50% of the tests have been executed at least once. Otherwise, fall back to use distribution by count.
            double executedTestsPercentage = ((double)executedTestCasesWithTime.Count() / testCasesToBeDistributed.Count()) * 100;

            _consoleProvider.WriteLine($"---> ExecutedTestsPercentage = {executedTestsPercentage}");
            if (executedTestsPercentage < FallBackPercentage)
            {
                _consoleProvider.WriteLine("---> Distribute tests using ITestsCountsBasedDistributeService");
                return _testsCountsBasedDistributeService.GenerateDistributionLists(testAgentsCount, sameMachineByClass, testCasesToBeDistributed);
            }

            if (executedTestCasesWithoutTime.Any() && sameMachineByClass)
            {
                return _testsCountsBasedDistributeService.GenerateDistributionLists(testAgentsCount, sameMachineByClass, testCasesToBeDistributed);
            }

            _consoleProvider.WriteLine("---> Distribute tests using ITestsTimesBasedDistributeService");
            _consoleProvider.WriteLine($"---> Total Count of Tests to be distributed = {testCasesToBeDistributed.Count}");

            var orderedByClassTestCases = executedTestCasesWithTime.OrderBy(x => x.ClassName).ToList();
            double totalSecondsPerList = Math.Ceiling(orderedByClassTestCases.Sum(x => x.AvgExecutionTime.Value.Milliseconds) / (double)testAgentsCount);
            _consoleProvider.WriteLine($"---> total seconds of all tests = {orderedByClassTestCases.Sum(x => x.AvgExecutionTime.Value.Milliseconds)}");
            _consoleProvider.WriteLine($"---> totalSecondsPerList = {totalSecondsPerList}");
            var distributedTestCases = new List<List<TestCase>>();
            if (totalSecondsPerList > 0)
            {
                int distributedIndex = 0;
                double tempDistributedTestsSeconds = totalSecondsPerList;
                string previousClass = null;
                for (int i = 0; i < orderedByClassTestCases.Count; i++)
                {
                    bool shouldResetTestsPerList = ShouldResetTestsPerList(sameMachineByClass, orderedByClassTestCases[i].ClassName, previousClass);
                    if (tempDistributedTestsSeconds <= 0 && shouldResetTestsPerList)
                    {
                        tempDistributedTestsSeconds = totalSecondsPerList;
                        distributedIndex++;
                    }

                    if (tempDistributedTestsSeconds.Equals(totalSecondsPerList))
                    {
                        distributedTestCases.Add(new List<TestCase>());
                    }

                    distributedTestCases[distributedIndex].Add(orderedByClassTestCases[i]);
                    previousClass = orderedByClassTestCases[i].ClassName;
                    tempDistributedTestsSeconds -= orderedByClassTestCases[i].AvgExecutionTime.Value.Milliseconds;
                }
            }
            else
            {
                distributedTestCases.Add(testCasesToBeDistributed);
            }

            var notDistributedTestCases = new List<List<TestCase>>();
            if (executedTestCasesWithoutTime.Any())
            {
                var notExecutedTestCases = GetTestCasesFromExecutedTestCases(executedTestCasesWithoutTime.ToList());
                notDistributedTestCases = _testsCountsBasedDistributeService.GenerateDistributionTestCasesLists(testAgentsCount, sameMachineByClass, notExecutedTestCases);
            }

            _consoleProvider.WriteLine($"---> Total Count of Tests to be NOT distributed test lists = {notDistributedTestCases.Count}");
            _consoleProvider.WriteLine($"---> Total Count of Tests to be distributed test lists = {distributedTestCases.Count}");

            // Merge time based and counts based lists.
            var distributedTestsLists = new List<string>();
            for (int i = 0; i < testAgentsCount; i++)
            {
                var mergedTestCasesList = distributedTestCases[i];

                if (notDistributedTestCases.Count > i && notDistributedTestCases[i] != null && notDistributedTestCases[i].Any())
                {
                    _consoleProvider.WriteLine($"---> NOT distributed list number = {i} added");
                    mergedTestCasesList.AddRange(notDistributedTestCases[i]);
                }

                distributedTestsLists.Add(_jsonSerializer.Serialize(mergedTestCasesList));
            }

            return distributedTestsLists;
        }

        private static bool ShouldResetTestsPerList(bool sameMachineByClass, string currentClass, string previousClass)
            => sameMachineByClass ? previousClass != currentClass : true;

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