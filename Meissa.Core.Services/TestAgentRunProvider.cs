// <copyright file="TestAgentRunProvider.cs" company="Automate The Planet Ltd.">
// Copyright 2024 Automate The Planet Ltd.
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
using System.Linq;
using System.Security;
using System.Threading;
using System.Threading.Tasks;
using Meissa.Core.Contracts;
using Meissa.Core.Model;
using Meissa.Model;
using Meissa.Server.Models;

namespace Meissa.Core.Services;

public class TestAgentRunProvider : ITestAgentRunProvider
{
    private readonly IServiceClient<TestRunDto> _testRunRepository;
    private readonly ITestRunOutputServiceClient _testRunOutputServiceClient;
    private readonly IServiceClient<TestAgentDto> _testAgentRepository;
    private readonly IServiceClient<TestAgentRunDto> _testAgentRunRepository;
    private readonly IServiceClient<TestRunCustomArgumentDto> _testRunCustomArgumentRepository;
    private readonly ITestsRunnerService _nativeTestsRunner;
    private readonly ITestAgentsLoggerService _testAgentsLoggerService;
    private readonly IDistributeLogger _logger;
    private readonly ITestAgentStateSwitcher _testAgentStateSwitcher;
    private readonly IConsoleProvider _consoleProvider;
    private readonly IPathProvider _pathProvider;
    private readonly IFileProvider _fileProvider;
    private readonly IEnvironmentService _environmentService;
    private readonly IGuidService _guidService;
    private readonly IPluginService _pluginService;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly ITaskProvider _taskProvider;
    private readonly ITestRunLogService _testRunLogService;
    private readonly ITestAgentRunAvailabilityServiceClient _testAgentRunAvailabilityServiceClient;
    private readonly ITestRunAvailabilityServiceClient _testRunAvailabilityServiceClient;
    private readonly IDirectoryProvider _directoryProvider;
    private int? _currentTestAgentId;
    private bool _wasTestAgentRunCompleted;

    public TestAgentRunProvider(
        IServiceClient<TestRunDto> testRunRepository,
        ITestRunOutputServiceClient testRunOutputServiceClient,
        IServiceClient<TestAgentDto> testAgentRepository,
        IServiceClient<TestAgentRunDto> testAgentRunRepository,
        IServiceClient<TestRunCustomArgumentDto> testRunCustomArgumentRepository,
        ITestsRunnerService nativeTestsRunner,
        ITestAgentsLoggerService testAgentsLoggerService,
        IDistributeLogger logger,
        ITestAgentStateSwitcher testAgentStateSwitcher,
        IPathProvider pathProvider,
        IFileProvider fileProvider,
        IConsoleProvider consoleProvider,
        IEnvironmentService environmentService,
        IGuidService guidService,
        IPluginService pluginService,
        IDateTimeProvider dateTimeProvider,
        ITaskProvider taskProvider,
        ITestRunLogService testRunLogService,
        ITestAgentRunAvailabilityServiceClient testAgentRunAvailabilityServiceClient,
        ITestRunAvailabilityServiceClient testRunAvailabilityServiceClient,
        IDirectoryProvider directoryProvider)
    {
        _testRunRepository = testRunRepository;
        _testRunOutputServiceClient = testRunOutputServiceClient;
        _testAgentRepository = testAgentRepository;
        _testAgentRunRepository = testAgentRunRepository;
        _testRunCustomArgumentRepository = testRunCustomArgumentRepository;
        _nativeTestsRunner = nativeTestsRunner;
        _testAgentsLoggerService = testAgentsLoggerService;
        _logger = logger;
        _testAgentStateSwitcher = testAgentStateSwitcher;
        _consoleProvider = consoleProvider;
        _pathProvider = pathProvider;
        _fileProvider = fileProvider;
        _environmentService = environmentService;
        _guidService = guidService;
        _pluginService = pluginService;
        _dateTimeProvider = dateTimeProvider;
        _taskProvider = taskProvider;
        _testRunLogService = testRunLogService;
        _testAgentRunAvailabilityServiceClient = testAgentRunAvailabilityServiceClient;
        _testRunAvailabilityServiceClient = testRunAvailabilityServiceClient;
        _directoryProvider = directoryProvider;
        _wasTestAgentRunCompleted = false;
    }

