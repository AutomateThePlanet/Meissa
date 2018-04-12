// <copyright file="Program.cs" company="Automate The Planet Ltd.">
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
// <site>https://automatetheplanet.com/</site>
using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using CommandLine;
using Meissa.API.Client.Clients;
using Meissa.API.Models;
using Meissa.Core.Contracts;
using Meissa.Core.Model.Exceptions;
using Meissa.Core.Model.Settings;
using Meissa.Core.Services;
using Meissa.Infrastructure;
using Meissa.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Unity;
using Unity.Injection;
using TestAgentStatus = Meissa.Model.TestAgentStatus;

namespace Meissa
{
    public class Program
    {
        private const string UnexpectedProblemOccurredMessage = @"Unexpected problem occurred.";
        private const string TestServerSettingsFileName = @"testExecutionServerSettings";
        private static ILogger _logger;
        private static IUnityContainer _container;

        public static void Main(string[] args)
        {
            try
            {
                CultureInfo.CurrentUICulture = new CultureInfo("en-US");
                var ci = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;

                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                Console.Title = "Meissa Distributed Test Runner- Bellatrix Test Automation Framework";
                Console.WindowHeight = 30;
            }
            catch (IOException)
            {
                // Ignore because the process is started not from the console.
            }

            Console.WriteLine();
            Console.WriteLine(" Created by Bellatrix Ltd.");
            Console.WriteLine(" http://bellatrix.solutions");
            _logger = ConfigureLogger();

            try
            {
                // TODO set the correct IP and Port--> option configure server URL
                Parser.Default.ParseArguments<
                        RunnerModeOptions,
                        InitializeServerModeOptions,
                        TestAgentModeOptions,
                        DumpModeOptions,
                        StatusModeOptions,
                        DeleteModeOptions,
                        SetTestServerUrlModeOptions>(args).
                    MapResult(
                        (RunnerModeOptions opts) => ExecuteTestRun(opts),
                        (InitializeServerModeOptions opts) => InitializeServer(),
                        (TestAgentModeOptions opts) => ExecuteTestAgentRun(opts),
                        (DumpModeOptions opts) => CreateDumpByFilePath(opts.DumpPath, opts.TestServerUrl),
                        (StatusModeOptions opts) => PrintAgentsStatus(opts.AgentTag, opts.TestServerUrl),
                        (DeleteModeOptions opts) => DeleteAllDumps(opts.TestServerUrl),
                        (SetTestServerUrlModeOptions opts) => SetTestExecutionServerUrl(opts.TestServerUrl),
                        errs => -1);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                _logger.LogError(UnexpectedProblemOccurredMessage, ex, ex.StackTrace);
                Environment.Exit(-1);
            }
        }

        private static int InitializeServer()
        {
            try
            {
                var processProvider = new ProcessProvider();

                // change path later with the latest version of the API use GetExecutingAssemblyFolder
                // when started with timeout 0, the process will be killed after the console is closed.
                ////processProvider.StartProcessAndWaitToFinish("dotnet", $"{GetExecutingAssemblyFolder()}\\Server", " Meissa.API.dll", 0);
                processProvider.StartProcessAndWaitToFinish($"{GetExecutingAssemblyFolder()}\\Meissa.API.exe", $"{GetExecutingAssemblyFolder()}", string.Empty, 0);
                Console.WriteLine("Meissa server successfully initialized.");
                return 1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError(UnexpectedProblemOccurredMessage, e);
                return -1;
            }
        }

