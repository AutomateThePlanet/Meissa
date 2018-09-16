// <copyright file="NativeTestsRunnerPluginService.cs" company="Automate The Planet Ltd.">
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
using System.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Meissa.API.Models;
using Meissa.Core.Model;
using Meissa.Plugins.Contracts;
using Meissa.Plugins.MSTest.Model;

namespace Meissa.Plugins.MSTest
{
    [Export(typeof(INativeTestsRunnerPluginService))]
    public class NativeTestsRunnerPluginService : INativeTestsRunnerPluginService
    {
        public string Name => "MSTest";

        public string RunnerFile => "dotnet";

        public string ResultsFileExtension => "trx";

        public List<string> RunnerProcessesNamesToKill => new List<string> { "dotnet" };

        public string BuildNativeRunnerArguments(string libraryName, string libraryPath, List<TestCase> testCasesToBeExecuted, string testResultsFilePath, string outputFilesDir, string nativeArguments)
        {
            var testCaseFilter = CreateRunFilterArgument(testCasesToBeExecuted).FirstOrDefault();
            var testFilterArg = string.IsNullOrEmpty(testCaseFilter) ? string.Empty : $"--testcasefilter:\"{testCaseFilter}\"";
            var arguments = $"vstest \"{Path.Combine(outputFilesDir, libraryName)}\" --logger:trx;LogFileName=\"{testResultsFilePath}\" {nativeArguments} {testFilterArg}";

            return arguments;
        }

        public object DeserializeTestResults(string originalRunTestResults) => Deserialize<TestRun>(originalRunTestResults);

        public string SerializeTestResults(object testResults) => Serialize((TestRun)testResults);

        public List<TestCase> GetAllPassesTestCases(string testResultsFileContent)
        {
            TestRun testRun = Deserialize<TestRun>(testResultsFileContent);
            var passedUnitTestResults = testRun.Results.Where(x => x.outcome.Equals("Passed")).ToList();
            var passedTestCases = ConvertUnitTestsResultsToTestCases(passedUnitTestResults, testRun);
            return passedTestCases;
        }

        public object GetAllPassesTests(object testRunObj)
        {
            var testRun = (TestRun)testRunObj;
            var results = testRun.Results.ToList().Where(x => x.outcome.Equals("Passed")).ToList();
            return results;
        }

        public object GetAllPassesTests(string testRunContent)
        {
            var testRun = Deserialize<TestRun>(testRunContent);
            var results = testRun.Results.ToList().Where(x => x.outcome.Equals("Passed")).ToList();
            var passedTestCases = ConvertUnitTestsResultsToTestCases(results, testRun);
            return passedTestCases;
        }

        public int GetAllPassesTestsCount(object testRunObj)
        {
            var testRun = (TestRun)testRunObj;
            int count = testRun.Results.Count(x => x.outcome.Equals("Passed"));
            return count;
        }

        public int GetAllNotPassesTestsCount(object testRunObj)
        {
            var testRun = (TestRun)testRunObj;
            int count = testRun.Results.Count(x => !x.outcome.Equals("Passed"));
            return count;
        }

