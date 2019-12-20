// <copyright file="TestRunCustomArgumentController.cs" company="Automate The Planet Ltd.">
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
using System.Threading.Tasks;
using AutoMapper;
using Meissa.API.Models;
using Meissa.API.Services;
using Meissa.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Meissa.API.Controllers
{
    [Route("api/testruncustomarguments")]
    public class TestRunCustomArgumentController : Controller
    {
        private readonly ILogger<TestRunCustomArgument> _logger;
        private readonly MeissaRepository _meissaRepository;

        public TestRunCustomArgumentController(ILogger<TestRunCustomArgument> logger, MeissaRepository repository)
        {
            _logger = logger;
            _meissaRepository = repository;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetTestRunCustomArgument([FromBody] int id)
        {
            try
            {
                var testRunCustomArgument = await _meissaRepository.GetByIdAsync<TestRunCustomArgument>(id);
                if (testRunCustomArgument == null)
                {
                    return NotFound();
                }

                var testRunCustomArgumentDto = Mapper.Map<TestRunCustomArgumentDto>(testRunCustomArgument);

                return Ok(testRunCustomArgumentDto);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting test run with id {id}.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTestRunCustomArguments()
        {
            try
            {
                var testRunCustomArguments = await _meissaRepository.GetAllQueryWithRefreshAsync<TestRunCustomArgument>();
                var testRunCustomArgumentDtos = Mapper.Map<IEnumerable<TestRunCustomArgumentDto>>(testRunCustomArguments);

                return Ok(testRunCustomArgumentDtos);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception while getting logs.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestRunCustomArgumentAsync([FromBody] TestRunCustomArgumentDto testRunCustomArgumentDto)
        {
            if (testRunCustomArgumentDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var testRunCustomArgument = Mapper.Map<TestRunCustomArgument>(testRunCustomArgumentDto);

            var result = await _meissaRepository.InsertWithSaveAsync(testRunCustomArgument);

            var resultDto = Mapper.Map<TestRunCustomArgumentDto>(result);

            return Ok(resultDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestRunCustomArgumentAsync([FromBody] KeyValuePair<int, TestRunCustomArgumentDto> updateObject)
        {
            if (updateObject.Value == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityToBeUpdated = await _meissaRepository.GetByIdAsync<TestRunCustomArgument>(updateObject.Key);
            if (entityToBeUpdated == null)
            {
                return NotFound();
            }

            entityToBeUpdated = Mapper.Map(updateObject.Value, entityToBeUpdated);
            await _meissaRepository.UpdateWithSaveAsync(entityToBeUpdated);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTestRunCustomArgumentAsync([FromBody] int id)
        {
            var entityToBeRemoved = await _meissaRepository.GetByIdAsync<TestRunCustomArgument>(id);
            if (entityToBeRemoved == null)
            {
                return NotFound();
            }

            await _meissaRepository.DeleteWithSaveAsync(entityToBeRemoved);

            return NoContent();
        }
    }
}