        private static int ExecuteTestAgentRun(TestAgentModeOptions options)
        {
            try
            {
                var serverUri = options.TestServerUrl != null ? new Uri(options.TestServerUrl) : LoadSavedTestExecutionServerUrl();
                if (serverUri == null)
                {
                    Console.WriteLine("You need to specify a test server URL.");
                }

                InitializeAllTypes(serverUri);

                var testAgentStateSwitcher = _container.Resolve<ITestAgentStateSwitcher>();
                var taskProvider = _container.Resolve<ITaskProvider>();
                var testAgentRunProvider = _container.Resolve<ITestAgentRunProvider>();
                var testAgentsService = _container.Resolve<ITestAgentsService>();
                testAgentStateSwitcher.SetTestAgentAsActiveAsync(options.TestAgentTag).Wait();

                var cancellationTokenSource = new CancellationTokenSource();
                if (options.Restarted)
                {
                    Console.WriteLine("Restarted  Successfully!");
                }

                Console.WriteLine("Test agent successfully initialized and starts listening for new jobs.");
                try
                {
                    var testsRunTask = taskProvider.StartNewLongRunningRepeating(
                            cancellationTokenSource,
                            () =>
                            {
                                testAgentRunProvider.RunTestsForCurrentAgentAsync(options.TestAgentTag, options.TestAgentRunTimeout).Wait();
                            },
                            10000);

                    var veryfyStatusTask = taskProvider.StartNewLongRunningRepeating(
                            cancellationTokenSource,
                            () => testAgentsService.VerifyActiveStatusAsync(options.TestAgentTag).Wait(),
                            15000);

                    Task.WaitAll(testsRunTask, veryfyStatusTask);

                    cancellationTokenSource.Cancel();
                    testAgentStateSwitcher.SetTestAgentAsInactiveAsync(options.TestAgentTag).Wait();
                }
                catch (Exception ex) when (ex.InnerException.InnerException.Message.Contains("A connection with the server could not be established"))
                {
                    Console.WriteLine($"A connection with the server {options.TestServerUrl} could not be established.");
                    return -1;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    _logger.LogError(UnexpectedProblemOccurredMessage, e);
                    cancellationTokenSource.Cancel();
                    testAgentStateSwitcher.SetTestAgentAsInactiveAsync(options.TestAgentTag).Wait();
                    return -1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return -1;
            }

            return 1;
        }

        private static int ExecuteTestRun(RunnerModeOptions runnerModeOptions)
        {
            var serverUri = runnerModeOptions.TestServerUrl != null ? new Uri(runnerModeOptions.TestServerUrl) : LoadSavedTestExecutionServerUrl();
            if (serverUri == null)
            {
                Console.WriteLine("You need to specify a test server URL.");
                return 0;
            }

            DateTime startTime = DateTime.Now;
            Console.WriteLine("Test Execution started....");

            var testRunSettings = new TestRunSettings
            {
                ResultsFilePath = runnerModeOptions.ResultsFilePath,
                OutputFilesLocation = runnerModeOptions.OutputFilesLocation,
                TestsFilter = runnerModeOptions.TestsFilter,
                TestLibraryPath = runnerModeOptions.TestLibraryPath,
                AgentTag = runnerModeOptions.AgentTag,
                RunInParallel = runnerModeOptions.RunInParallel,
                MaxParallelProcessesCount = runnerModeOptions.MaxParallelProcessesCount,
                TimeBasedBalance = runnerModeOptions.TimeBasedBalance,
                NativeArguments = runnerModeOptions.NativeArguments,
                TestRunTimeout = runnerModeOptions.TestRunTimeout,
                RetriesCount = runnerModeOptions.RetriesCount,
                Threshold = runnerModeOptions.Threshold,
                CustomArguments = runnerModeOptions.CustomArguments,
                RetriedResultsFilePath = runnerModeOptions.RetriedResultsFilePath,
                TestTechnology = runnerModeOptions.TestTechnology,
            };

            InitializeAllTypes(serverUri);

            bool wasSuccessfulRun = false;
            try
            {
                var testExecutionService = _container.Resolve<TestExecutionService>();
                wasSuccessfulRun = testExecutionService.ExecuteAsync(testRunSettings).Result;
            }
            catch (TestRunAbortedException ex)
            {
                var exceptionLogger = _container.Resolve<IDistributeLogger>();
                exceptionLogger.LogErrorAsync(ex.Message, ex).Wait();
                Environment.Exit(0);
            }
            catch (Exception ex) when (ex.InnerException.InnerException.Message.Contains("A connection with the server could not be established"))
            {
                Console.WriteLine($"A connection with the server {runnerModeOptions.TestServerUrl} could not be established.");
                Environment.Exit(-1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                var exceptionLogger = _container.Resolve<IDistributeLogger>();
                exceptionLogger.LogErrorAsync(e.Message, e).Wait();
                Environment.Exit(-1);
            }

            DateTime endTime = DateTime.Now;
            TimeSpan completionTime = endTime - startTime;
            Console.WriteLine($"Test Run Completed for {(int)completionTime.TotalMinutes} minutes and {completionTime.Seconds:00} seconds");

            return wasSuccessfulRun ? 1 : 0;
        }

        private static int SetTestExecutionServerUrl(string serverUrl)
        {
            try
            {
                var serverUri = new Uri(serverUrl);
                if (serverUri.Port == 0)
                {
                    // TODO: throw exception if it is not the correct port.
                }

                using (var streamWriter = File.CreateText(TestServerSettingsFileName))
                {
                    streamWriter.WriteLine(serverUri);
                }

                Console.WriteLine($"Test execution server URL successfully set to {serverUri}");

                return 1;
            }
            catch (UriFormatException e)
            {
                Console.WriteLine("The specified URL is not valid.");
                _logger.LogError(UnexpectedProblemOccurredMessage, e);
                return -1;
            }
            catch (Exception ex) when (ex.InnerException.InnerException.Message.Contains("A connection with the server could not be established"))
            {
                Console.WriteLine($"A connection with the server {serverUrl} could not be established.");
                return -1;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                _logger.LogError(UnexpectedProblemOccurredMessage, e);
                return -1;
            }
        }

        private static string LoadSavedSettings()
        {
            string fileContent = string.Empty;
            if (File.Exists(TestServerSettingsFileName))
            {
                fileContent = File.ReadAllText(TestServerSettingsFileName);
            }

            return fileContent;
        }

        private static Uri LoadSavedTestExecutionServerUrl()
        {
            Uri savedUri = null;
            string savedContent = LoadSavedSettings();
            if (!string.IsNullOrEmpty(savedContent))
            {
                savedUri = new Uri(savedContent);
            }

            return savedUri;
        }

        private static int PrintAgentsStatus(string agentTag, string serverUrl = null)
        {
            try
            {
                var serverUri = serverUrl != null ? new Uri(serverUrl) : LoadSavedTestExecutionServerUrl();
                if (serverUri == null)
                {
                    Console.WriteLine("You need to specify a test server URL.");
                }

                InitializeAllTypes(serverUri);

                var testAgentsService = _container.Resolve<ITestAgentsService>();
                var testAgents = testAgentsService.GetAllActiveTestAgentsByTagAsync(agentTag).Result;
                if (testAgents != null && testAgents.Count > 0)
                {
                    Console.WriteLine("Test Agents' Status for tag = '{0}'", agentTag);
                    foreach (var testAgent in testAgents)
                    {
                        Console.WriteLine("MACHINE: {0} STATUS: {1}", testAgent.MachineName, Enum.GetName(typeof(TestAgentStatus), testAgent.Status));
                    }
                }
                else
                {
                    Console.WriteLine("No Registered Agents with tag = '{0}'", agentTag);
                }

                return 1;
            }
            catch (Exception ex) when (ex.InnerException.InnerException.Message.Contains("A connection with the server could not be established"))
            {
                Console.WriteLine($"A connection with the server {serverUrl} could not be established.");
                return -1;
            }
            catch (Exception e)
            {
                _logger.LogError(UnexpectedProblemOccurredMessage, e);
                Console.WriteLine(e);
                return -1;
            }
        }

        private static int CreateDumpByFilePath(string dumpLocation = null, string serverUrl = null)
        {
            try
            {
                var serverUri = serverUrl != null ? new Uri(serverUrl) : LoadSavedTestExecutionServerUrl();
                if (serverUri == null)
                {
                    Console.WriteLine("You need to specify a test server URL.");
                }

                InitializeAllTypes(serverUri);
                var exceptionLogDumpCreator = _container.Resolve<IDistributeLogDumpCreator>();
                exceptionLogDumpCreator.CreateDumpAsync(dumpLocation).Wait();
                return 1;
            }
            catch (Exception ex) when (ex.InnerException.InnerException.Message.Contains("A connection with the server could not be established"))
            {
                Console.WriteLine($"A connection with the server {serverUrl} could not be established.");
                return -1;
            }
            catch (Exception e)
            {
                _logger.LogError(UnexpectedProblemOccurredMessage, e);
                Console.WriteLine(e);
                return -1;
            }
        }

        private static int DeleteAllDumps(string serverUrl = null)
        {
            try
            {
                var serverUri = serverUrl != null ? new Uri(serverUrl) : LoadSavedTestExecutionServerUrl();
                if (serverUri == null)
                {
                    Console.WriteLine("You need to specify a test server URL.");
                }

                InitializeAllTypes(serverUri);
                var exceptionLogDumpCreator = _container.Resolve<IDistributeLogDumpCreator>();
                exceptionLogDumpCreator.DeleteAllDumpsAsync().Wait();
                Console.WriteLine("All dumps successfully deleted.");
                return 1;
            }
            catch (Exception ex) when (ex.InnerException.InnerException.Message.Contains("A connection with the server could not be established"))
            {
                Console.WriteLine($"A connection with the server {serverUrl} could not be established.");
                return -1;
            }
            catch (Exception e)
            {
                _logger.LogError(UnexpectedProblemOccurredMessage, e);
                Console.WriteLine(e);
                return -1;
            }
        }

        public static string GetExecutingAssemblyFolder()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            UriBuilder uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }

        private static ILogger ConfigureLogger()
        {
            var loggingSection = ConfigurationService.Root.GetSection("logging");
            var loggingSettings = ConfigurationService.Root.GetSection("logging")?.Get<LoggingSettings>();
            var resultLogger = default(ILogger);
            if (loggingSettings != null && loggingSettings.IsEnabled)
            {
                ILoggerFactory loggerFactory = new LoggerFactory();

                if (loggingSettings.IsConsoleLoggingEnabled)
                {
                    loggerFactory.AddConsole(loggingSection);
                }

                if (loggingSettings.IsDebugLoggingEnabled)
                {
                    loggerFactory.AddDebug();
                }

                if (loggingSettings.IsFileLoggingEnabled)
                {
                    var fileLoggingSection = ConfigurationService.Root.GetSection("logging:fileLogging");
                    loggerFactory.AddFile(fileLoggingSection);
                }

                resultLogger = loggerFactory.CreateLogger("Bellatrix");
            }

            return resultLogger;
        }

        private static void InitializeAllTypes(Uri testServerUrl)
        {
            _container = new UnityContainer();

            _container.RegisterType<ITestAgentRunAvailabilityServiceClient, TestAgentRunAvailabilityServiceClient>(
             new InjectionConstructor(testServerUrl.Host, testServerUrl.Port));
            _container.RegisterType<ITestRunAvailabilityServiceClient, TestRunAvailabilityServiceClient>(
              new InjectionConstructor(testServerUrl.Host, testServerUrl.Port));
            _container.RegisterType<ITestRunsCleanerServiceClient, TestRunsCleanerServiceClient>(
               new InjectionConstructor(testServerUrl.Host, testServerUrl.Port));
            _container.RegisterType<ITestRunOutputServiceClient, TestRunOutputServiceClient>(
                new InjectionConstructor(testServerUrl.Host, testServerUrl.Port));
            _container.RegisterType<IServiceClient<LogDto>, LogServiceClient>(
                new InjectionConstructor(testServerUrl.Host, testServerUrl.Port));
            _container.RegisterType<IServiceClient<TestAgentDto>, TestAgentServiceClient>(
                new InjectionConstructor(testServerUrl.Host, testServerUrl.Port));
            _container.RegisterType<ITestCaseRunsServiceClient, TestCaseRunsServiceClient>(
                new InjectionConstructor(testServerUrl.Host, testServerUrl.Port));
            _container.RegisterType<IServiceClient<TestRunDto>, TestRunServiceClient>(
                new InjectionConstructor(testServerUrl.Host, testServerUrl.Port));
            _container.RegisterType<IServiceClient<TestRunLogDto>, TestRunLogServiceClient>(
                new InjectionConstructor(testServerUrl.Host, testServerUrl.Port));
            _container.RegisterType<IServiceClient<TestRunCustomArgumentDto>, TestRunCustomArgumentServiceClient>(
                new InjectionConstructor(testServerUrl.Host, testServerUrl.Port));
            _container.RegisterType<IServiceClient<TestCaseHistoryDto>, TestCaseHistoryServiceClient>(
                new InjectionConstructor(testServerUrl.Host, testServerUrl.Port));
            _container.RegisterType<IServiceClient<TestCaseHistoryEntryDto>, TestCaseHistoryEntryServiceClient>(
                new InjectionConstructor(testServerUrl.Host, testServerUrl.Port));
            _container.RegisterType<IServiceClient<TestAgentRunDto>, TestAgentRunServiceClient>(
                new InjectionConstructor(testServerUrl.Host, testServerUrl.Port));
            _container.RegisterType<IReflectionProvider, ReflectionProvider>();
            _container.RegisterType<IDirectoryProvider, DirectoryProvider>();
            _container.RegisterType<IPathProvider, PathProvider>();
            _container.RegisterType<IOutputFilesService, OutputFilesService>();
            _container.RegisterType<IDateTimeProvider, DateTimeProvider>();
            _container.RegisterType<IFileProvider, FileProvider>();
            _container.RegisterType<ITaskProvider, TaskProvider>();
            _container.RegisterType<ITestAgentsLoggerService, TestAgentsLoggerService>();
            _container.RegisterType<IDistributeLogger, DistributeLogger>();
            _container.RegisterType<IProcessKiller, ProcessKiller>();
            _container.RegisterType<IProcessProvider, ProcessProvider>();
            _container.RegisterType<IConsoleProvider, ConsoleProvider>();
            _container.RegisterType<IEnvironmentService, EnvironmentService>();
            _container.RegisterType<IGuidService, GuidService>();
            _container.RegisterType<IXmlSerializer, XmlSerializer>();
            _container.RegisterType<IJsonSerializer, JsonSerializer>();
            _container.RegisterType<IAssemblyProvider, AssemblyProvider>();
            _container.RegisterType<IConsoleArgumentsProvider, ConsoleArgumentsProvider>();
            _container.RegisterInstance(_logger);
            _container.RegisterInstance(_container);

            _container.RegisterType<ITestsRunnerService, TestRunnerService>();
            _container.RegisterType<ITestsRunnerTestResultsService, TestsRunnerTestResultsService>();
            _container.RegisterType<ITestCasesFilterService, TestCasesFilterService>();
            _container.RegisterType<ITestsCountsBasedDistributeService, TestsCountsBasedCountsBasedDistributeService>();
            _container.RegisterType<ITestAgentsService, TestAgentsService>();
            _container.RegisterType<ITestAgentStateSwitcher, TestAgentStateSwitcher>();
            _container.RegisterType<ITestAgentRunProvider, TestAgentRunProvider>();
            _container.RegisterType<ITestRunProvider, TestRunProvider>();
            _container.RegisterType<IDistributeLogDumpCreator, DistributeLogDumpCreator>();
            _container.RegisterType<ITestCasesHistoryService, TestCasesHistoryService>();
            _container.RegisterType<ITestsTimesBasedDistributeService, TestsTimesBasedDistributeService>();
            _container.RegisterType<IPluginService, PluginService>();
            _container.RegisterType<ITestRunLogService, TestRunLogService>();
            _container.RegisterType<TestExecutionService>();
        }
    }
}