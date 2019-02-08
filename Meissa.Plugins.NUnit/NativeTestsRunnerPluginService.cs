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
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Meissa.API.Models;
using Meissa.Core.Model;
using Meissa.Core.Model.NUnit;
using Meissa.Plugins.Contracts;

namespace Meissa.Plugins.NUnit
{
    [Export(typeof(INativeTestsRunnerPluginService))]
    public class NativeTestsRunnerPluginService : INativeTestsRunnerPluginService
    {
        public string Name => "NUnit";

        public string RunnerFile => Path.Combine(GetRunningAssemblyPath(), "Plugins\\nunit-native-runner\\nunit3-console.exe");

        public string ResultsFileExtension => "xml";

        public List<string> RunnerProcessesNamesToKill => new List<string> { "nunit3-console" };

        public string BuildNativeRunnerArguments(string libraryName, string libraryPath, List<TestCase> testCasesToBeExecuted, string testResultsFilePath, string outputFilesDir, string nativeArguments)
        {
            var testListFilePath = CreateTestListFile(testCasesToBeExecuted);
            var arguments = $" \"{libraryPath}\" --result:{testResultsFilePath} --testlist=\"{testListFilePath}\" -dispose-runners {nativeArguments}";

            return arguments;
        }

        public object DeserializeTestResults(string originalRunTestResults) => Deserialize<testrun>(originalRunTestResults);

        public string SerializeTestResults(object testResults) => Serialize((testrun)testResults);

        public object GetAllPassesTests(object testRunContent)
        {
            var testRun = Deserialize<testrun>((string)testRunContent);
            var passedTestCases = new List<testrunTestsuiteTestsuiteTestsuiteTestcase>();
            foreach (var testSuiteNamespace in testRun.testsuite.testsuite)
            {
                foreach (var testSuiteTestSuite in testSuiteNamespace.testsuite)
                {
                    passedTestCases.AddRange(testSuiteTestSuite.testcase.Where(x => x.result.Equals("Passed")).ToList());
                }
            }

            return passedTestCases;
        }

        public object GetAllPassesTests(string testRunContent)
        {
            var results = GetAllPassesTests(testRunContent as object);
            return results;
        }

        public int GetAllPassesTestsCount(object testRunObj)
        {
            var testRun = (testrun)testRunObj;
            var passedTestCases = new List<testrunTestsuiteTestsuiteTestsuiteTestcase>();
            foreach (var testSuiteNamespace in testRun.testsuite.testsuite)
            {
                foreach (var testSuiteTestSuite in testSuiteNamespace.testsuite)
                {
                    passedTestCases.AddRange(testSuiteTestSuite.testcase.Where(x => x.result.Equals("Passed")).ToList());
                }
            }

            return passedTestCases.Count();
        }

        public int GetAllNotPassesTestsCount(object testRunObj)
        {
            var testRun = (testrun)testRunObj;
            var passedTestCases = new List<testrunTestsuiteTestsuiteTestsuiteTestcase>();
            foreach (var testSuiteNamespace in testRun.testsuite.testsuite)
            {
                foreach (var testSuiteTestSuite in testSuiteNamespace.testsuite)
                {
                    passedTestCases.AddRange(testSuiteTestSuite.testcase.Where(x => !x.result.Equals("Passed")).ToList());
                }
            }

            return passedTestCases.Count();
        }