        public string MergeTestResults(object testResultsToBeMergedObj)
        {
            var result = string.Empty;
            var testRunsToBeMerged = (List<object>)testResultsToBeMergedObj;
            TestRun mergedTestRun = null;
            if (testRunsToBeMerged.Any())
            {
                mergedTestRun = (TestRun)testRunsToBeMerged.First();

                mergedTestRun.Times.finish = ((TestRun)testRunsToBeMerged.Last()).Times.finish;
                for (int i = 1; i < testRunsToBeMerged.Count; i++)
                {
                    var msTestTestRun = (TestRun)testRunsToBeMerged[i];
                    mergedTestRun.TestDefinitions = ConcatArrays(mergedTestRun.TestDefinitions, msTestTestRun.TestDefinitions);
                    mergedTestRun.Results = ConcatArrays(mergedTestRun.Results, msTestTestRun.Results);
                    mergedTestRun.TestEntries = ConcatArrays(mergedTestRun.TestEntries, msTestTestRun.TestEntries);
                    if (mergedTestRun.ResultSummary.outcome == "Passed" &&
                        mergedTestRun.ResultSummary.outcome != msTestTestRun.ResultSummary.outcome)
                    {
                        mergedTestRun.ResultSummary.outcome = msTestTestRun.ResultSummary.outcome;
                    }

                    mergedTestRun.ResultSummary.Counters.total += msTestTestRun.ResultSummary.Counters.total;
                    mergedTestRun.ResultSummary.Counters.executed += msTestTestRun.ResultSummary.Counters.executed;
                    mergedTestRun.ResultSummary.Counters.passed += msTestTestRun.ResultSummary.Counters.passed;
                    mergedTestRun.ResultSummary.Counters.failed += msTestTestRun.ResultSummary.Counters.failed;
                    mergedTestRun.ResultSummary.Counters.error += msTestTestRun.ResultSummary.Counters.error;
                    mergedTestRun.ResultSummary.Counters.aborted += msTestTestRun.ResultSummary.Counters.aborted;
                    mergedTestRun.ResultSummary.Counters.inconclusive +=
                        msTestTestRun.ResultSummary.Counters.inconclusive;
                    mergedTestRun.ResultSummary.Counters.passedButRunAborted +=
                        msTestTestRun.ResultSummary.Counters.passedButRunAborted;
                    mergedTestRun.ResultSummary.Counters.notRunnable +=
                        msTestTestRun.ResultSummary.Counters.notRunnable;
                    mergedTestRun.ResultSummary.Counters.notExecuted +=
                        msTestTestRun.ResultSummary.Counters.notExecuted;
                    mergedTestRun.ResultSummary.Counters.disconnected +=
                        msTestTestRun.ResultSummary.Counters.disconnected;
                    mergedTestRun.ResultSummary.Counters.warning += msTestTestRun.ResultSummary.Counters.warning;
                    mergedTestRun.ResultSummary.Counters.completed += msTestTestRun.ResultSummary.Counters.completed;
                    mergedTestRun.ResultSummary.Counters.inProgress += msTestTestRun.ResultSummary.Counters.inProgress;
                    mergedTestRun.ResultSummary.Counters.pending += msTestTestRun.ResultSummary.Counters.pending;
                }
            }

            if (mergedTestRun != null)
            {
                result = Serialize(mergedTestRun);
            }

            return result;
        }

        public void UpdatePassedTests(object passedTests, object testRunObj)
        {
            var passedTestCases = (List<TestCase>)passedTests;
            var testRun = (TestRun)testRunObj;
            var msTestTestCases = ConvertTestRunToMsTestCases(testRun);

            foreach (var currentTest in testRun.Results)
            {
                var currentTestFullName = msTestTestCases.FirstOrDefault(x => x.Id.Equals(currentTest.testId));
                if (passedTestCases.Count(x => x.FullName.Equals(currentTestFullName)) > 0)
                {
                    currentTest.outcome = "Passed";
                }
            }
        }

        public void UpdateResultsSummary(object testRunObj)
        {
            TestRun testRun = (TestRun)testRunObj;
            testRun.ResultSummary.Counters.failed = (byte)testRun.Results.Count(x => x.outcome.Equals("Failed"));
            testRun.ResultSummary.Counters.passed = (byte)testRun.Results.Count(x => x.outcome.Equals("Passed"));
            if (testRun.ResultSummary.Counters.passed != testRun.Results.Length)
            {
                testRun.ResultSummary.outcome = "Failed";
            }
            else
            {
                testRun.ResultSummary.outcome = "Passed";
            }
        }

        public List<TestCaseRun> UpdateTestCasesHistory(object testRunContent, string libraryName)
        {
            var testRun = Deserialize<TestRun>((string)testRunContent);
            var allPassedTestsTestRun = (List<TestRunUnitTestResult>)GetAllPassesTests(testRun);
            var testCaseRuns = new List<TestCaseRun>();
            foreach (var currentUnitTestResult in allPassedTestsTestRun)
            {
                var unitTestId = currentUnitTestResult.testId;
                var duration = currentUnitTestResult.duration;
                var currentUnitTest = testRun.TestDefinitions.FirstOrDefault(x => x.id.Equals(unitTestId));

                var className = currentUnitTest?.TestMethod.className.Split(',').Last().Trim();
                var unitTestLibraryName = currentUnitTest?.TestMethod.codeBase;
                var name = currentUnitTest?.TestMethod.name;
                var fullName = $"{className}.{name}";
                if (unitTestLibraryName != null && unitTestLibraryName.ToLower().Contains(libraryName.ToLower()))
                {
                    testCaseRuns.Add(new TestCaseRun(fullName, duration));
                }
            }

            return testCaseRuns;
        }

