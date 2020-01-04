// <copyright file="TestRunnerService.cs" company="Automate The Planet Ltd.">
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
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Meissa.Core.Contracts;
using Meissa.Core.Model;
using Meissa.Plugins.Contracts;
using Meissa.Server.Models;

namespace Meissa.Infrastructure
{
    public class TestRunnerService : ITestsRunnerService
    {
        private readonly IServiceClient<TestRunDto> _testRunRepository;
        private readonly IServiceClient<TestRunLogDto> _testRunLogRepository;
        private readonly IProcessProvider _processStarter;
        private readonly IFileProvider _fileProvider;
        private readonly IDirectoryProvider _directoryProvider;
        private readonly IPathProvider _pathProvider;
        private readonly IConsoleProvider _consoleProvider;
        private readonly ITestsRunnerTestResultsService _testResultsService;
        private readonly IJsonSerializer _jsonSerializer;
        private readonly ITestCasesHistoryService _testCasesHistoryService;
        private readonly ITaskProvider _taskProvider;
        private readonly IPluginService _pluginService;
        private readonly ITestRunLogService _testRunLogService;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IEnvironmentService _environmentService;
        private INativeTestsRunnerPluginService _nativeTestsRunner;
        private Guid _currentTestRunId;

        public TestRunnerService(
            IServiceClient<TestRunDto> testRunRepository,
            IServiceClient<TestRunLogDto> testRunLogRepository,
            IProcessProvider processStarter,
            IFileProvider fileProvider,
            IDirectoryProvider directoryProvider,
            IPathProvider pathProvider,
            IConsoleProvider consoleProvider,
            ITestsRunnerTestResultsService testResultsService,
            IJsonSerializer jsonSerializer,
            ITestCasesHistoryService testCasesHistoryService,
            ITaskProvider taskProvider,
            IPluginService pluginService,
            ITestRunLogService testRunLogService,
            IDateTimeProvider dateTimeProvider,
            IEnvironmentService environmentService)
        {
            _testRunRepository = testRunRepository;
            _testRunLogRepository = testRunLogRepository;
            _processStarter = processStarter;
            _fileProvider = fileProvider;
            _directoryProvider = directoryProvider;
            _pathProvider = pathProvider;
            _consoleProvider = consoleProvider;
            _testResultsService = testResultsService;
            _jsonSerializer = jsonSerializer;
            _testCasesHistoryService = testCasesHistoryService;
            _taskProvider = taskProvider;
            _pluginService = pluginService;
            _testRunLogService = testRunLogService;
            _dateTimeProvider = dateTimeProvider;
            _environmentService = environmentService;
        }

        public async Task<string> ExecuteTestsAsync(string testTechnology, string distributedTestsList, string workingDir, Guid testRunId, string testsLibraryPath, string assemblyName, bool runInParallel, string nativeArguments, int testAgentRunTimeout, bool isTimeBasedBalance, bool sameMachineByClass, CancellationTokenSource cancellationTokenSource)
        {
            _currentTestRunId = testRunId;
            _nativeTestsRunner = _pluginService.GetNativeTestRunnerService(testTechnology);
            var testRun = await _testRunRepository.GetAsync(testRunId).ConfigureAwait(false);
            var distributedTestCases = _jsonSerializer.Deserialize<List<TestCase>>(distributedTestsList);
            var testTestResults = await ExecuteTestsWithNativeRunnerAsync(workingDir, testsLibraryPath, assemblyName, runInParallel, testRun.MaxParallelProcessesCount, nativeArguments, testAgentRunTimeout, isTimeBasedBalance, sameMachineByClass, distributedTestCases, cancellationTokenSource).ConfigureAwait(false);

            return testTestResults;
        }