        public string MergeTestResults(object testResultsToBeMergedObj)
        {
            var result = string.Empty;
            testrun mergedTestRun = null;
            var testRunsToBeMerged = (List<object>)testResultsToBeMergedObj;
            if (testRunsToBeMerged.Any())
            {
                mergedTestRun = (testrun)testRunsToBeMerged.First();
                mergedTestRun.starttime = ((testrun)testRunsToBeMerged.First()).starttime;
                mergedTestRun.endtime = ((testrun)testRunsToBeMerged.Last()).endtime;
                mergedTestRun.duration = (decimal)(DateTime.Parse(mergedTestRun.starttime) - DateTime.Parse(mergedTestRun.endtime)).TotalSeconds;

                foreach (testrun currentTestRun in testRunsToBeMerged)
                {
                    if (mergedTestRun.id != currentTestRun.id)
                    {
                        // Merge assembly level test suite.
                        if (mergedTestRun.testsuite.result == "Passed" && mergedTestRun.testsuite.result != currentTestRun.testsuite.result)
                        {
                            mergedTestRun.testsuite.result = currentTestRun.testsuite.result;
                        }

                        mergedTestRun.testsuite.total += currentTestRun.testsuite.total;
                        mergedTestRun.testsuite.passed += currentTestRun.testsuite.passed;
                        mergedTestRun.testsuite.failed += currentTestRun.testsuite.failed;
                        mergedTestRun.testsuite.warnings += currentTestRun.testsuite.warnings;
                        mergedTestRun.testsuite.inconclusive += currentTestRun.testsuite.inconclusive;
                        mergedTestRun.testsuite.skipped += currentTestRun.testsuite.skipped;
                        mergedTestRun.testsuite.asserts += currentTestRun.testsuite.asserts;
                        mergedTestRun.testsuite.endtime = currentTestRun.testsuite.endtime;

                        foreach (var testSuiteNamespace in currentTestRun.testsuite.testsuite)
                        {
                            if (mergedTestRun.testsuite.testsuite.Any(x => x.id.Equals(testSuiteNamespace.id)))
                            {
                                var mergedTestRunTestSuiteNamespace = mergedTestRun.testsuite.testsuite.First(x => x.id.Equals(testSuiteNamespace.id));

                                // Merge namespace level test suite. If exist update if not add to the array?
                                if (mergedTestRunTestSuiteNamespace.result == "Passed" && mergedTestRunTestSuiteNamespace.result != testSuiteNamespace.result)
                                {
                                    mergedTestRunTestSuiteNamespace.result = testSuiteNamespace.result;
                                }

                                mergedTestRunTestSuiteNamespace.total += testSuiteNamespace.total;
                                mergedTestRunTestSuiteNamespace.passed += testSuiteNamespace.passed;
                                mergedTestRunTestSuiteNamespace.failed += testSuiteNamespace.failed;
                                mergedTestRunTestSuiteNamespace.warnings += testSuiteNamespace.warnings;
                                mergedTestRunTestSuiteNamespace.inconclusive += testSuiteNamespace.inconclusive;
                                mergedTestRunTestSuiteNamespace.skipped += testSuiteNamespace.skipped;
                                mergedTestRunTestSuiteNamespace.asserts += testSuiteNamespace.asserts;
                                mergedTestRunTestSuiteNamespace.endtime = testSuiteNamespace.endtime;

                                foreach (var testSuiteTestSuite in testSuiteNamespace.testsuite)
                                {
                                    if (mergedTestRunTestSuiteNamespace.testsuite.Any(x => x.id.Equals(testSuiteNamespace.id)))
                                    {
                                        var mergedTestRunTestSuiteClass = mergedTestRunTestSuiteNamespace.testsuite.First(x => x.id.Equals(testSuiteNamespace.id));

                                        // Merge test suite class level.
                                        mergedTestRunTestSuiteClass.failed = testSuiteTestSuite.testcase.Count(x => x.result.Equals("Failed"));
                                        mergedTestRunTestSuiteClass.passed = testSuiteTestSuite.testcase.Count(x => x.result.Equals("Passed"));
                                        if (mergedTestRunTestSuiteClass.passed != testSuiteTestSuite.testcase.Length)
                                        {
                                            mergedTestRunTestSuiteClass.result = "Failed";
                                        }
                                        else
                                        {
                                            mergedTestRunTestSuiteClass.result = "Passed";
                                        }

                                        mergedTestRunTestSuiteClass.total += testSuiteTestSuite.total;
                                        mergedTestRunTestSuiteClass.passed += testSuiteTestSuite.passed;
                                        mergedTestRunTestSuiteClass.failed += testSuiteTestSuite.failed;
                                        mergedTestRunTestSuiteClass.warnings += testSuiteTestSuite.warnings;
                                        mergedTestRunTestSuiteClass.inconclusive += testSuiteTestSuite.inconclusive;
                                        mergedTestRunTestSuiteClass.skipped += testSuiteTestSuite.skipped;
                                        mergedTestRunTestSuiteClass.asserts += testSuiteTestSuite.asserts;
                                        mergedTestRunTestSuiteClass.endtime = testSuiteTestSuite.endtime;
                                    }
                                    else
                                    {
                                        var mergedTestSuitesClass = mergedTestRunTestSuiteNamespace.testsuite.ToList();
                                        mergedTestSuitesClass.Add(testSuiteTestSuite);
                                        mergedTestRunTestSuiteNamespace.testsuite = mergedTestSuitesClass.ToArray();
                                    }
                                }
                            }
                            else
                            {
                                var mergedTestSuites = mergedTestRun.testsuite.testsuite.ToList();
                                mergedTestSuites.Add(testSuiteNamespace);
                                mergedTestRun.testsuite.testsuite = mergedTestSuites.ToArray();
                            }
                        }
                    }
                }
            }

            if (mergedTestRun != null)
            {
                result = Serialize(mergedTestRun);
            }

            return result;
        }

