// <copyright file="TestAgentController.cs" company="Automate The Planet Ltd.">
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
using System.Threading.Tasks;
using AutoMapper;
using Meissa.API.Models;
using Meissa.API.Services;
using Meissa.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Meissa.API.Controllers
{
    [Route("api/testagents")]
    public class TestAgentController : Controller
    {
        private readonly ILogger<TestAgentController> _logger;
        private readonly MeissaRepository _meissaRepository;

        public TestAgentController(ILogger<TestAgentController> logger, MeissaRepository repository)
        {
            _logger = logger;
            _meissaRepository = repository;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetTestAgent([FromBody] int id)
        {
            try
            {
                var testAgent = await _meissaRepository.GetByIdAsync<TestAgent>(id);
                if (testAgent == null)
                {
                    _logger.LogInformation($"TestAgent with id {id} wasn't found.");
                    return NotFound();
                }

                var testAgentDto = Mapper.Map<TestAgentDto>(testAgent);

                return Ok(testAgentDto);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting test run with id {id}.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTestAgents()
        {
            try
            {
                var testAgents = await _meissaRepository.GetAllQueryWithRefreshAsync<TestAgent>();
                var testAgentDtos = Mapper.Map<IEnumerable<TestAgentDto>>(testAgents);

                return Ok(testAgentDtos);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception while getting test runs.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestAgentAsync([FromBody] TestAgentDto testAgentDto)
        {
            if (testAgentDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var testAgent = Mapper.Map<TestAgent>(testAgentDto);

            var result = await _meissaRepository.InsertWithSaveAsync(testAgent);

            var resultDto = Mapper.Map<TestAgentDto>(result);

            return Ok(resultDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestAgentAsync([FromBody] KeyValuePair<int, TestAgentDto> updateObject)
        {
            if (updateObject.Value == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityToBeUpdated = await _meissaRepository.GetByIdAsync<TestAgent>(updateObject.Key);
            if (entityToBeUpdated == null)
            {
                return NotFound();
            }

            entityToBeUpdated = Mapper.Map(updateObject.Value, entityToBeUpdated);
            await _meissaRepository.UpdateWithSaveAsync(entityToBeUpdated);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTestAgentAsync([FromBody] int id)
        {
            var entityToBeRemoved = await _meissaRepository.GetByIdAsync<TestAgent>(id);
            if (entityToBeRemoved == null)
            {
                return NotFound();
            }

            await _meissaRepository.DeleteWithSaveAsync(entityToBeRemoved);

            return NoContent();
        }
    }
}
