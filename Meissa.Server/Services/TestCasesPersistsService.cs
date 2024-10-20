// <copyright file="TestCasesPersistsService.cs" company="Automate The Planet Ltd.">
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
using System.Threading.Tasks;
using AutoMapper;
using Meissa.Core.Contracts;
using Meissa.Model;

namespace Meissa.Server.Services;

public class TestCasesPersistsService
{
    private const string TestCasesHistoryFileName = "testCasesHistory.json";
    private readonly IJsonSerializer _jsonSerializer;
    private readonly IFileProvider _fileProvider;
    private readonly IPathProvider _pathProvider;
    private readonly IDirectoryProvider _directoryProvider;
    private readonly MeissaRepository _meissaRepository;

    public TestCasesPersistsService(
        MeissaRepository meissaRepository,
        IJsonSerializer jsonSerializer,
        IFileProvider fileProvider,
        IPathProvider pathProvider,
        IDirectoryProvider directoryProvider)
    {
        _meissaRepository = meissaRepository;
        _jsonSerializer = jsonSerializer;
        _fileProvider = fileProvider;
        _pathProvider = pathProvider;
        _directoryProvider = directoryProvider;
    }

    public async Task PersistsHistoryToFileAsync()
    {
        try
        {
            var testCaseHistoryCollection = new List<TestCaseHistoryDto>();

            var testCasesHistoryEntries = await _meissaRepository.GetAllQueryWithRefreshAsync<TestCaseHistory>().ConfigureAwait(false);
            var historyEntries = await _meissaRepository.GetAllQueryWithRefreshAsync<TestCaseHistoryEntry>().ConfigureAwait(false);
            testCaseHistoryCollection = Mapper.Map<IEnumerable<TestCaseHistoryDto>>(testCasesHistoryEntries).ToList();

            foreach (var testCaseHistory in testCaseHistoryCollection)
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
        catch (Exception e)
        {
            Debug.WriteLine(e);
        }
    }

    public async Task LoadTestCaseHistoryCollectionAsync()
    {
        try
        {
            var testCaseHistoryDtoCollection = new List<TestCaseHistoryDto>();

            var testCasesHistoryFilePath = GetTestCasesHistoryFileNamePath();
            var testCaseHistoryFileContent = string.Empty;
            if (_fileProvider.Exists(testCasesHistoryFilePath))
            {
                testCaseHistoryFileContent = await _fileProvider.ReadAllTextAsync(testCasesHistoryFilePath).ConfigureAwait(false);
            }

            if (!string.IsNullOrEmpty(testCaseHistoryFileContent))
            {
                testCaseHistoryDtoCollection = _jsonSerializer.Deserialize<List<TestCaseHistoryDto>>(testCaseHistoryFileContent);
            }

            if (testCaseHistoryDtoCollection.Any())
            {
                foreach (var testCaseHistoryDto in testCaseHistoryDtoCollection)
                {
                    var testCaseHistory = Mapper.Map<TestCaseHistory>(testCaseHistoryDto);
                    var createdTestCaseHistory = await _meissaRepository.InsertWithSaveAsync(testCaseHistory).ConfigureAwait(false);

                    if (testCaseHistoryDto.Durations.Any())
                    {
                        foreach (var currentDuration in testCaseHistoryDto.Durations)
                        {
                            var testCaseHistoryEntry = new TestCaseHistoryEntry
                            {
                                TestCaseHistoryId = createdTestCaseHistory.TestCaseHistoryId,
                                AvgDuration = currentDuration,
                            };

                            await _meissaRepository.InsertWithSaveAsync(testCaseHistoryEntry).ConfigureAwait(false);
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Debug.WriteLine(e);
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