        public void UpdatePassedTests(object passedTests, object testRun)
        {
            var allTests = GetAllExecutedTestCases((testrun)testRun).ToArray();
            foreach (var currentTest in allTests)
            {
                if (((testrunTestsuiteTestsuiteTestsuiteTestcase[])passedTests).Count(x => x.id.Equals(currentTest.id)) > 0)
                {
                    currentTest.result = "Passed";
                }
            }
        }

        public void UpdateResultsSummary(object testRunObj)
        {
            var testRun = (testrun)testRunObj;
            foreach (var testSuiteNamespace in testRun.testsuite.testsuite)
            {
                foreach (var testSuiteTestSuite in testSuiteNamespace.testsuite)
                {
                    testSuiteTestSuite.failed = testSuiteTestSuite.testcase.Count(x => x.result.Equals("Failed"));
                    testSuiteTestSuite.passed = testSuiteTestSuite.testcase.Count(x => x.result.Equals("Passed"));
                    if (testSuiteTestSuite.passed != testSuiteTestSuite.testcase.Length)
                    {
                        testSuiteNamespace.result = "Failed";
                        testSuiteTestSuite.result = "Failed";
                    }
                    else
                    {
                        testSuiteNamespace.result = "Passed";
                        testSuiteTestSuite.result = "Passed";
                    }
                }
            }
        }

