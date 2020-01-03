// <copyright file="INativeTestsRunnerPluginService.cs" company="Automate The Planet Ltd.">
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
using System.Collections.Generic;
using Meissa.Core.Model;
using Meissa.Server.Models;

namespace Meissa.Plugins.Contracts
{
    public interface INativeTestsRunnerPluginService
    {
        string Name { get; }
        string RunnerFile { get; }
        string ResultsFileExtension { get; }
        List<string> RunnerProcessesNamesToKill { get; }
        object DeserializeTestResults(string originalRunTestResults);
        object GetAllPassesTests(object testRun);
        int GetAllPassesTestsCount(object testRun);
        int GetAllNotPassesTestsCount(object testRun);
        object GetAllPassesTests(string testRunContent);
        void UpdatePassedTests(object passedTests, object testRun);
        void UpdateResultsSummary(object testRunObj);
        List<TestCaseRun> UpdateTestCasesHistory(object testRun, string libraryName);
        string MergeTestResults(object testResultsToBeMergedObj);
        string BuildNativeRunnerArguments(string libraryName, string libraryPath, List<TestCase> testCasesToBeExecuted, string testResultsFilePath, string outputFilesDir, string nativeArguments);
        List<List<TestCase>> SplitTestCases(int availableCores, bool sameMachineByClass, List<TestCase> testCasesToBeDistributed);
        List<TestCase> GetAllNotPassedTests(string testResultsFileContent);
        List<TestCase> GetAllPassesTestCases(string testResultsFileContent);
        object GetRetriedTestResultsForTestRun(List<TestAgentRunDto> testAgentRuns);
        object GetTestResultsForTestRun(List<TestAgentRunDto> testAgentRuns);
        string SerializeTestResults(object testResults);
        void ExecutePostRunActions();
    }
}
