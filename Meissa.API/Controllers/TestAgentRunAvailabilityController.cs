// <copyright file="TestAgentRunAvailabilityController.cs" company="Automate The Planet Ltd.">
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
    [Route("api/testAgentRunAvailabilities")]
    public class TestAgentRunAvailabilityController : Controller
    {
        private readonly ILogger<TestAgentRunAvailabilityController> _logger;
        private readonly MeissaRepository _meissaRepository;

        public TestAgentRunAvailabilityController(ILogger<TestAgentRunAvailabilityController> logger, MeissaRepository repository)
        {
            _logger = logger;
            _meissaRepository = repository;
        }

        [HttpGet("testAgentRun")]
        public async Task<IActionResult> GetLastTestAgentRunAvailabilityForTestRun([FromBody] int id)
        {
            try
            {
                var testRunAvailability = (await _meissaRepository.GetAllQueryWithRefreshAsync<TestAgentRunAvailability>()).LastOrDefault(x => x.TestAgentRunId.Equals(id));
                if (testRunAvailability == null)
                {
                    _logger.LogInformation($"Test Agent Run Availability with testAgentRunId {id} wasn't found.");
                    return NotFound();
                }

                var testRunAvailabilityDto = Mapper.Map<TestAgentRunAvailabilityDto>(testRunAvailability);

                return Ok(testRunAvailabilityDto);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting test run availability with id {id}.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetTestAgentRunAvailability([FromBody] int id)
        {
            try
            {
                var testRunAvailability = await _meissaRepository.GetByIdAsync<TestAgentRunAvailability>(id);
                if (testRunAvailability == null)
                {
                    _logger.LogInformation($"Test Agent Run Availability with id {id} wasn't found.");
                    return NotFound();
                }

                var testRunAvailabilityDto = Mapper.Map<TestAgentRunAvailabilityDto>(testRunAvailability);

                return Ok(testRunAvailabilityDto);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting test run availability with id {id}.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTestRunAvailabilities()
        {
            try
            {
                var testAvailabilities = await _meissaRepository.GetAllQueryWithRefreshAsync<TestAgentRunAvailability>();
                var testRunAvailabilityDtos = Mapper.Map<IEnumerable<TestAgentRunAvailabilityDto>>(testAvailabilities);

                return Ok(testRunAvailabilityDtos);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception while getting test run availabilities.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestAgentRunAvailabilityAsync([FromBody] TestAgentRunAvailabilityDto testRunAvailabilityDto)
        {
            if (testRunAvailabilityDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var testRunAvailability = Mapper.Map<TestAgentRunAvailability>(testRunAvailabilityDto);

            var result = await _meissaRepository.InsertWithSaveAsync(testRunAvailability);

            var resultDto = Mapper.Map<TestAgentRunAvailabilityDto>(result);

            return Ok(resultDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestAgentRunAvailabilityAsync([FromBody] KeyValuePair<int, TestAgentRunAvailabilityDto> updateObject)
        {
            if (updateObject.Value == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityToBeUpdated = await _meissaRepository.GetByIdAsync<TestAgentRunAvailability>(updateObject.Key);
            if (entityToBeUpdated == null)
            {
                return NotFound();
            }

            entityToBeUpdated = Mapper.Map(updateObject.Value, entityToBeUpdated);
            await _meissaRepository.UpdateWithSaveAsync(entityToBeUpdated);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTestAgentRunAvailabilityAsync([FromBody] int id)
        {
            var entityToBeRemoved = await _meissaRepository.GetByIdAsync<TestAgentRunAvailability>(id);
            if (entityToBeRemoved == null)
            {
                return NotFound();
            }

            await _meissaRepository.DeleteWithSaveAsync(entityToBeRemoved);

            return NoContent();
        }
    }
}
