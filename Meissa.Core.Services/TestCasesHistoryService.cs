// <copyright file="TestCasesHistoryService.cs" company="Automate The Planet Ltd.">
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
using Meissa.Model;

namespace Meissa.Core.Services
{
    public class TestCasesHistoryService : ITestCasesHistoryService
    {
        private const string TestCasesHistoryFileName = "testCasesHistory.json";
        private readonly IJsonSerializer _jsonSerializer;
        private readonly IFileProvider _fileProvider;
        private readonly IPathProvider _pathProvider;
        private readonly IDirectoryProvider _directoryProvider;
        private readonly IServiceClient<TestCaseHistoryDto> _testCaseHistoryRepository;
        private readonly IServiceClient<TestCaseHistoryEntryDto> _testCaseHistoryEntryRepository;
        private readonly ITestCaseRunsServiceClient _testCaseRunsServiceClient;

        public TestCasesHistoryService(
            IServiceClient<TestCaseHistoryDto> testCaseHistoryRepository,
            IServiceClient<TestCaseHistoryEntryDto> testCaseHistoryEntryRepository,
            ITestCaseRunsServiceClient testCaseRunsServiceClient,
            IJsonSerializer jsonSerializer,
            IFileProvider fileProvider,
            IPathProvider pathProvider,
            IDirectoryProvider directoryProvider)
        {
            _testCaseHistoryRepository = testCaseHistoryRepository;
            _testCaseHistoryEntryRepository = testCaseHistoryEntryRepository;
            _testCaseRunsServiceClient = testCaseRunsServiceClient;
            _jsonSerializer = jsonSerializer;
            _fileProvider = fileProvider;
            _pathProvider = pathProvider;
            _directoryProvider = directoryProvider;
        }

        public async Task<List<ExecutedTestCase>> GetExecutedTestCasesAsync(List<TestCase> testCasesToBeExecuted)
        {
            var executedTestCases = new List<ExecutedTestCase>();
            var testCasesHistory = await _testCaseHistoryRepository.GetAllAsync().ConfigureAwait(false);
            foreach (var testCase in testCasesToBeExecuted)
            {
                if (testCasesHistory.Any(x => x.FullName.Equals(testCase.FullName)))
                {
                    var currentHistoryTestCase = testCasesHistory.FirstOrDefault(x => x.FullName.Equals(testCase.FullName));
                    if (currentHistoryTestCase != null)
                    {
                        executedTestCases.Add(new ExecutedTestCase(testCase, currentHistoryTestCase.AvgDuration));
                    }
                }
                else
                {
                    executedTestCases.Add(new ExecutedTestCase(testCase));
                }
            }

            return executedTestCases;
        }

        public async Task DeleteOlderTestCasesHistoryAsync() => await _testCaseRunsServiceClient.DeleteOlderTestCasesHistoryAsync().ConfigureAwait(false);

        public async Task UpdateTestCaseExecutionHistoryAsync(List<TestCaseRun> testCaseRuns)
        {
            await _testCaseRunsServiceClient.UpdateTestCaseExecutionHistoryAsync(testCaseRuns).ConfigureAwait(false);
        }

        public async Task PersistsHistoryToFileAsync()
        {
            var testCaseHistoryCollection = new List<TestCaseHistoryDto>();

            var testCasesHistoryEntries = await _testCaseHistoryRepository.GetAllAsync().ConfigureAwait(false);
            var historyEntries = await _testCaseHistoryEntryRepository.GetAllAsync().ConfigureAwait(false);
            foreach (var testCaseHistory in testCasesHistoryEntries)
            {
               var currentTestCaseHistoryEntries = historyEntries.Where(x => x.TestCaseHistoryId == testCaseHistory.TestCaseHistoryId);
               foreach (var testCaseHistoryEntry in currentTestCaseHistoryEntries)
               {
                   testCaseHistory.Durations.Add(testCaseHistoryEntry.AvgDuration);
               }
            }

            var fileContent = _jsonSerializer.Serialize(testCaseHistoryCollection);
            await _fileProvider.WriteAllTextAsync(GetTestCasesHistoryFileNamePath(), fileContent).ConfigureAwait(false);
        }

        public async Task LoadTestCaseHistoryCollectionAsync()
        {
            var testCaseHistoryCollection = new List<TestCaseHistoryDto>();

            var testCasesHistoryFilePath = GetTestCasesHistoryFileNamePath();
            var testCaseHistoryFileContent = string.Empty;
            if (_fileProvider.Exists(testCasesHistoryFilePath))
            {
                testCaseHistoryFileContent = await _fileProvider.ReadAllTextAsync(testCasesHistoryFilePath).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(testCaseHistoryFileContent))
            {
                testCaseHistoryCollection = _jsonSerializer.Deserialize<List<TestCaseHistoryDto>>(testCaseHistoryFileContent);
            }

            if (testCaseHistoryCollection.Any())
            {
                foreach (var testCaseHistory in testCaseHistoryCollection)
                {
                    var createdTestCaseHistory = await _testCaseHistoryRepository.CreateAsync(testCaseHistory).ConfigureAwait(false);

                    if (testCaseHistory.Durations.Any())
                    {
                        foreach (var currentDuration in testCaseHistory.Durations)
                        {
                            var testCaseHistoryEntry = new TestCaseHistoryEntryDto
                            {
                                TestCaseHistoryId = createdTestCaseHistory.TestCaseHistoryId,
                                AvgDuration = currentDuration,
                            };

                            await _testCaseHistoryEntryRepository.CreateAsync(testCaseHistoryEntry).ConfigureAwait(false);
                        }
                    }
                }
            }
        }

        private string GetTestCasesHistoryFileNamePath()
        {
            var testCasesHistoryFileNamePath = _pathProvider.Combine(GetAppDataMeissaFolder(), TestCasesHistoryFileName);
            return testCasesHistoryFileNamePath;
        }

        private string GetAppDataMeissaFolder()
        {
            var appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var meissaAppDataFolder = _pathProvider.Combine(appData, "MEISSA");
            _directoryProvider.CreateDirectory(meissaAppDataFolder);
            return meissaAppDataFolder;
        }
    }
}