        public List<List<TestCase>> SplitTestCases(int availableCores, bool sameMachineByClass, List<TestCase> testCasesToBeDistributed)
        {
            if (availableCores <= 0)
            {
                throw new ArgumentException("Test Agents Count Must be Greater Than 0.");
            }

            var orderedByClassTestCases = testCasesToBeDistributed.OrderBy(x => x.ClassName).ToList();
            var runFilterArgs = CreateRunFilterArgument(testCasesToBeDistributed);

            int totalPartitions = availableCores >= runFilterArgs.Count ? availableCores : runFilterArgs.Count;
            int numberOfTestsPerList = (int)Math.Ceiling(orderedByClassTestCases.Count / (double)totalPartitions);

            var distributedTestCases = new List<List<TestCase>>();
            if (numberOfTestsPerList > 0)
            {
                int distributedIndex = 0;
                int tempDistributedTestsCount = numberOfTestsPerList;
                string previousClass = null;
                for (int i = 0; i < orderedByClassTestCases.Count; i++)
                {
                    bool shouldResetTestsPerList = ShouldResetTestsPerList(sameMachineByClass, orderedByClassTestCases[i].ClassName, previousClass);
                    if (tempDistributedTestsCount <= 0 && shouldResetTestsPerList)
                    {
                        tempDistributedTestsCount = numberOfTestsPerList;
                        distributedIndex++;
                    }

                    if (tempDistributedTestsCount == numberOfTestsPerList)
                    {
                        distributedTestCases.Add(new List<TestCase>());
                    }

                    distributedTestCases[distributedIndex].Add(orderedByClassTestCases[i]);
                    previousClass = orderedByClassTestCases[i].ClassName;

                    tempDistributedTestsCount--;
                }
            }
            else
            {
                distributedTestCases.Add(testCasesToBeDistributed);
            }

            return distributedTestCases;
        }

        private bool ShouldResetTestsPerList(bool sameMachineByClass, string currentClass, string previousClass)
        {
            return sameMachineByClass ? previousClass != currentClass : true;
        }

        public List<TestCase>[] SplitTestCases(List<TestCase> testCases, int availableCores)
        {
            if (testCases == null)
            {
                throw new ArgumentNullException(nameof(testCases));
            }

            if (availableCores < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(availableCores), "Available cores cannot be less than 1.");
            }

            var runFilterArgs = CreateRunFilterArgument(testCases);
            ////Console.WriteLine($"Number of runFilters - {runFilterArgs} with test cases {list.Count}");
            int totalPartitions = availableCores >= runFilterArgs.Count ? availableCores : runFilterArgs.Count;

            var partitions = new List<TestCase>[totalPartitions];

            int maxSize = (int)Math.Ceiling(testCases.Count / (double)totalPartitions);
            int k = 0;

            for (int i = 0; i < partitions.Length; i++)
            {
                partitions[i] = new List<TestCase>();
                for (int j = k; j < k + maxSize; j++)
                {
                    if (j >= testCases.Count)
                    {
                        break;
                    }

                    partitions[i].Add(testCases[j]);
                }

                k += maxSize;
            }

            return partitions;
        }

        public List<TestCase> GetAllNotPassedTests(string testResultsFileContent)
        {
            TestRun testRun = Deserialize<TestRun>(testResultsFileContent);
            var notPassedUnitTestResults = testRun.Results.Where(x => !x.outcome.Equals("Passed")).ToList();
            var notPassedTestCases = ConvertUnitTestsResultsToTestCases(notPassedUnitTestResults, testRun);
            return notPassedTestCases;
        }

        public object GetRetriedTestResultsForTestRun(List<TestAgentRunDto> testAgentRuns)
        {
            var msTestTestRuns = new List<object>();
            if (testAgentRuns.Any())
            {
                foreach (var testAgentRun in testAgentRuns)
                {
                    if (!string.IsNullOrEmpty(testAgentRun.TestAgentRetriedRunResults))
                    {
                        var msTestTestRun = Deserialize<TestRun>(testAgentRun.TestAgentRetriedRunResults);
                        msTestTestRuns.Add(msTestTestRun);
                    }
                }
            }

