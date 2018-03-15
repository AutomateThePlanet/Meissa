// <copyright file="TestRunAvailabilityController.cs" company="Automate The Planet Ltd.">
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
using Meissa.API.Services;
using Meissa.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Meissa.API.Controllers
{
    [Route("api/testRunAvailabilities")]
    public class TestRunAvailabilityController : Controller
    {
        private readonly ILogger<TestRunAvailabilityController> _logger;
        private readonly MeissaRepository _meissaRepository;

        public TestRunAvailabilityController(ILogger<TestRunAvailabilityController> logger, MeissaRepository repository)
        {
            _logger = logger;
            _meissaRepository = repository;
        }

        [HttpGet("testRun")]
        public async Task<IActionResult> GetLastTestRunAvailabilityForTestRun([FromBody] Guid id)
        {
            try
            {
                var testRunAvailability = (await _meissaRepository.GetAllQueryWithRefreshAsync<TestRunAvailability>()).LastOrDefault(x => x.TestRunId.Equals(id));
                if (testRunAvailability == null)
                {
                    _logger.LogInformation($"Test Run Availability with testRunId {id} wasn't found.");
                    return NotFound();
                }

                var testRunAvailabilityDto = Mapper.Map<TestRunAvailabilityDto>(testRunAvailability);

                return Ok(testRunAvailabilityDto);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting test run availability with id {id}.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetTestRunAvailability([FromBody] int id)
        {
            try
            {
                var testRunAvailability = await _meissaRepository.GetByIdAsync<TestRunAvailability>(id);
                if (testRunAvailability == null)
                {
                    _logger.LogInformation($"Test Run Availability with id {id} wasn't found.");
                    return NotFound();
                }

                var testRunAvailabilityDto = Mapper.Map<TestRunAvailabilityDto>(testRunAvailability);

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
                var testAvailabilities = await _meissaRepository.GetAllQueryWithRefreshAsync<TestRunAvailability>();
                var testRunAvailabilityDtos = Mapper.Map<IEnumerable<TestRunAvailabilityDto>>(testAvailabilities);

                return Ok(testRunAvailabilityDtos);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception while getting test run availabilities.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestRunAvailabilityAsync([FromBody] TestRunAvailabilityDto testRunAvailabilityDto)
        {
            if (testRunAvailabilityDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var testRunAvailability = Mapper.Map<TestRunAvailability>(testRunAvailabilityDto);

            var result = await _meissaRepository.InsertWithSaveAsync(testRunAvailability);

            var resultDto = Mapper.Map<TestRunAvailabilityDto>(result);

            return Ok(resultDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestRunAvailabilityAsync([FromBody] KeyValuePair<int, TestRunAvailabilityDto> updateObject)
        {
            if (updateObject.Value == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityToBeUpdated = await _meissaRepository.GetByIdAsync<TestRunAvailability>(updateObject.Key);
            if (entityToBeUpdated == null)
            {
                return NotFound();
            }

            entityToBeUpdated = Mapper.Map(updateObject.Value, entityToBeUpdated);
            await _meissaRepository.UpdateWithSaveAsync(entityToBeUpdated);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTestRunAvailabilityAsync([FromBody] int id)
        {
            var entityToBeRemoved = await _meissaRepository.GetByIdAsync<TestRunAvailability>(id);
            if (entityToBeRemoved == null)
            {
                return NotFound();
            }

            await _meissaRepository.DeleteWithSaveAsync(entityToBeRemoved);

            return NoContent();
        }
    }
}