        public List<TestCaseRun> UpdateTestCasesHistory(object testRunContent, string libraryName)
        {
            var testRun = Deserialize<testrun>((string)testRunContent);
            var allPassedTestsTestRun = GetAllPassesTests(testRunContent);
            var testCaseRuns = new List<TestCaseRun>();
            foreach (var currentNUnitTestCase in (List<testrunTestsuiteTestsuiteTestsuiteTestcase>)allPassedTestsTestRun)
            {
                var duration = TimeSpan.FromSeconds((double)currentNUnitTestCase.duration);
                var unitTestLibraryName = testRun.testsuite.fullname;
                var fullName = currentNUnitTestCase.fullname;
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
            int numberOfTestsPerList = (int)Math.Ceiling(orderedByClassTestCases.Count / (double)availableCores);

            List<List<TestCase>> distributedTestCases = new List<List<TestCase>>();
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

        public List<TestCase> GetAllNotPassedTests(string testResultsFileContent)
        {
            testrun testRun = Deserialize<testrun>(testResultsFileContent);
            var testCases = new List<TestCase>();
            foreach (var testSuiteNamespace in testRun.testsuite.testsuite)
            {
                foreach (var testSuiteTestSuite in testSuiteNamespace.testsuite)
                {
                    foreach (var testSuiteTestCase in testSuiteTestSuite.testcase.Where(x => !x.result.Equals("Passed")).ToList())
                    {
                        testCases.Add(new TestCase(testSuiteTestCase.fullname, testSuiteTestSuite.name));
                    }
                }
            }

            return testCases;
        }

        public List<TestCase> GetAllPassesTestCases(string testResultsFileContent)
        {
            testrun testRun = Deserialize<testrun>(testResultsFileContent);
            var testCases = new List<TestCase>();
            foreach (var testSuiteNamespace in testRun.testsuite.testsuite)
            {
                foreach (var testSuiteTestSuite in testSuiteNamespace.testsuite)
                {
                    foreach (var testSuiteTestCase in testSuiteTestSuite.testcase.Where(x => x.result.Equals("Passed")).ToList())
                    {
                        testCases.Add(new TestCase(testSuiteTestCase.fullname, testSuiteTestSuite.name));
                    }
                }
            }

            return testCases;
        }

        public object GetRetriedTestResultsForTestRun(List<TestAgentRunDto> testAgentRuns)
        {
            var testRuns = new List<object>();
            if (testAgentRuns.Any())
            {
                foreach (var testAgentRun in testAgentRuns)
                {
                    if (!string.IsNullOrEmpty(testAgentRun.TestAgentRetriedRunResults))
                    {
                        var msTestTestRun = Deserialize<testrun>(testAgentRun.TestAgentRetriedRunResults);
                        testRuns.Add(msTestTestRun);
                    }
                }
            }

            return testRuns;
        }

        public object GetTestResultsForTestRun(List<TestAgentRunDto> testAgentRuns)
        {
            var testRuns = new List<object>();
            if (testAgentRuns.Any())
            {
                foreach (var testAgentRun in testAgentRuns)
                {
                    if (!string.IsNullOrEmpty(testAgentRun.TestAgentOriginalRunResults))
                    {
                        var testRun = Deserialize<testrun>(testAgentRun.TestAgentOriginalRunResults);
                        testRuns.Add(testRun);
                    }
                }
            }

            return testRuns;
        }

        public void ExecutePostRunActions()
        {
        }

        private bool ShouldResetTestsPerList(bool sameMachineByClass, string currentClass, string previousClass)
            => !sameMachineByClass || previousClass != currentClass;

        private List<testrunTestsuiteTestsuiteTestsuiteTestcase> GetAllExecutedTestCases(testrun testRun)
        {
            var allTestCases = new List<testrunTestsuiteTestsuiteTestsuiteTestcase>();
            foreach (var testSuiteNamespace in testRun.testsuite.testsuite)
            {
                foreach (var testSuiteTestSuite in testSuiteNamespace.testsuite)
                {
                    allTestCases.AddRange(testSuiteTestSuite.testcase.ToList());
                }
            }

            return allTestCases;
        }

        private string CreateTestListFile(List<TestCase> distributedTestCases)
        {
            var testListFilePath = Path.GetTempFileName();
            var sb = new StringBuilder();
            foreach (var testCase in distributedTestCases)
            {
                sb.AppendLine(testCase.FullName);
            }

            File.WriteAllText(testListFilePath, sb.ToString());
            return testListFilePath;
        }

        private TEntity Deserialize<TEntity>(string content)
        {
            var serializer = new XmlSerializer(typeof(TEntity));
            var reader = new StringReader(content);
            var testRun = (TEntity)serializer.Deserialize(reader);
            reader.Close();

            return testRun;
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

        private string GetRunningAssemblyPath() => Assembly.GetExecutingAssembly().Location;
    }
}