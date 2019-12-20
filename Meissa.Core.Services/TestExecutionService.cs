// <copyright file="TestExecutionService.cs" company="Automate The Planet Ltd.">
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
using System.Threading.Tasks;
using Meissa.Core.Contracts;
using Meissa.Core.Model;
using Meissa.Core.Model.Settings;
using Meissa.Plugins.Contracts;

namespace Meissa.Core.Services
{
    public class TestExecutionService
    {
        private const string TestRunHasTimedOut = "### The test run timeout. It ran for over {0} minutes. ###";
        private const string TestAgentRunsHasFinished = "### All Test Agent Runs Finished! ###";
        private const string NoTestAgentsAreAvailable = "### No test agents where available for the provided tag! ###";
        private const int ExecutionFrequency = 30000;
        private readonly IFileProvider _fileProvider;
        private readonly ITestRunProvider _testRunProvider;
        private readonly ITestRunsCleanerServiceClient _testRunsCleanerServiceClient;
        private readonly ITestsCountsBasedDistributeService _testCountsBasedDistributeService;
        private readonly ITestsTimesBasedDistributeService _testsTimesBasedDistributeService;
        private readonly ITestAgentRunProvider _testAgentRunProvider;
        private readonly ITestsRunnerTestResultsService _testResultsService;
        private readonly IConsoleProvider _consoleProvider;
        private readonly ITestAgentsService _testAgentService;
        private readonly IPathProvider _pathProvider;
        private readonly ITestCasesFilterService _testCasesFilterService;
        private readonly ITestCasesHistoryService _testCasesHistoryService;
        private readonly IPluginService _pluginService;
        private INativeTestsRunnerTestCasesPluginService _testCasesProvider;

        public TestExecutionService(
            IFileProvider fileProvider,
            ITestRunProvider testRunProvider,
            ITestRunsCleanerServiceClient testRunsCleanerServiceClient,
            ITestsCountsBasedDistributeService testCountsBasedDistributeService,
            ITestsTimesBasedDistributeService testsTimesBasedDistributeService,
            ITestAgentRunProvider testAgentRunProvider,
            ITestsRunnerTestResultsService testResultsService,
            IConsoleProvider consoleProvider,
            ITestAgentsService testAgentService,
            IPathProvider pathProvider,
            ITestCasesFilterService testCasesFilterService,
            ITestCasesHistoryService testCasesHistoryService,
            IPluginService pluginService)
        {
            _fileProvider = fileProvider;
            _testRunProvider = testRunProvider;
            _testRunsCleanerServiceClient = testRunsCleanerServiceClient;
            _testCountsBasedDistributeService = testCountsBasedDistributeService;
            _testsTimesBasedDistributeService = testsTimesBasedDistributeService;
            _testAgentRunProvider = testAgentRunProvider;
            _testResultsService = testResultsService;
            _consoleProvider = consoleProvider;
            _testAgentService = testAgentService;
            _pathProvider = pathProvider;
            _testCasesFilterService = testCasesFilterService;
            _testCasesHistoryService = testCasesHistoryService;
            _pluginService = pluginService;
        }