    public async Task<List<TestAgentRunDto>> CreateNewTestAgentRunsAsync(Guid testRunId, List<TestAgentDto> testAgents, List<string> testLists)
    {
        if (testAgents.Count == 0 || testLists.Count == 0)
        {
            throw new ArgumentException("The test lists' or test agents' count cannot be 0.");
        }

        if (testAgents.Count < testLists.Count)
        {
            throw new ArgumentException("The test lists' count cannot be greater than test agents' count.");
        }

        var testAgentRuns = new List<TestAgentRunDto>();

        for (var i = 0; i < testLists.Count; i++)
        {
            if (!string.IsNullOrEmpty(testLists[i]))
            {
                var testAgentRun = new TestAgentRunDto
                {
                    TestAgentId = testAgents[i].TestAgentId,
                    Status = TestAgentRunStatus.New,
                    TestList = testLists[i],
                    TestRunId = testRunId,
                };
                testAgentRun = await _testAgentRunRepository.CreateAsync(testAgentRun).ConfigureAwait(false);
                testAgentRuns.Add(testAgentRun);
            }
        }

        return testAgentRuns;
    }

    public async Task RunTestsForCurrentAgentAsync(string testAgentTag, int testAgentRunTimeout)
    {
        if (await IsEligibleToStartTestAgentRunAsync(testAgentTag).ConfigureAwait(false))
        {
            var newTestAgentRun = await GetFirstNewTestAgentRunForCurrentTestAgentAsync().ConfigureAwait(false);

            if (newTestAgentRun != null)
            {
                await _testRunLogService.CreateTestRunLogAsync($"Test agent with tag {testAgentTag} starts tests execution on machine {_environmentService.MachineName}.", newTestAgentRun.TestRunId).ConfigureAwait(false);
                await _testAgentStateSwitcher.SetTestAgentAsRunningTestsAsync(testAgentTag).ConfigureAwait(false);

                var cancellationTokenSource = new CancellationTokenSource();
                var cancellationTokenSourceLastAvailable = new CancellationTokenSource();
                var testAgentUpdateAvailabilityTask = _taskProvider.StartNewLongRunningRepeating(
                        cancellationTokenSourceLastAvailable,
                        () =>
                        {
                            UpdateTestAgentLastAvailable(newTestAgentRun.TestAgentRunId);
                        },
                        15000);

                var executeTestAgentRunTask = _taskProvider.StartNewLongRunning(
                       (c) =>
                       {
                           ExecuteTestAgentRunAsync(newTestAgentRun, testAgentRunTimeout, cancellationTokenSource).Wait();
                       },
                       cancellationTokenSource);

                var checkTestRunnerLastAvailableTask = _taskProvider.StartNewLongRunningRepeating(
                       cancellationTokenSource,
                       () =>
                       {
                           if (executeTestAgentRunTask.IsCompleted)
                           {
                               cancellationTokenSource.Cancel();
                               return;
                           }

                           if (executeTestAgentRunTask.IsFaulted)
                           {
                               cancellationTokenSource.Cancel();
                               return;
                           }

                           CheckTestRunnerStatus(newTestAgentRun.TestAgentRunId, cancellationTokenSource);
                       },
                       15000);

                checkTestRunnerLastAvailableTask.Wait();
                cancellationTokenSourceLastAvailable.Cancel();
                testAgentUpdateAvailabilityTask.Wait();
                try
                {
                    // DEBUG: Turn-off if debugging
                    _consoleProvider.Clear();

                    if (_wasTestAgentRunCompleted)
                    {
                        await _testRunLogService.CreateTestRunLogAsync($"Test agent with tag {testAgentTag} finished tests execution on machine {_environmentService.MachineName}.", newTestAgentRun.TestRunId).ConfigureAwait(false);
                        await _testRunLogService.CreateTestRunLogAsync($"Test agent with tag {testAgentTag} starts waiting for new jobs on machine {_environmentService.MachineName}.", newTestAgentRun.TestRunId).ConfigureAwait(false);
                    }
                    else
                    {
                        SendTestAgentRunExceptionToRunner(newTestAgentRun, executeTestAgentRunTask);

                        // TODO: Move logic to be executed on Test Agent Run Abort- extension.
                        await _testRunLogService
                            .CreateTestRunLogAsync(
                                $"Test agent with tag {testAgentTag} starts waiting for new jobs on machine {_environmentService.MachineName}.",
                                newTestAgentRun.TestRunId).ConfigureAwait(false);
                        _consoleProvider.WriteLine($"Test agent run aborted.");
                        _consoleProvider.WriteLine($"Test agent with tag {testAgentTag} starts waiting for new jobs on machine {_environmentService.MachineName}.");
                        var cts = new CancellationTokenSource();
                        var waitForTestRunToCompleteTask = _taskProvider.StartNewLongRunningRepeating(
                                cts,
                                () =>
                                {
                                    if (IsTestRunCompleted(newTestAgentRun.TestRunId).Result)
                                    {
                                        cts.Cancel();
                                    }
                                },
                                5000);
                        waitForTestRunToCompleteTask.Wait();
                    }
                }
                finally
                {
                    await _testAgentStateSwitcher.SetTestAgentAsActiveAsync(testAgentTag).ConfigureAwait(false);
                }
            }
        }
    }

