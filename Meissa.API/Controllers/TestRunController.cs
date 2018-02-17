// <copyright file="TestRunController.cs" company="Automate The Planet Ltd.">
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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Meissa.API.Models;
using Meissa.API.Services;
using Meissa.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Meissa.API.Controllers
{
    [Route("api/testruns")]
    public class TestRunController : Controller
    {
        private readonly ILogger<TestRunController> _logger;
        private readonly MeissaRepository _meissaRepository;

        public TestRunController(ILogger<TestRunController> logger, MeissaRepository repository)
        {
            _logger = logger;
            _meissaRepository = repository;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetTestRunAsync([FromBody] Guid id)
        {
            try
            {
                var testRun = (await _meissaRepository.GetAllQueryWithRefreshAsync<TestRun>()).FirstOrDefault(x => x.TestRunId.Equals(id));
                if (testRun == null)
                {
                    return NotFound();
                }

                var testRunDto = Mapper.Map<TestRunDto>(testRun);

                return Ok(testRunDto);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting test run with id {id}.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTestRunsAsync()
        {
            try
            {
                var testRuns = await _meissaRepository.GetAllQueryWithRefreshAsync<TestRun>();
                var testRunDto = Mapper.Map<IEnumerable<TestRunDto>>(testRuns);

                return Ok(testRunDto);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception while getting test runs.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestRunAsync([FromBody] TestRunDto testRunDto)
        {
            if (testRunDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var testRun = Mapper.Map<TestRun>(testRunDto);

            var result = await _meissaRepository.InsertWithSaveAsync(testRun);

            var resultDto = Mapper.Map<TestRunDto>(result);

            return Ok(resultDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestRunAsync([FromBody] KeyValuePair<Guid, TestRunDto> updateObject)
        {
            if (updateObject.Value == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityToBeUpdated = (await _meissaRepository.GetAllQueryWithRefreshAsync<TestRun>()).FirstOrDefault(x => x.TestRunId.Equals(updateObject.Key));
            if (entityToBeUpdated == null)
            {
                return NotFound();
            }

            entityToBeUpdated = Mapper.Map(updateObject.Value, entityToBeUpdated);
            await _meissaRepository.UpdateWithSaveAsync(entityToBeUpdated);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTestRun([FromBody] Guid id)
        {
            var entityToBeRemoved = (await _meissaRepository.GetAllQueryWithRefreshAsync<TestRun>()).FirstOrDefault(x => x.TestRunId.Equals(id));
            if (entityToBeRemoved == null)
            {
                return NotFound();
            }

            await _meissaRepository.DeleteWithSaveAsync(entityToBeRemoved);

            return NoContent();
        }
    }
}