        public async Task<bool> ExecuteAsync(TestRunSettings testRunSettings)
        {
            if (!_pathProvider.IsFilePathValid(testRunSettings.ResultsFilePath))
            {
                throw new ArgumentException($"The specified test results file path is not valid. Specified path = {testRunSettings.ResultsFilePath}");
            }

            _pluginService.ExecuteAllTestRunnerPluginsPreTestRunLogic();

            await _testRunsCleanerServiceClient.DeleteOldTestRunsDataAsync();
            await _testCasesHistoryService.DeleteOlderTestCasesHistoryAsync();

            var activeTestAgents = await _testAgentService.GetAllActiveTestAgentsByTagAsync(testRunSettings.AgentTag);
            await _testAgentService.SetAllActiveAgentsToVerifyTheirStatusAsync(testRunSettings.AgentTag);
            _testAgentService.WaitAllActiveAgentsToVerifyTheirStatusAsync(activeTestAgents);
            var availableTestAgents = await _testAgentService.GetAllActiveTestAgentsByTagAsync(testRunSettings.AgentTag);
            bool wasSuccessfulRun = false;
            if (availableTestAgents.Count > 0)
            {
                var tempFilePath = _pathProvider.GetTempFileName();
                _fileProvider.Delete(tempFilePath);
                _fileProvider.CreateZip(testRunSettings.OutputFilesLocation, tempFilePath);
                var zipData = _fileProvider.ReadAllBytes(tempFilePath);

                var testRunId = await _testRunProvider.CreateNewTestRunAsync(_pathProvider.GetFileName(testRunSettings.TestLibraryPath), zipData, testRunSettings.RetriesCount, testRunSettings.Threshold, testRunSettings.RunInParallel, testRunSettings.MaxParallelProcessesCount, testRunSettings.NativeArguments, testRunSettings.TestTechnology, testRunSettings.TimeBasedBalance, testRunSettings.SameMachineByClass, testRunSettings.CustomArguments);
                _testCasesProvider = _pluginService.GetNativeTestsRunnerTestCasesPluginService(testRunSettings.TestTechnology);
                var allTestCases = _testCasesProvider.ExtractAllTestCasesFromTestLibrary(testRunSettings.TestLibraryPath);
                var filteredTestCases = _testCasesFilterService.FilterCases(allTestCases, testRunSettings.TestsFilter);

                var distributedTestsLists = testRunSettings.TimeBasedBalance ?
                    await _testsTimesBasedDistributeService.GenerateDistributionListsAsync(availableTestAgents.Count, testRunSettings.SameMachineByClass, filteredTestCases) :
                    _testCountsBasedDistributeService.GenerateDistributionLists(availableTestAgents.Count, testRunSettings.SameMachineByClass, filteredTestCases);

                var testAgentRuns = await _testAgentRunProvider.CreateNewTestAgentRunsAsync(testRunId, availableTestAgents, distributedTestsLists);
                try
                {
                    // TODO: pass ExecutionFrequency from args console?
                    await _testAgentRunProvider.WaitForTestAgentRunsToFinishAsync(testAgentRuns, testRunSettings.TestRunTimeout, ExecutionFrequency);

                    // DEBUG:
                    ////_consoleProvider.WriteLine("AFTER WaitForTestAgentRunsToFinishAsync");
                    _consoleProvider.WriteLine(TestAgentRunsHasFinished);
                }
                catch (TimeoutException)
                {
                    _consoleProvider.WriteLine(string.Format(TestRunHasTimedOut, testRunSettings.TestRunTimeout));
                    await _testAgentRunProvider.AbortAllTestAgentRunsInTestRunAsync(testRunId);
                }

                var areThereAbortedTestAgentRuns = await _testAgentRunProvider.AreThereAbortedTestAgentRunsAsync(testRunId);
                if (!areThereAbortedTestAgentRuns)
                {
                    // DEBUG:
                    ////_consoleProvider.WriteLine("START COMPLEETING TEST RUN");
                    await _testRunProvider.CompleteTestRunAsync(testRunId, TestRunStatus.Completed);
                    wasSuccessfulRun = true;

                    // DEBUG:
                    _consoleProvider.WriteLine("TEST RUN COMPLETED");
                    await _testResultsService.SaveTestResultsForCurrentRunAsync(testRunSettings.TestTechnology, testRunSettings.ResultsFilePath, testRunSettings.RetriedResultsFilePath, testRunId);
                    try
                    {
                        await _testRunsCleanerServiceClient.DeleteOldTestRunDataByTestRunIdAsync(testRunId);
                    }
                    catch (Exception e)
                    {
                        _consoleProvider.WriteLine(e.ToString());
                    }
                }
                else
                {
                    _consoleProvider.WriteLine("Test Run Aborted!");
                    await _testRunProvider.CompleteTestRunAsync(testRunId, TestRunStatus.Aborted);
                }
            }
            else
            {
                _consoleProvider.WriteLine(NoTestAgentsAreAvailable);
            }

            _pluginService.ExecuteAllTestRunnerPluginsPostTestRunLogic();

            return wasSuccessfulRun;
        }
    }
}