    public async Task WaitForTestAgentRunsToFinishAsync(List<TestAgentRunDto> testAgentRuns, double testRunTimeout, int frequency)
    {
        var timeout = TimeSpan.FromMinutes(testRunTimeout);
        var stopwatch = new Stopwatch();
        try
        {
            stopwatch.Start();
            var notFinishedTestAgentRunIds = testAgentRuns.Select(x => x.TestAgentRunId).ToList();
            var loggerCancellationToken = new CancellationTokenSource();
            var loggingTask = _testAgentsLoggerService.LogTestAgentsRunsResults(loggerCancellationToken, testAgentRuns.First().TestRunId);
            var testRunId = testAgentRuns.First().TestRunId;
            var cancellationTokenSourceLastAvailable = new CancellationTokenSource();
            var updateTestRunnerLastAvailableTask = _taskProvider.StartNewLongRunningRepeating(
                    cancellationTokenSourceLastAvailable,
                    () =>
                    {
                        UpdateTestRunnerLastAvailable(testRunId).Wait();
                    },
                    15000);
            await _testRunRepository.GetAsync(testRunId).ConfigureAwait(false);
            do
            {
                if (loggingTask.IsFaulted)
                {
                    loggingTask = _testAgentsLoggerService.LogTestAgentsRunsResults(loggerCancellationToken, testAgentRuns.First().TestRunId);
                }

                var finishedTestAgentRunsToBeRemoved = new List<int>();

                foreach (var testAgentRunId in notFinishedTestAgentRunIds)
                {
                    var testAgentRun = await _testAgentRunRepository.GetAsync(testAgentRunId).ConfigureAwait(false);

                    var testAgentRunAvailability = await _testAgentRunAvailabilityServiceClient.GetLastTestAgentRunAvailabilityForTestRun(testAgentRunId).ConfigureAwait(false);

                    if (testAgentRun == null || testAgentRun.Status == TestAgentRunStatus.Completed || testAgentRun.Status == TestAgentRunStatus.Aborted)
                    {
                        finishedTestAgentRunsToBeRemoved.Add(testAgentRunId);
                    }
                    else if (testAgentRunAvailability != null && testAgentRunAvailability.LastAvailable < _dateTimeProvider.GetCurrentTime().AddSeconds(-120))
                    {
                        var testAgent = await _testAgentRepository.GetAsync(testAgentRun.TestAgentId).ConfigureAwait(false);
                        _consoleProvider.WriteLine($"Abort Test Agent Run because test runner lost connection with test agent on machine: {testAgent.MachineName} {testAgentRunAvailability.LastAvailable} {_dateTimeProvider.GetCurrentTime().AddSeconds(-120)} current status {testAgentRun.Status}");
                        await AbortAllTestAgentRunsInTestRunAsync(testRunId).ConfigureAwait(false);
                        loggerCancellationToken.Cancel();
                        cancellationTokenSourceLastAvailable.Cancel();
                        loggingTask.Wait();
                        updateTestRunnerLastAvailableTask.Wait();
                        return;
                    }
                }

                foreach (var finishedTestAgentRunToBeRemoved in finishedTestAgentRunsToBeRemoved)
                {
                    notFinishedTestAgentRunIds.Remove(finishedTestAgentRunToBeRemoved);
                }

                if (notFinishedTestAgentRunIds.Count == 0)
                {
                    cancellationTokenSourceLastAvailable.Cancel();
                    loggerCancellationToken.Cancel();
                    loggingTask.Wait();
                    updateTestRunnerLastAvailableTask.Wait();
                    return;
                }

                Thread.Sleep(frequency);

                if (stopwatch.Elapsed.Ticks > timeout.Ticks)
                {
                    cancellationTokenSourceLastAvailable.Cancel();
                    loggerCancellationToken.Cancel();
                    loggingTask.Wait();
                    updateTestRunnerLastAvailableTask.Wait();
                    throw new TimeoutException("Test run timeout!");
                }
            }
            while (true);
        }
        catch (Exception ex)
        {
            await _logger.LogErrorAsync(ex.Message, ex).ConfigureAwait(false);
            throw;
        }
    }

