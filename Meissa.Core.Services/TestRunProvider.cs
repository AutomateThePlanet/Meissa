﻿// <copyright file="TestRunProvider.cs" company="Automate The Planet Ltd.">
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
using System.Threading.Tasks;
using Meissa.Core.Contracts;
using Meissa.Core.Model;
using Meissa.Model;
using Meissa.Server.Models;

namespace Meissa.Core.Services;

public class TestRunProvider : ITestRunProvider
{
    private readonly IServiceClient<TestRunDto> _testRunServiceClient;
    private readonly ITestRunOutputServiceClient _testRunOutputServiceClient;
    private readonly IServiceClient<TestRunCustomArgumentDto> _testRunCustomArgumentRepository;
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly IGuidService _guidService;

    public TestRunProvider(IServiceClient<TestRunDto> testRunServiceClient,
        IServiceClient<TestRunCustomArgumentDto> testRunCustomArgumentRepository,
        ITestRunOutputServiceClient testRunOutputServiceClient,
        IDateTimeProvider dateTimeProvider,
        IGuidService guidService)
    {
        _testRunServiceClient = testRunServiceClient;
        _testRunCustomArgumentRepository = testRunCustomArgumentRepository;
        _testRunOutputServiceClient = testRunOutputServiceClient;
        _dateTimeProvider = dateTimeProvider;
        _guidService = guidService;
    }

    public async Task<Guid> CreateNewTestRunAsync(string testAssemblyName, byte[] outputFilesZip, int retriesCount, double threshold, bool runInParallel, int maxParallelProcessesCount, string nativeArguments, string testTechnology, bool isTimeBasedBalance, bool sameMachineByClass, IEnumerable<string> customArgumentsPairs = null)
    {
        if (testAssemblyName == null)
        {
            throw new ArgumentException("testAssemblyName must be provided.");
        }

        var newTestRun = new TestRunDto
        {
            TestRunId = _guidService.NewGuid(),
            DateStarted = _dateTimeProvider.GetCurrentTime(),
            TestAssemblyName = testAssemblyName,
            Status = TestRunStatus.InProgress,
            RetriesCount = retriesCount,
            Threshold = threshold,
            RunInParallel = runInParallel,
            NativeArguments = nativeArguments,
            MaxParallelProcessesCount = maxParallelProcessesCount,
            TestTechnology = testTechnology,
            IsTimeBasedBalance = isTimeBasedBalance,
            SameMachineByClass = sameMachineByClass,
        };
        newTestRun = await _testRunServiceClient.CreateAsync(newTestRun).ConfigureAwait(false);

        var newTestRunOutput = new TestRunOutputDto()
        {
            TestRunId = newTestRun.TestRunId,
            TestOutputFilesPackage = outputFilesZip,
        };
        await _testRunOutputServiceClient.CreateAsync(newTestRunOutput).ConfigureAwait(false);

        if (customArgumentsPairs != null)
        {
            await CreateTestRunCustomArgumentsAsync(newTestRun.TestRunId, customArgumentsPairs).ConfigureAwait(false);
        }

        return newTestRun.TestRunId;
    }

    private async Task CreateTestRunCustomArgumentsAsync(Guid testRunId, IEnumerable<string> customArgumentsPairs)
    {
        // TODO: add a validation that it is correctly formatted?
        foreach (var customArgumentPair in customArgumentsPairs)
        {
            var customArgumentPairString = customArgumentPair.Split('=');
            if (customArgumentPairString.Length == 2)
            {
                var key = customArgumentPairString[0];
                var value = customArgumentPairString[1];
                if (!string.IsNullOrEmpty(key) && !string.IsNullOrEmpty(value))
                {
                    var testRunCustomArgumentDto = new TestRunCustomArgumentDto
                    {
                        Key = key,
                        Value = value,
                        TestRunId = testRunId,
                    };
                    await _testRunCustomArgumentRepository.CreateAsync(testRunCustomArgumentDto).ConfigureAwait(false);
                }
            }
        }
    }

    public async Task CompleteTestRunAsync(Guid testRunId, TestRunStatus testRunStatus)
    {
        if (testRunStatus == TestRunStatus.InProgress)
        {
            throw new ArgumentException("Cannot complete test run with status InProgress!");
        }

        var testRun = await _testRunServiceClient.GetAsync(testRunId).ConfigureAwait(false);
        testRun.Status = testRunStatus;
        testRun.DateFinished = _dateTimeProvider.GetCurrentTime();

        await _testRunServiceClient.UpdateAsync(testRun.TestRunId, testRun).ConfigureAwait(false);
        await _testRunOutputServiceClient.DeleteTestRunOutputByTestRunIdAsync(testRun.TestRunId).ConfigureAwait(false);
    }
}