            return msTestTestRuns;
        }

        public object GetTestResultsForTestRun(List<TestAgentRunDto> testAgentRuns)
        {
            var msTestTestRuns = new List<object>();
            if (testAgentRuns.Any())
            {
                foreach (var testAgentRun in testAgentRuns)
                {
                    if (!string.IsNullOrEmpty(testAgentRun.TestAgentOriginalRunResults))
                    {
                        var msTestTestRun = Deserialize<TestRun>(testAgentRun.TestAgentOriginalRunResults);
                        msTestTestRuns.Add(msTestTestRun);
                    }
                }
            }

            return msTestTestRuns;
        }

        public void ExecutePostRunActions()
        {
        }

        private List<TestCase> ConvertUnitTestsResultsToTestCases(List<TestRunUnitTestResult> unitTestResults, TestRun testRun)
        {
            var testCases = new List<TestCase>();
            foreach (var unitTest in unitTestResults)
            {
                var testDefinition = testRun.TestDefinitions.FirstOrDefault(x => x.id.Equals(unitTest.testId));
                string fullName = $"{testDefinition?.TestMethod.className}.{testDefinition?.TestMethod.name}";
                testCases.Add(new TestCase(fullName, testDefinition?.TestMethod.className));
            }

            return testCases;
        }

        private List<MSTestTestCase> ConvertTestRunToMsTestCases(TestRun testRun)
        {
            var testCases = new List<MSTestTestCase>();
            foreach (var unitTest in testRun.TestDefinitions)
            {
                var currentTestCase = new MSTestTestCase
                {
                    FullName = $"{unitTest.TestMethod.className}.{unitTest.TestMethod.name}",
                    ClassName = unitTest.TestMethod.className,
                    Id = Guid.Parse(unitTest.id),
                };
                testCases.Add(currentTestCase);
            }

            return testCases;
        }

        private List<string> CreateRunFilterArgument(List<TestCase> distributedTestCases)
        {
            var runFilterArgumentBuilder = new StringBuilder();
            var argumentsLists = new List<string>();
            foreach (var testCase in distributedTestCases)
            {
                runFilterArgumentBuilder.Append($"FullyQualifiedName={testCase.FullName}|");
                if (runFilterArgumentBuilder.ToString().Length > 25000)
                {
                    argumentsLists.Add(runFilterArgumentBuilder.ToString().TrimEnd('|'));
                    runFilterArgumentBuilder = new StringBuilder();
                }
            }

            if (runFilterArgumentBuilder.ToString().Length > 0)
            {
                argumentsLists.Add(runFilterArgumentBuilder.ToString().TrimEnd('|'));
            }

            return argumentsLists;
        }

        private TEntity[] ConcatArrays<TEntity>(TEntity[] firstArray, TEntity[] secondArray)
        {
            var resultArray = new TEntity[firstArray.Length + secondArray.Length];
            firstArray.CopyTo(resultArray, 0);
            secondArray.CopyTo(resultArray, firstArray.Length);

            return resultArray;
        }

        private string Serialize<TEntity>(TEntity entityToBeSerialized)
        {
            var settings = new XmlWriterSettings
            {
                Encoding = new UnicodeEncoding(false, false),
                Indent = false,
                OmitXmlDeclaration = false,
            };
            var xmlSerializer = new XmlSerializer(typeof(TEntity));
            string result;

            using (var stringWriter = new StringWriter())
            {
                using (var writer = XmlWriter.Create(stringWriter, settings))
                {
                    xmlSerializer.Serialize(writer, entityToBeSerialized);
                    result = stringWriter.ToString();
                }
            }

            result = result.Replace("xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", string.Empty);
            result = result.Replace("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", string.Empty);

            return result;
        }

        private TEntity Deserialize<TEntity>(string content)
        {
            var serializer = new XmlSerializer(typeof(TEntity));
            var reader = new StringReader(content);
            var testRun = (TEntity)serializer.Deserialize(reader);
            reader.Close();

            return testRun;
        }
    }
}