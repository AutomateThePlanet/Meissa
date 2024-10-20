// <copyright file="TestRunLogController.cs" company="Automate The Planet Ltd.">
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
using AutoMapper;
using Meissa.Model;
using Meissa.Server.Models;
using Meissa.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Meissa.Server.Controllers;

[Route("api/testrunlogs")]
public class TestRunLogController : Controller
{
    private readonly ILogger<TestRunLogController> _logger;
    private readonly MeissaRepository _meissaRepository;

    public TestRunLogController(ILogger<TestRunLogController> logger, MeissaRepository repository)
    {
        _logger = logger;
        _meissaRepository = repository;
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetTestRunLogAsync([FromBody] int id)
    {
        try
        {
            var testRunLog = await _meissaRepository.GetByIdAsync<TestRunLog>(id).ConfigureAwait(false);
            if (testRunLog == null)
            {
                return NotFound();
            }

            var testRunLogDto = Mapper.Map<TestRunLogDto>(testRunLog);

            return Ok(testRunLogDto);
        }
        catch (Exception ex)
        {
            _logger.LogCritical($"Exception while getting test run with id {id}.", ex);
            return StatusCode(500, "A problem happened while handling your request.");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAndDeleteNewTestRunLogsAsync()
    {
        try
        {
            var testRunLogs = (await _meissaRepository.GetAllQueryWithRefreshAsync<TestRunLog>().ConfigureAwait(false)).Where(x => x.Status == TestRunLogStatus.New);
            var testRunLogDtos = Mapper.Map<IEnumerable<TestRunLogDto>>(testRunLogs);
            await _meissaRepository.DeleteRangeWithSaveAsync(testRunLogs).ConfigureAwait(false);

            return Ok(testRunLogDtos);
        }
        catch (Exception ex)
        {
            _logger.LogCritical("Exception while getting testRunLogs.", ex);
            return StatusCode(500, "A problem happened while handling your request.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateTestRunLogAsync([FromBody] TestRunLogDto testRunLogDto)
    {
        if (testRunLogDto == null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var testRunLog = Mapper.Map<TestRunLog>(testRunLogDto);

        var result = await _meissaRepository.InsertWithSaveAsync(testRunLog).ConfigureAwait(false);

        var resultDto = Mapper.Map<TestRunLogDto>(result);

        return Ok(resultDto);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTestRunLogAsync([FromBody] KeyValuePair<int, TestRunLogDto> updateObject)
    {
        if (updateObject.Value == null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var entityToBeUpdated = await _meissaRepository.GetByIdAsync<TestRunLog>(updateObject.Key).ConfigureAwait(false);
        if (entityToBeUpdated == null)
        {
            return NotFound();
        }

        entityToBeUpdated = Mapper.Map(updateObject.Value, entityToBeUpdated);
        await _meissaRepository.UpdateWithSaveAsync(entityToBeUpdated).ConfigureAwait(false);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTestRunLogAsync([FromBody] int id)
    {
        var entityToBeRemoved = await _meissaRepository.GetByIdAsync<TestRunLog>(id).ConfigureAwait(false);
        if (entityToBeRemoved == null)
        {
            return NotFound();
        }

        await _meissaRepository.DeleteWithSaveAsync(entityToBeRemoved).ConfigureAwait(false);

        return NoContent();
    }
}
