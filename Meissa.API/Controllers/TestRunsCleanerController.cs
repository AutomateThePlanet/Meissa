// <copyright file="TestRunsCleanerController.cs" company="Automate The Planet Ltd.">
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
using System.Linq;
using System.Threading.Tasks;
using Meissa.API.Services;
using Meissa.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Meissa.API.Controllers
{
    [Route("api/testrunscleaner")]
    public class TestRunsCleanerController : Controller
    {
        private readonly MeissaRepository _meissaRepository;

        public TestRunsCleanerController(ILogger<TestRunsCleanerController> logger, MeissaRepository repository) => _meissaRepository = repository;

        [HttpDelete("testRun")]
        public async Task<IActionResult> DeleteOldTestRunDataByTestRunIdAsync([FromBody] Guid id)
        {
            try
            {
                var testRun = _meissaRepository.GetAllQuery<TestRun>().FirstOrDefault(r => r.TestRunId.Equals(id));
                if (testRun != null)
                {
                    var testRunOutputs = _meissaRepository.GetAllQuery<TestRunOutput>().Where(x => x.TestRunId.Equals(testRun.TestRunId));
                    _meissaRepository.DeleteRange(testRunOutputs);
                    var testRunCustomArguments = _meissaRepository.GetAllQuery<TestRunCustomArgument>().Where(x => x.TestRunId.Equals(testRun.TestRunId));
                    _meissaRepository.DeleteRange(testRunCustomArguments);
                    var testAgentRuns = _meissaRepository.GetAllQuery<TestAgentRun>().Where(x => x.TestRunId.Equals(testRun.TestRunId));
                    DeleteTestAgentRunAvailabilitiesForTestAgentRuns(testAgentRuns);
                    _meissaRepository.DeleteRange(testAgentRuns);
                    var testRunLogs = _meissaRepository.GetAllQuery<TestRunLog>().Where(x => x.TestRunId.Equals(testRun.TestRunId));
                    _meissaRepository.DeleteRange(testRunLogs);
                    _meissaRepository.GetAllQuery<TestRunAvailability>().Where(x => x.TestRunId.Equals(testRun.TestRunId));
                    _meissaRepository.DeleteRange(testRunLogs);
                    await _meissaRepository.DeleteWithSaveAsync(testRun);
                    await _meissaRepository.SaveAsync();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                // Ignore.
            }

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOldTestRunsDataAsync()
        {
            try
            {
                var testRuns = (await _meissaRepository.GetAllQueryWithRefreshAsync<TestRun>()).Where(r => r.Status != TestRunStatus.InProgress || (r.Status == TestRunStatus.InProgress && r.DateStarted < DateTime.Now.AddDays(1)));
                foreach (var testRun in testRuns)
                {
                    var testRunOutputs = _meissaRepository.GetAllQuery<TestRunOutput>().Where(x => x.TestRunId.Equals(testRun.TestRunId));
                    _meissaRepository.DeleteRange(testRunOutputs);
                    var testRunCustomArguments = _meissaRepository.GetAllQuery<TestRunCustomArgument>().Where(x => x.TestRunId.Equals(testRun.TestRunId));
                    _meissaRepository.DeleteRange(testRunCustomArguments);
                    var testAgentRuns = _meissaRepository.GetAllQuery<TestAgentRun>().Where(x => x.TestRunId.Equals(testRun.TestRunId));
                    DeleteTestAgentRunAvailabilitiesForTestAgentRuns(testAgentRuns);

                    _meissaRepository.DeleteRange(testAgentRuns);
                    var testRunLogs = _meissaRepository.GetAllQuery<TestRunLog>().Where(x => x.TestRunId.Equals(testRun.TestRunId));
                    _meissaRepository.DeleteRange(testRunLogs);

                    _meissaRepository.GetAllQuery<TestRunAvailability>().Where(x => x.TestRunId.Equals(testRun.TestRunId));
                    _meissaRepository.DeleteRange(testRunLogs);
                }

                _meissaRepository.DeleteRange(testRuns);
                await _meissaRepository.SaveAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Ignore.
            }

            return NoContent();
        }

        private void DeleteTestAgentRunAvailabilitiesForTestAgentRuns(IQueryable<TestAgentRun> testAgentRuns)
        {
            foreach (var testAgent in testAgentRuns)
            {
                var testAgentRunAvailabilities = _meissaRepository.GetAllQuery<TestAgentRunAvailability>().Where(x => x.TestAgentRunId.Equals(testAgent.TestAgentId));
                _meissaRepository.DeleteRange(testAgentRunAvailabilities);
            }
        }
    }
}