    private async Task UpdateTestRunnerLastAvailable(Guid testRunId)
    {
        var testRunAvailability = new TestRunAvailabilityDto
        {
            TestRunId = testRunId,
            LastAvailable = _dateTimeProvider.GetCurrentTime(),
        };

        await _testRunAvailabilityServiceClient.CreateAsync(testRunAvailability).ConfigureAwait(false);
    }

    public async Task AbortAllTestAgentRunsInProgressForCurrentTestAgentAsync(string agentTag)
    {
        var testAgentRuns = await GetInProgressTestAgentRunsForCurrentTestAgentAsync(agentTag).ConfigureAwait(false);
        foreach (var testAgentRun in testAgentRuns)
        {
            await AbortTestAgentRunAsync(testAgentRun).ConfigureAwait(false);
        }
    }

    public async Task AbortAllTestAgentRunsInTestRunAsync(Guid testRunId)
    {
        var inProgressTestAgentRuns = await GetInProgressTestAgentRunsForTestRunAsync(testRunId).ConfigureAwait(false);
        foreach (var currentTestAgentRun in inProgressTestAgentRuns)
        {
            await AbortTestAgentRunAsync(currentTestAgentRun).ConfigureAwait(false);
        }
    }

    public async Task<bool> AreThereAbortedTestAgentRunsAsync(Guid testRunId)
    {
        var areThereAbortedRuns = (await _testAgentRunRepository.GetAllAsync().ConfigureAwait(false)).Where(x => x.TestRunId == testRunId && x.Status == TestAgentRunStatus.Aborted);
        foreach (var abortedRuns in areThereAbortedRuns)
        {
            var testAgent = await _testAgentRepository.GetAsync(abortedRuns.TestAgentId).ConfigureAwait(false);
            _consoleProvider.WriteLine($"Test Agent Run Aborted on machine: {testAgent.MachineName}");
        }

        return areThereAbortedRuns.Any();
    }

