// <copyright file="TestCaseHistoryEntryController.cs" company="Automate The Planet Ltd.">
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
using Meissa.API.Services;
using Meissa.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Meissa.API.Controllers
{
    [Route("api/testcaseHistoryEntries")]
    public class TestCaseHistoryEntryController : Controller
    {
        private readonly ILogger<TestCaseHistoryEntryController> _logger;
        private readonly MeissaRepository _meissaRepository;

        public TestCaseHistoryEntryController(ILogger<TestCaseHistoryEntryController> logger, MeissaRepository repository)
        {
            _logger = logger;
            _meissaRepository = repository;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetTestCaseHistoryEntry([FromBody] int id)
        {
            try
            {
                var testCaseHistoryEntry = await _meissaRepository.GetByIdAsync<TestCaseHistoryEntry>(id);
                if (testCaseHistoryEntry == null)
                {
                    _logger.LogInformation($"TestCaseHistoryEntry with id {id} wasn't found.");
                    return NotFound();
                }

                var testCaseHistoryEntryDto = Mapper.Map<TestCaseHistoryEntryDto>(testCaseHistoryEntry);

                return Ok(testCaseHistoryEntryDto);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting test run with id {id}.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTestCaseHistoryEntrys()
        {
            try
            {
                var testCaseHistoryEntrys = await _meissaRepository.GetAllQueryWithRefreshAsync<TestCaseHistoryEntry>();
                var testCaseHistoryEntryDtos = Mapper.Map<IEnumerable<TestCaseHistoryEntryDto>>(testCaseHistoryEntrys);

                return Ok(testCaseHistoryEntryDtos);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception while getting test runs.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestCaseHistoryEntryAsync([FromBody] TestCaseHistoryEntryDto testCaseHistoryEntryDto)
        {
            if (testCaseHistoryEntryDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var testCaseHistoryEntry = Mapper.Map<TestCaseHistoryEntry>(testCaseHistoryEntryDto);

            var result = await _meissaRepository.InsertWithSaveAsync(testCaseHistoryEntry);

            var resultDto = Mapper.Map<TestCaseHistoryEntryDto>(result);

            return Ok(resultDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestCaseHistoryEntryAsync([FromBody] KeyValuePair<int, TestCaseHistoryEntryDto> updateObject)
        {
            if (updateObject.Value == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityToBeUpdated = await _meissaRepository.GetByIdAsync<TestCaseHistoryEntry>(updateObject.Key);
            if (entityToBeUpdated == null)
            {
                return NotFound();
            }

            entityToBeUpdated = Mapper.Map(updateObject.Value, entityToBeUpdated);
            await _meissaRepository.UpdateWithSaveAsync(entityToBeUpdated);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteTestCaseHistoryEntryAsync([FromBody] int id)
        {
            var entityToBeRemoved = await _meissaRepository.GetByIdAsync<TestCaseHistoryEntry>(id);
            if (entityToBeRemoved == null)
            {
                return NotFound();
            }

            await _meissaRepository.DeleteWithSaveAsync(entityToBeRemoved);

            return NoContent();
        }
    }
}
