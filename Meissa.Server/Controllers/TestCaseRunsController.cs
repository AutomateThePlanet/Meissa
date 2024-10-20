﻿// <copyright file="TestCaseRunController.cs" company="Automate The Planet Ltd.">
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
using System.Linq;
using System.Threading.Tasks;
using Meissa.Core.Model;
using Meissa.Model;
using Meissa.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Meissa.Server.Controllers;

[Route("api/testcaseruns")]
public class TestCaseRunsController : Controller
{
    private readonly ILogger<TestCaseRunsController> _logger;
    private readonly MeissaRepository _meissaRepository;

    public TestCaseRunsController(ILogger<TestCaseRunsController> logger, MeissaRepository repository)
    {
        _logger = logger;
        _meissaRepository = repository;
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteOlderTestCasesHistoryAsync()
    {
        try
        {
            // Get all test cases history where are not updated in the last 30 days.
            var testCasesHistory = _meissaRepository.GetAllQuery<TestCaseHistory>();
            foreach (var currentTestCaseHistory in testCasesHistory)
            {
                var allHistoryEntries = _meissaRepository.GetAllQuery<TestCaseHistoryEntry>();
                if (allHistoryEntries.Count(x => x.TestCaseHistoryId.Equals(currentTestCaseHistory.TestCaseHistoryId)) > 3)
                {
                    var filteredEntries = allHistoryEntries.Where(x => x.TestCaseHistoryId.Equals(currentTestCaseHistory.TestCaseHistoryId)).OrderByDescending(j => j.TestCaseHistoryEntryId).Skip(3).ToList();
                    _meissaRepository.DeleteRange(filteredEntries);
                }
            }

            var outdatedTestCasesHistory = _meissaRepository.GetAllQuery<TestCaseHistory>().Where(x => x.LastUpdatedTime < DateTime.Now.AddDays(-30));
            _meissaRepository.DeleteRange(outdatedTestCasesHistory);
            await _meissaRepository.SaveAsync().ConfigureAwait(false);
        }
        catch (DbUpdateConcurrencyException ex)
        {
            _logger.LogError(ex.Message, ex);
        }

        return NoContent();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTestCaseExecutionHistoryAsync([FromBody] List<TestCaseRun> testCaseRuns)
    {
        try
        {
            var existingTestCasesHistory = _meissaRepository.GetAllQuery<TestCaseHistory>().AsEnumerable().Where(x => testCaseRuns.Any(y => y.FullName.Equals(x.FullName))).ToList();
            var testCaseHistoryEntries = _meissaRepository.GetAllQuery<TestCaseHistoryEntry>();
            foreach (var testCaseRun in testCaseRuns)
            {
                if (existingTestCasesHistory.Any(x => x.FullName.Equals(testCaseRun.FullName)))
                {
                    var existingTestCaseHistory = existingTestCasesHistory.FirstOrDefault(x => x.FullName.Equals(testCaseRun.FullName));

                    // Creates the new test case history entry for the current run.
                    if (existingTestCaseHistory != null)
                    {
                        var testCaseHistoryEntry = new TestCaseHistoryEntry
                        {
                            AvgDuration = testCaseRun.Duration,
                            TestCaseHistoryId = existingTestCaseHistory.TestCaseHistoryId,
                        };
                        _meissaRepository.Insert(testCaseHistoryEntry);

                        // Get all previous runs for the test and add to the list the new entry.
                        var allCurrentTestCaseHistoryEntries = testCaseHistoryEntries.Where(x => x.TestCaseHistoryId.Equals(existingTestCaseHistory.TestCaseHistoryId)).ToList();
                        allCurrentTestCaseHistoryEntries.Add(testCaseHistoryEntry);
                    }

                    // Calculate the new average duration for the current tests based on the new entry.
                    double newAverageDurationTicks = testCaseHistoryEntries.Average(x => x.AvgDuration.Ticks);
                    var newAverageDuration = new TimeSpan(Convert.ToInt64(newAverageDurationTicks));

                    // Update the test case history info.
                    if (existingTestCaseHistory != null)
                    {
                        existingTestCaseHistory.AvgDuration = newAverageDuration;
                        existingTestCaseHistory.LastUpdatedTime = DateTime.Now;

                        _meissaRepository.Update(existingTestCaseHistory);
                    }
                }
                else
                {
                    // If no entries exist, we create the history test case and a new history entry.
                    var testCaseHistoryDto = new TestCaseHistory()
                    {
                        FullName = testCaseRun.FullName,
                        LastUpdatedTime = DateTime.Now,
                        AvgDuration = testCaseRun.Duration,
                    };
                    testCaseHistoryDto = await _meissaRepository.InsertWithSaveAsync(testCaseHistoryDto).ConfigureAwait(false);

                    var testCaseHistoryEntry = new TestCaseHistoryEntry
                    {
                        AvgDuration = testCaseRun.Duration,
                        TestCaseHistoryId = testCaseHistoryDto.TestCaseHistoryId,
                    };
                    _meissaRepository.Insert(testCaseHistoryEntry);
                }
            }

            await _meissaRepository.SaveAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            _logger.LogCritical($"Exception while updating test cases execution history. {ex.Message} {ex.InnerException?.StackTrace} {ex.InnerException?.Message}", ex);
        }

        return Ok();
    }
}