    private void SendTestAgentRunExceptionToRunner(TestAgentRunDto newTestAgentRun, Task executeTestAgentRunTask)
    {
        if (executeTestAgentRunTask.IsFaulted)
        {
            if (executeTestAgentRunTask.Exception != null)
            {
                foreach (var ex in executeTestAgentRunTask.Exception.InnerExceptions)
                {
                    _logger.LogErrorAsync(ex.GetType().Name, ex).Wait();
                    _testRunLogService.CreateTestRunLogAsync(ex.ToString(), newTestAgentRun.TestRunId);
                }
            }
        }
    }

    private void CheckTestRunnerStatus(int testAgentRunId, CancellationTokenSource cancellationTokenSource)
    {
        var testAgentRun = _testAgentRunRepository.GetAsync(testAgentRunId).Result;
        if (testAgentRun == null)
        {
            _consoleProvider.WriteLine($"CheckTestRunnerStatus testAgentRun == null {_dateTimeProvider.GetCurrentTime()}");
            cancellationTokenSource.Cancel();
            return;
        }

        var testRun = _testRunRepository.GetAsync(testAgentRun.TestRunId).Result;
        if (testRun == null)
        {
            _consoleProvider.WriteLine($"CheckTestRunnerStatus testRun == null {_dateTimeProvider.GetCurrentTime()}");
            cancellationTokenSource.Cancel();
            return;
        }

        var testRunAvailability = _testRunAvailabilityServiceClient.GetLastTestRunAvailabilityForTestRun(testRun.TestRunId).Result;
        if (testRunAvailability != null)
        {
            if (testRunAvailability.LastAvailable < _dateTimeProvider.GetCurrentTime().AddSeconds(-120) || testRun.Status == TestRunStatus.Aborted)
            {
                if (testRun.Status != TestRunStatus.Aborted)
                {
                    testRun.Status = TestRunStatus.Aborted;
                    _testRunRepository.UpdateAsync(testRun.TestRunId, testRun).Wait();
                    _testRunOutputServiceClient.DeleteTestRunOutputByTestRunIdAsync(testRun.TestRunId).Wait();
                }

                _testRunLogService.CreateTestRunLogAsync($"Abort Test Agent Run because test runner didn't updated its availability status in the last 120 seconds. {_environmentService.MachineName} {testRunAvailability.LastAvailable} {_dateTimeProvider.GetCurrentTime().AddSeconds(-120)} {testRun.Status}", testAgentRun.TestRunId).Wait();
                cancellationTokenSource.Cancel();
            }
        }
    }

    private void UpdateTestAgentLastAvailable(int testAgentRunId)
    {
        try
        {
            var testAgentRunAvailability = new TestAgentRunAvailabilityDto
            {
                TestAgentRunId = testAgentRunId,
                LastAvailable = _dateTimeProvider.GetCurrentTime(),
            };

            _testAgentRunAvailabilityServiceClient.CreateAsync(testAgentRunAvailability).Wait();
        }
        catch (Exception e)
        {
            // DEBUG:
            _consoleProvider.WriteLine($"THERE WAS AN EXCEPTION DURING UPDATING LAST AVAILABLE {e}");
        }
    }

    private async Task CreateEnvironmentVariablesForCustomArgumentsAsync(Guid testRunId)
    {
        var testRunCustomArguments = (await _testRunCustomArgumentRepository.GetAllAsync().ConfigureAwait(false)).Where(x => x.TestRunId.Equals(testRunId));
        if (testRunCustomArguments.Any())
        {
            foreach (var testRunCustomArgument in testRunCustomArguments)
            {
                try
                {
                    _environmentService.SetEnvironmentVariable(testRunCustomArgument.Key, testRunCustomArgument.Value);
                }
                catch (SecurityException)
                {
                    _consoleProvider.WriteLine("You need to start the test agent in elevated mode otherwise it cannot set system environment variables as custom arguments.");
                    throw;
                }
            }
        }
    }

