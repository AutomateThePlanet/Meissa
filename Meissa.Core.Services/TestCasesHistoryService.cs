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
using Meissa.Core.Contracts;
using Meissa.Core.Model;
using Meissa.Model;

namespace Meissa.Core.Services
{
    public class TestCasesHistoryService : ITestCasesHistoryService, IDisposable
    {
        private const string TestCasesHistoryFileName = "testCasesHistory.json";
        private readonly IJsonSerializer _jsonSerializer;
        private readonly IFileProvider _fileProvider;
        private readonly IPathProvider _pathProvider;
        private readonly IDirectoryProvider _directoryProvider;
        private List<TestCaseHistoryDto> _testCaseHistoryCollection;

        public TestCasesHistoryService(IJsonSerializer jsonSerializer, IFileProvider fileProvider, IPathProvider pathProvider, IDirectoryProvider directoryProvider)
        {
            _jsonSerializer = jsonSerializer;
            _fileProvider = fileProvider;
            _pathProvider = pathProvider;
            _directoryProvider = directoryProvider;
            LoadTestCaseHistoryCollection();
        }

        public List<ExecutedTestCase> GetExecutedTestCases(List<TestCase> testCasesToBeExecuted)
        {
            var executedTestCases = new List<ExecutedTestCase>();
            foreach (var testCase in testCasesToBeExecuted)
            {
                if (_testCaseHistoryCollection.Any(x => x.FullName.Equals(testCase.FullName)))
                {
                    var currentHistoryTestCase =
                        _testCaseHistoryCollection.First(x => x.FullName.Equals(testCase.FullName));
                    executedTestCases.Add(new ExecutedTestCase(testCase, currentHistoryTestCase.AvgDuration));
                }
                else
                {
                    executedTestCases.Add(new ExecutedTestCase(testCase));
                }
            }

            return executedTestCases;
        }

        public void DeleteOlderTestCasesHistory()
        {
            _testCaseHistoryCollection.RemoveAll(x => x.LastUpdatedTime < DateTime.Now.AddDays(-30));
        }

        public void UpdateTestCaseExecutionHistory(List<TestCaseRun> testCaseRuns)
        {
            var existingTestCasesHistory = _testCaseHistoryCollection
                .Where(x => testCaseRuns.Any(y => y.FullName.Equals(x.FullName))).ToList();
            foreach (var testCaseRun in testCaseRuns)
            {
                if (existingTestCasesHistory.Any(x => x.FullName.Equals(testCaseRun.FullName)))
                {
                    var existingTestCaseHistory =
                        existingTestCasesHistory.FirstOrDefault(x => x.FullName.Equals(testCaseRun.FullName));

                    // Creates the new test case history entry for the current run.
                    existingTestCaseHistory?.Durations.Add(testCaseRun.Duration);

                    // Calculate the new average duration for the current tests based on the new entry.
                    if (existingTestCaseHistory != null)
                    {
                        var newAverageDurationTicks = existingTestCaseHistory.Durations.Average(x => x.Ticks);
                        var newAverageDuration = new TimeSpan(Convert.ToInt64(newAverageDurationTicks));
                        existingTestCaseHistory.AvgDuration = newAverageDuration;
                        existingTestCaseHistory.LastUpdatedTime = DateTime.Now;
                    }
                }
                else
                {
                    // If no entries exist, we create the history test case and a new history entry.
                    var testCaseHistoryDto = new TestCaseHistoryDto
                    {
                        FullName = testCaseRun.FullName,
                        LastUpdatedTime = DateTime.Now,
                        AvgDuration = testCaseRun.Duration,
                        Durations = new List<TimeSpan> { testCaseRun.Duration },
                    };

                    _testCaseHistoryCollection.Add(testCaseHistoryDto);
                }
            }
        }

        public void Dispose()
        {
            var fileContent = _jsonSerializer.Serialize(_testCaseHistoryCollection);
            _fileProvider.WriteAllText(GetTestCasesHistoryFileNamePath(), fileContent);
            GC.SuppressFinalize(this);
        }

        private void LoadTestCaseHistoryCollection()
        {
            var testCasesHistoryFilePath = GetTestCasesHistoryFileNamePath();
            var testCaseHistoryFileContent = string.Empty;
            if (_fileProvider.Exists(testCasesHistoryFilePath))
            {
                testCaseHistoryFileContent = _fileProvider.ReadAllText(testCasesHistoryFilePath);
            }

            if (!string.IsNullOrEmpty(testCaseHistoryFileContent))
            {
                _testCaseHistoryCollection =
                    _jsonSerializer.Deserialize<List<TestCaseHistoryDto>>(testCaseHistoryFileContent);
            }
            else
            {
                _testCaseHistoryCollection = new List<TestCaseHistoryDto>();
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
