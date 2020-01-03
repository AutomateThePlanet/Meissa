// <copyright file="TestsRunnerTestResultsService.cs" company="Automate The Planet Ltd.">
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
using System.Threading.Tasks;
using Meissa.Core.Contracts;
using Meissa.Core.Model;
using Meissa.Plugins.Contracts;
using Meissa.Server.Models;

namespace Meissa.Infrastructure
{
    public class TestsRunnerTestResultsService : ITestsRunnerTestResultsService
    {
        private readonly IServiceClient<TestAgentRunDto> _testAgentRunRepository;
        private readonly IServiceClient<TestRunDto> _testRunRepository;
        private readonly IFileProvider _fileProvider;
        private readonly IDirectoryProvider _directoryProvider;
        private readonly IPathProvider _pathProvider;
        private readonly IPluginService _pluginService;
        private INativeTestsRunnerPluginService _nativeTestsRunnerPluginService;

        public TestsRunnerTestResultsService(
            IServiceClient<TestAgentRunDto> testAgentRunRepository,
            IServiceClient<TestRunDto> testRunRepository,
            IFileProvider fileProvider,
            IDirectoryProvider directoryProvider,
            IPathProvider pathProvider,
            IPluginService pluginService)
        {
            _testAgentRunRepository = testAgentRunRepository;
            _testRunRepository = testRunRepository;
            _fileProvider = fileProvider;
            _directoryProvider = directoryProvider;
            _pathProvider = pathProvider;
            _pluginService = pluginService;
        }

        public async Task SaveTestResultsForCurrentRunAsync(string testTechnology, string testResultsFilePath, string retriedResultsFilePath, Guid testRunId)
        {
            _nativeTestsRunnerPluginService = _pluginService.GetNativeTestRunnerService(testTechnology);
            var testResultsDir = _pathProvider.GetDirectoryName(testResultsFilePath);
            EnsureResultsDirectoryExists(testResultsDir);
            DeleteAllFilesInResultsDirectory(testResultsDir);
            await WriteTestAgentRunsResultsToFilesInResultsDirectoryAsync(testResultsFilePath, testRunId).ConfigureAwait(false);
            await WriteTestAgentRunsRetriedResultsToFilesInResultsDirectoryAsync(retriedResultsFilePath, testRunId).ConfigureAwait(false);
        }

        public List<TestCase> GetAllPassesTests(string testTechnology, string testResultsFileContent)
        {
            _nativeTestsRunnerPluginService = _pluginService.GetNativeTestRunnerService(testTechnology);
            return _nativeTestsRunnerPluginService.GetAllPassesTestCases(testResultsFileContent);
        }

        public List<TestCase> GetAllNotPassedTests(string testTechnology, string testResultsFileContent)
        {
            _nativeTestsRunnerPluginService = _pluginService.GetNativeTestRunnerService(testTechnology);
            return _nativeTestsRunnerPluginService.GetAllNotPassedTests(testResultsFileContent);
        }

        public double CalculatedFailedTestsPercentage(List<TestCase> failedTests, List<TestCase> allTests)
        {
            double result = 0;
            if (allTests.Count > 0)
            {
                // ReSharper disable All
                result = (double)failedTests.Count / (double)allTests.Count * 100;

                // ReSharper enable All
            }

            return result;
        }

        private async Task WriteTestAgentRunsResultsToFilesInResultsDirectoryAsync(string testResultsFilePath, Guid testRunId)
        {
            var testRun = await _testRunRepository.GetAsync(testRunId).ConfigureAwait(false);
            var testAgentRuns = (await _testAgentRunRepository.GetAllAsync().ConfigureAwait(false)).Where(x => x.TestRunId == testRunId).ToList();
            var msTestTestRuns = _nativeTestsRunnerPluginService.GetTestResultsForTestRun(testAgentRuns);
            var mergedTestRunResults = _nativeTestsRunnerPluginService.MergeTestResults(msTestTestRuns);

            // TODO: validate that this is a valid file path but not here.
            if (!string.IsNullOrEmpty(mergedTestRunResults))
            {
                _fileProvider.WriteAllText(testResultsFilePath, mergedTestRunResults);
            }
            else
            {
                // TODO: create custom exception type.
                throw new Exception("A problem occurred merging the tests results. No test agent run results were present.");
            }
        }

        private async Task WriteTestAgentRunsRetriedResultsToFilesInResultsDirectoryAsync(string testResultsFilePath, Guid testRunId)
        {
            var testRun = await _testRunRepository.GetAsync(testRunId).ConfigureAwait(false);
            var testAgentRuns = (await _testAgentRunRepository.GetAllAsync().ConfigureAwait(false)).Where(x => x.TestRunId == testRunId).ToList();
            var msTestTestRuns = _nativeTestsRunnerPluginService.GetRetriedTestResultsForTestRun(testAgentRuns);
            var mergedTestRunResults = _nativeTestsRunnerPluginService.MergeTestResults(msTestTestRuns);

            // TODO: validate that this is a valid file path but not here.
            if (!string.IsNullOrEmpty(mergedTestRunResults))
            {
                _fileProvider.WriteAllText(testResultsFilePath, mergedTestRunResults);
            }
        }

        private void EnsureResultsDirectoryExists(string testResultsFolder)
        {
            if (!string.IsNullOrEmpty(testResultsFolder) && !_directoryProvider.DoesDirectoryExists(testResultsFolder))
            {
                _directoryProvider.CreateDirectory(testResultsFolder);
            }
        }

        private void DeleteAllFilesInResultsDirectory(string testResultsFolder)
        {
            if (_directoryProvider.Exists(testResultsFolder))
            {
                var files = _directoryProvider.GetFiles(testResultsFolder);
                foreach (var file in files)
                {
                    if (_fileProvider.IsWithExtension(file, "trx"))
                    {
                        _fileProvider.Delete(file);
                    }
                }
            }
        }
    }
}