    private async Task AbortTestAgentRunAsync(TestAgentRunDto testAgentRun)
    {
        testAgentRun.Status = TestAgentRunStatus.Aborted;
        testAgentRun.TestAgentOriginalRunResults = string.Empty;
        testAgentRun.TestAgentRetriedRunResults = string.Empty;
        await _testAgentRunRepository.UpdateAsync(testAgentRun.TestAgentRunId, testAgentRun).ConfigureAwait(false);
    }

    private async Task<List<TestAgentRunDto>> GetInProgressTestAgentRunsForCurrentTestAgentAsync(string agentTag)
    {
        var currentTestAgentId = await GetTestAgentIdForCurrentMachineAsync(agentTag).ConfigureAwait(false);
        var testAgentRuns = (await _testAgentRunRepository.GetAllAsync().ConfigureAwait(false)).Where(x => x.TestAgentId == currentTestAgentId && x.Status == TestAgentRunStatus.InProgress).ToList();

        return testAgentRuns;
    }

    private async Task<List<TestAgentRunDto>> GetInProgressTestAgentRunsForTestRunAsync(Guid testRunId)
    {
        var testAgentRuns = (await _testAgentRunRepository.GetAllAsync().ConfigureAwait(false)).Where(x => x.TestRunId == testRunId && x.Status == TestAgentRunStatus.InProgress).ToList();

        return testAgentRuns;
    }

    private async Task ExecuteTestAgentRunAsync(TestAgentRunDto testAgentRun, int testAgentRunTimeout, CancellationTokenSource cancellationTokenSource)
    {
        _pluginService.ExecuteAllTestAgentPluginsPreTestRunLogic();

        testAgentRun.Status = TestAgentRunStatus.InProgress;
        await CreateEnvironmentVariablesForCustomArgumentsAsync(testAgentRun.TestRunId).ConfigureAwait(false);
        await _testAgentRunRepository.UpdateAsync(testAgentRun.TestAgentRunId, testAgentRun).ConfigureAwait(false);
        var testRun = await _testRunRepository.GetAsync(testAgentRun.TestRunId).ConfigureAwait(false);
        var tempExecutionFolder = _pathProvider.Combine(_pathProvider.GetTempFolderPath(), _guidService.NewGuid().ToString());
        var tempZipFileName = _pathProvider.GetTempFileName();
        var testRunOutput = await _testRunOutputServiceClient.GetTestRunOutputByTestRunIdAsync(testRun.TestRunId).ConfigureAwait(false);
        if (testRunOutput == null)
        {
            // DEBUG:
            await _testRunLogService.CreateTestRunLogAsync("The test run output cannot be null.", testAgentRun.TestRunId).ConfigureAwait(false);
            throw new ArgumentException("The test run output cannot be null.");
        }

        _fileProvider.WriteAllBytes(tempZipFileName, testRunOutput.TestOutputFilesPackage);
        _fileProvider.ExtractZip(tempZipFileName, tempExecutionFolder);
        var testRunTestsAssemblyPath = _pathProvider.Combine(tempExecutionFolder, testRun.TestAssemblyName);
        if (cancellationTokenSource.IsCancellationRequested)
        {
            return;
        }

        var testsResults = await _nativeTestsRunner.ExecuteTestsAsync(
            testRun.TestTechnology,
            testAgentRun.TestList,
            tempExecutionFolder,
            testAgentRun.TestRunId,
            testRunTestsAssemblyPath,
            testRun.TestAssemblyName,
            testRun.RunInParallel,
            testRun.NativeArguments,
            testAgentRunTimeout,
            testRun.IsTimeBasedBalance,
            testRun.SameMachineByClass,
            cancellationTokenSource).ConfigureAwait(false);
        var retriedTestResults = string.Empty;
        if (testRun.RetriesCount > 0)
        {
            retriedTestResults = await _nativeTestsRunner.ExecuteTestsWithRetryAsync(
                testRun.TestTechnology,
                testsResults,
                testAgentRun.TestList,
                tempExecutionFolder,
                testAgentRun.TestRunId,
                testRunTestsAssemblyPath,
                testRun.TestAssemblyName,
                testRun.RunInParallel,
                testRun.NativeArguments,
                testAgentRunTimeout,
                testRun.RetriesCount,
                testRun.Threshold,
                testRun.IsTimeBasedBalance,
                testRun.SameMachineByClass,
                cancellationTokenSource).ConfigureAwait(false);
        }

        if (cancellationTokenSource.IsCancellationRequested)
        {
            return;
        }

        await CompleteTestAgentRunAsync(testAgentRun.TestAgentRunId, testsResults, retriedTestResults).ConfigureAwait(false);

        _pluginService.ExecuteAllTestAgentPluginsPostTestRunLogic();

        DeleteTempExecutionFolder(tempExecutionFolder);
    }