        public async Task<string> ExecuteTestsWithRetryAsync(
            string testTechnology,
            string originalRunTestResults,
            string distributedTestsList,
            string workingDir,
            Guid testRunId,
            string testsLibraryPath,
            string assemblyName,
            bool runInParallel,
            string nativeArguments,
            int testAgentRunTimeout,
            int retriesCount,
            double threshold,
            bool isTimeBasedBalance,
            bool sameMachineByClass,
            CancellationTokenSource cancellationTokenSource)
        {
            _currentTestRunId = testRunId;
            _nativeTestsRunner = _pluginService.GetNativeTestRunnerService(testTechnology);
            var testRun = await _testRunRepository.GetAsync(testRunId).ConfigureAwait(false);
            var distributedTestCases = _jsonSerializer.Deserialize<List<TestCase>>(distributedTestsList);
            if (string.IsNullOrEmpty(originalRunTestResults))
            {
                return null;
            }

            var originalTestRun = _nativeTestsRunner.DeserializeTestResults(originalRunTestResults);
            var failedTests = _testResultsService.GetAllNotPassedTests(testTechnology, originalRunTestResults);
            double failedTestsPercentage = _testResultsService.CalculatedFailedTestsPercentage(failedTests, distributedTestCases);
            await _testRunLogService.CreateTestRunLogAsync($"failedTestsPercentage= {failedTestsPercentage} < threshold = {threshold}", testRunId).ConfigureAwait(false);
            if (failedTests.Count > 0 && failedTestsPercentage < threshold)
            {
                await _testRunLogService.CreateTestRunLogAsync($"The failed test % {failedTestsPercentage} < threshold % {threshold}. The failed tests will be retried {retriesCount} times.", testRunId).ConfigureAwait(false);
                for (int i = 0; i < retriesCount; i++)
                {
                    if (cancellationTokenSource.Token.IsCancellationRequested)
                    {
                        return null;
                    }

                    await _testRunLogService.CreateTestRunLogAsync($"Start failed tests retry number {i + 1}.", testRunId).ConfigureAwait(false);
                    string retriedTestTestResults;
                    if (failedTests.Count > 0)
                    {
                        await _testRunLogService.CreateTestRunLogAsync($"{failedTests.Count} tests will be retried.", testRunId).ConfigureAwait(false);
                        retriedTestTestResults = await ExecuteTestsWithNativeRunnerAsync(workingDir, testsLibraryPath, assemblyName, runInParallel, testRun.MaxParallelProcessesCount, nativeArguments, testAgentRunTimeout, isTimeBasedBalance, sameMachineByClass, failedTests, cancellationTokenSource).ConfigureAwait(false);

                        var passedTests = _nativeTestsRunner.GetAllPassesTests(retriedTestTestResults);
                        _nativeTestsRunner.UpdatePassedTests(passedTests, originalTestRun);
                        _nativeTestsRunner.UpdateResultsSummary(originalTestRun);
                    }
                    else
                    {
                        break;
                    }

                    if (!string.IsNullOrEmpty(retriedTestTestResults))
                    {
                        failedTests = _testResultsService.GetAllNotPassedTests(testTechnology, retriedTestTestResults);
                    }
                }
            }
            else
            {
                await _testRunLogService.CreateTestRunLogAsync($"Percentage of failed tests {failedTestsPercentage} is over threshold {threshold}, will not retry tests.", testRunId).ConfigureAwait(false);
            }

            string retriedRunTestResults = _nativeTestsRunner.SerializeTestResults(originalTestRun);

            return retriedRunTestResults;
        }

