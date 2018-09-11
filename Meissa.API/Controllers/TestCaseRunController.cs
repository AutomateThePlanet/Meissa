// <copyright file="TestCaseRunController.cs" company="Automate The Planet Ltd.">
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
// <site>https://bellatrix.solutions/</site>
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meissa.API.Services;
using Meissa.Core.Model;
using Meissa.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Meissa.API.Controllers
{
    [Route("api/testcaseruns")]
    public class TestCaseRunsController : Controller
    {
        private readonly IBackgroundTaskQueue _backgroundTaskQueue;
        private readonly IServiceProvider _serviceProvider;

        public TestCaseRunsController(IBackgroundTaskQueue backgroundTaskQueue, IServiceProvider serviceProvider)
        {
            _backgroundTaskQueue = backgroundTaskQueue;
            _serviceProvider = serviceProvider;
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOlderTestCasesHistoryAsync()
        {
            _backgroundTaskQueue.QueueBackgroundWorkItem(async token =>
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var meissaRepository = scope.ServiceProvider.GetRequiredService<MeissaRepository>();
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<TestCaseRunsController>>();
                    try
                    {
                        // Get all test cases history where are not updated in the last 30 days.
                        var testCasesHistory = meissaRepository.GetAllQuery<TestCaseHistory>();
                        foreach (var currentTestCaseHistory in testCasesHistory)
                        {
                            var allHistoryEntries = meissaRepository.GetAllQuery<TestCaseHistoryEntry>();
                            if (allHistoryEntries.Count(x => x.TestCaseHistoryId.Equals(currentTestCaseHistory.TestCaseHistoryId)) > 3)
                            {
                                var filteredEntries = allHistoryEntries.Where(x => x.TestCaseHistoryId.Equals(currentTestCaseHistory.TestCaseHistoryId)).OrderByDescending(j => j.TestCaseHistoryEntryId).Skip(3).ToList();
                                meissaRepository.DeleteRange(filteredEntries);
                            }
                        }

                        var outdatedTestCasesHistory = meissaRepository.GetAllQuery<TestCaseHistory>().Where(x => x.LastUpdatedTime < DateTime.Now.AddDays(-30));
                        meissaRepository.DeleteRange(outdatedTestCasesHistory);
                        await meissaRepository.SaveAsync();
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        logger.LogError(ex.Message, ex);
                    }
                }
            });

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestCaseExecutionHistoryAsync([FromBody] List<TestCaseRun> testCaseRuns)
        {
            _backgroundTaskQueue.QueueBackgroundWorkItem(async token =>
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var meissaRepository = scope.ServiceProvider.GetRequiredService<MeissaRepository>();
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<TestCaseRunsController>>();

                    try
                    {
                        var existingTestCasesHistory = meissaRepository.GetAllQuery<TestCaseHistory>().Where(x => testCaseRuns.Any(y => y.FullName.Equals(x.FullName))).ToList();
                        var testCaseHistoryEntries = meissaRepository.GetAllQuery<TestCaseHistoryEntry>();
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
                                    meissaRepository.Insert(testCaseHistoryEntry);

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

                                    meissaRepository.Update(existingTestCaseHistory);
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
                                testCaseHistoryDto = await meissaRepository.InsertWithSaveAsync(testCaseHistoryDto);

                                var testCaseHistoryEntry = new TestCaseHistoryEntry
                                {
                                    AvgDuration = testCaseRun.Duration,
                                    TestCaseHistoryId = testCaseHistoryDto.TestCaseHistoryId,
                                };
                                meissaRepository.Insert(testCaseHistoryEntry);
                            }
                        }

                        await meissaRepository.SaveAsync();
                    }
                    catch (Exception ex)
                    {
                        logger.LogCritical("Exception while updating test cases execution history.", ex);
                    }
                }
            });

            return Ok();
        }
    }
}