    private void DeleteTempExecutionFolder(string tempExecutionFolder)
    {
        if (_directoryProvider.DoesDirectoryExists(tempExecutionFolder))
        {
            try
            {
                _directoryProvider.Delete(tempExecutionFolder, true);
            }
            catch (UnauthorizedAccessException)
            {
                _consoleProvider.Write("The temp execution couldn't be deleted. You should start the agent with Administrative permissions.");
            }
        }
    }

    private async Task CompleteTestAgentRunAsync(int testAgentRunId, string testResults, string retriedTestResults)
    {
        var testAgentRun = await _testAgentRunRepository.GetAsync(testAgentRunId).ConfigureAwait(false);
        testAgentRun.Status = TestAgentRunStatus.Completed;
        testAgentRun.TestAgentOriginalRunResults = testResults;
        testAgentRun.TestAgentRetriedRunResults = retriedTestResults;
        await _testAgentRunRepository.UpdateAsync(testAgentRun.TestAgentRunId, testAgentRun).ConfigureAwait(false);
        _consoleProvider.WriteLine($"TEST AGENT RUN COMPLETED");
        _wasTestAgentRunCompleted = true;
    }

    private async Task<int> GetTestAgentIdForCurrentMachineAsync(string agentTag)
    {
        var currentTestAgentTag = agentTag;
        var currentTestAgent = (await _testAgentRepository.GetAllAsync().ConfigureAwait(false)).SingleOrDefault(x => x.MachineName == Environment.MachineName && x.AgentTag == currentTestAgentTag);

        if (currentTestAgent != null)
        {
            return currentTestAgent.TestAgentId;
        }
        else
        {
            return 0;
        }
    }

    private async Task<TestAgentRunDto> GetFirstNewTestAgentRunForCurrentTestAgentAsync()
    {
        var newTestAgentRuns = (await _testAgentRunRepository.GetAllAsync().ConfigureAwait(false)).OrderBy(x => x.TestAgentRunId).FirstOrDefault(x => x.TestAgentId == _currentTestAgentId && x.Status == TestAgentRunStatus.New);

        return newTestAgentRuns;
    }

    private async Task<bool> IsEligibleToStartTestAgentRunAsync(string agentTag)
    {
        if (_currentTestAgentId == null)
        {
            _currentTestAgentId = await GetTestAgentIdForCurrentMachineAsync(agentTag).ConfigureAwait(false);
        }

        var testAgentRunsForCurrentAgent = (await _testAgentRunRepository.GetAllAsync().ConfigureAwait(false)).Where(x => x.TestAgentId == _currentTestAgentId);
        var result = !testAgentRunsForCurrentAgent.Any(x => x.Status == TestAgentRunStatus.InProgress) && testAgentRunsForCurrentAgent.Any(x => x.Status == TestAgentRunStatus.New);

        return result;
    }

    private async Task<bool> IsTestRunCompleted(Guid testRunId)
    {
        var testRun = await _testRunRepository.GetAsync(testRunId).ConfigureAwait(false);

        if (testRun == null)
        {
            return true;
        }

        if (testRun.Status.Equals(TestRunStatus.InProgress) || testRun.Status.Equals(TestRunStatus.Aborted))
        {
            return false;
        }

        return true;
    }
}