        private async Task<string> ExecuteTestsWithNativeRunnerAsync(
            string workingDir,
            string testsLibraryPath,
            string assemblyName,
            bool runInParallel,
            int maxParallelProcessesCount,
            string nativeArguments,
            int testAgentRunTimeout,
            bool isTimeBasedBalance,
            bool sameMachineByClass,
            List<TestCase> distributedTestCases,
            CancellationTokenSource outerCancellationTokenSource)
        {
            var outputFilesDir = _pathProvider.GetDirectoryName(testsLibraryPath);
            var availableCores = runInParallel ? maxParallelProcessesCount : 1;

            // Merge logic of CreateRunFilterArgument here. remove inner foreach
            var listOfDistributedTestCases = _nativeTestsRunner.SplitTestCases(availableCores, sameMachineByClass, distributedTestCases);
            var testRunsToBeMerged = new List<object>();
            var testRunProcesses = new List<Process>();
            var resultsFiles = new List<string>();

            var processCreationTime = _dateTimeProvider.GetCurrentTime();

            foreach (var distributedTestCasesList in listOfDistributedTestCases)
            {
                var currentTestResultsFilePath = _pathProvider.GetTempFileName();
                resultsFiles.Add(currentTestResultsFilePath);
                var arguments = _nativeTestsRunner.BuildNativeRunnerArguments(
                    assemblyName,
                    testsLibraryPath,
                    distributedTestCasesList,
                    currentTestResultsFilePath,
                    outputFilesDir,
                    nativeArguments);

                var currentProcess = _processStarter.InitializeProcess(
                    _nativeTestsRunner.RunnerFile,
                    workingDir,
                    arguments,
                    LogStandardOutput,
                    LogErrorOutput);
                testRunProcesses.Add(currentProcess);
            }

            var innerCancellationTokenSource = new CancellationTokenSource();

            var waitForNativeRunnerProcessesToFinishTask = _taskProvider.StartNewLongRunning(
                         (c) =>
                         {
                             var ranProcesses = new List<int>();
                             do
                             {
                                 var coresCount = availableCores;
                                 if (runInParallel)
                                 {
                                     foreach (var process in testRunProcesses)
                                     {
                                         if (coresCount == 0)
                                         {
                                             break;
                                         }

                                         if (!ranProcesses.Contains(process.GetHashCode()))
                                         {
                                             _processStarter.StartProcess(process, LogStandardOutput, LogErrorOutput);
                                             Thread.Sleep(1000);
                                             ranProcesses.Add(process.GetHashCode());
                                             coresCount--;
                                         }
                                     }
                                 }

                                 // Do not start all processes upfront
                                 // if parallel here start all of them?
                                 // run in task and pass cancellation token. If is canceled kill all processes. DO IT for NUNIT TOO
                                 foreach (var process in testRunProcesses)
                                 {
                                     if (outerCancellationTokenSource.Token.IsCancellationRequested)
                                     {
                                         return;
                                     }

                                     if (!runInParallel)
                                     {
                                         // Start processes one by one, otherwise they are started all upfront.
                                         _processStarter.StartProcess(process, LogStandardOutput, LogErrorOutput);
                                         ranProcesses.Add(process.GetHashCode());
                                     }

                                     if (ranProcesses.Contains(process.GetHashCode()))
                                     {
                                         _processStarter.WaitForProcessToFinish(testAgentRunTimeout, process);
                                     }
                                 }
                             }
                             while (ranProcesses.Count != testRunProcesses.Count);
                         },
                         innerCancellationTokenSource);

            var checkCancellationRequestsTask = _taskProvider.StartNewLongRunningRepeating(
                         innerCancellationTokenSource,
                         () =>
                         {
                             if (waitForNativeRunnerProcessesToFinishTask.IsCompleted || waitForNativeRunnerProcessesToFinishTask.IsFaulted)
                             {
                                 if (waitForNativeRunnerProcessesToFinishTask.IsFaulted)
                                 {
                                     _testRunLogService.CreateTestRunLogAsync($"waitForNativeRunnerProcessesToFinishTask FAULTED- {waitForNativeRunnerProcessesToFinishTask.Exception}", _currentTestRunId).Wait();
                                 }

                                 innerCancellationTokenSource.Cancel();
                             }
                             else if (outerCancellationTokenSource.Token.IsCancellationRequested)
                             {
                                 foreach (var processName in _nativeTestsRunner.RunnerProcessesNamesToKill)
                                 {
                                     var processes = Process.GetProcessesByName(processName);
                                     foreach (var process in processes)
                                     {
                                         try
                                         {
                                             if (process.StartTime > processCreationTime)
                                             {
                                                 process.Kill();
                                                 process.WaitForExit();
                                             }
                                         }
                                         catch (Exception e)
                                         {
                                             _consoleProvider.WriteLine(e.ToString());
                                         }
                                     }
                                 }
                             }
                         },
                         5000);
            checkCancellationRequestsTask.Wait(innerCancellationTokenSource.Token);

            string result = null;
            if (!outerCancellationTokenSource.Token.IsCancellationRequested)
            {
                foreach (var testResultFile in resultsFiles)
                {
                    if (_fileProvider.Exists(testResultFile))
                    {
                        var testTestResults = _fileProvider.ReadAllText(testResultFile);
                        var currentTestRun = _nativeTestsRunner.DeserializeTestResults(testTestResults);
                        testRunsToBeMerged.Add(currentTestRun);
                    }
                    else if (_directoryProvider.Exists(testResultFile))
                    {
                        // TODO: Added this because of the Protractor Plugin, since it produces folder instead of file.
                        // Fix it later with something more generic solution. Maybe, we have to save the test results to plugin folder and
                        // add a plugin method for deleting them at the end.
                        var files = _directoryProvider.GetFiles(testResultFile);
                        if (!files.Any())
                        {
                            throw new Exception("No test results' file was produced for test run");
                        }

                        var firstFile = _directoryProvider.GetFiles(testResultFile).First();
                        var testTestResults = _fileProvider.ReadAllText(firstFile);
                        var currentTestRun = _nativeTestsRunner.DeserializeTestResults(testTestResults);
                        testRunsToBeMerged.Add(currentTestRun);
                    }
                    else
                    {
                        throw new Exception("No test results' file was produced for test run");
                    }
                }

                var mergedTestRun = _nativeTestsRunner.MergeTestResults(testRunsToBeMerged);
                if (isTimeBasedBalance)
                {
                    // TODO: This is run on the agent. So, the info should be sent back to the runner or if we have the info there?
                    // Maybe we should return the tables and persists there.
                    var testCaseRuns = _nativeTestsRunner.UpdateTestCasesHistory(mergedTestRun, assemblyName);
                    await _testCasesHistoryService.UpdateTestCaseExecutionHistoryAsync(testCaseRuns).ConfigureAwait(false);
                }

                try
                {
                    _nativeTestsRunner.ExecutePostRunActions();
                }
                catch (Exception ex)
                {
                    _testRunLogService.CreateTestRunLogAsync($"There was a problem executing ExecutePostRunActions on {Environment.MachineName}. Exception: {ex}", _currentTestRunId).Wait();
                }

                result = mergedTestRun;
            }

            return result;
        }

        public void LogStandardOutput(string message)
        {
            if (!string.IsNullOrEmpty(message) && !message.Contains("Test:"))
            {
                var testRunLog = new TestRunLogDto
                {
                    Message = message,
                    TestRunId = _currentTestRunId,
                    Status = TestRunLogStatus.New,
                };
                try
                {
                    _testRunLogRepository.CreateAsync(testRunLog).Wait();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    _consoleProvider.WriteLine(e.Message);
                }
            }

            _consoleProvider.WriteLine(message);
        }

        public void LogErrorOutput(string message) => _consoleProvider.WriteLine(message);
    }
}