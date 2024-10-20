// <copyright file="TestRunOutputController.cs" company="Automate The Planet Ltd.">
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
using Meissa.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Meissa.Server.Controllers;

[Route("api/testrunoutputs")]
public class TestRunOutputController : Controller
{
    private readonly ILogger<TestRunOutputController> _logger;
    private readonly MeissaRepository _meissaRepository;

    public TestRunOutputController(ILogger<TestRunOutputController> logger, MeissaRepository repository)
    {
        _logger = logger;
        _meissaRepository = repository;
    }

    [HttpGet("testRun")]
    public async Task<IActionResult> GetTestRunOutputByTestRunIdAsync([FromBody] Guid id)
    {
        try
        {
            var testRunOutput = (await _meissaRepository.GetAllQueryWithRefreshAsync<TestRunOutput>().ConfigureAwait(false)).FirstOrDefault(x => x.TestRunId.Equals(id));
            if (testRunOutput == null)
            {
                return NotFound();
            }

            var testRunOutputDto = Mapper.Map<TestRunOutputDto>(testRunOutput);

            return Ok(testRunOutputDto);
        }
        catch (Exception ex)
        {
            _logger.LogCritical($"Exception while getting test run with id {id}.", ex);
            return StatusCode(500, "A problem happened while handling your request.");
        }
    }

    [HttpDelete("testRun")]
    public async Task<IActionResult> DeleteTestRunOutputByTestRunIdAsync([FromBody] Guid id)
    {
        var entityToBeRemoved = (await _meissaRepository.GetAllQueryWithRefreshAsync<TestRunOutput>().ConfigureAwait(false)).FirstOrDefault(x => x.TestRunId.Equals(id));
        if (entityToBeRemoved != null)
        {
            await _meissaRepository.DeleteWithSaveAsync(entityToBeRemoved).ConfigureAwait(false);
        }

        return NoContent();
    }

    [HttpDelete("outputFiles")]
    public async Task<IActionResult> DeleteAllTestRunsTestOutputFilesPackagesAsync()
    {
        var testRuns = (await _meissaRepository.GetAllQueryWithRefreshAsync<TestRun>().ConfigureAwait(false)).Where(r => r.Status != TestRunStatus.InProgress);
        foreach (var testRun in testRuns)
        {
            var testRunOutput = (await _meissaRepository.GetAllQueryWithRefreshAsync<TestRunOutput>().ConfigureAwait(false)).First(x => x.TestRunId.Equals(testRun.TestRunId));
            await _meissaRepository.DeleteWithSaveAsync(testRunOutput).ConfigureAwait(false);
        }

        return NoContent();
    }

    [HttpGet("id")]
    public async Task<IActionResult> GetTestRunOutput([FromBody] Guid id)
    {
        try
        {
            var testRunOutput = (await _meissaRepository.GetAllQueryWithRefreshAsync<TestRunOutput>().ConfigureAwait(false)).First(x => x.TestRunOutputId.Equals(id));
            if (testRunOutput == null)
            {
                _logger.LogInformation($"TestRunOutput with id {id} wasn't found.");
                return NotFound();
            }

            var testRunOutputDto = Mapper.Map<TestRunOutputDto>(testRunOutput);

            return Ok(testRunOutputDto);
        }
        catch (Exception ex)
        {
            _logger.LogCritical($"Exception while getting test run with id {id}.", ex);
            return StatusCode(500, "A problem happened while handling your request.");
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetTestRunOutputs()
    {
        try
        {
            var testRunOutputs = await _meissaRepository.GetAllQueryWithRefreshAsync<TestRunOutput>().ConfigureAwait(false);
            var testRunOutputDtos = Mapper.Map<IEnumerable<TestRunOutputDto>>(testRunOutputs);

            return Ok(testRunOutputDtos);
        }
        catch (Exception ex)
        {
            _logger.LogCritical("Exception while getting test runs.", ex);
            return StatusCode(500, "A problem happened while handling your request.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateTestRunOutputAsync([FromBody] TestRunOutputDto testRunOutputDto)
    {
        if (testRunOutputDto == null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var testRunOutput = Mapper.Map<TestRunOutput>(testRunOutputDto);

        var result = await _meissaRepository.InsertWithSaveAsync(testRunOutput).ConfigureAwait(false);

        var resultDto = Mapper.Map<TestRunOutputDto>(result);

        return Ok(resultDto);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateTestRunOutputAsync([FromBody] KeyValuePair<int, TestRunOutputDto> updateObject)
    {
        if (updateObject.Value == null)
        {
            return BadRequest();
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var entityToBeUpdated = (await _meissaRepository.GetAllQueryWithRefreshAsync<TestRunOutput>().ConfigureAwait(false)).FirstOrDefault(x => x.TestRunOutputId.Equals(updateObject.Key));
        if (entityToBeUpdated == null)
        {
            return NotFound();
        }

        entityToBeUpdated = Mapper.Map(updateObject.Value, entityToBeUpdated);
        await _meissaRepository.UpdateWithSaveAsync(entityToBeUpdated).ConfigureAwait(false);

        return NoContent();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteTestRunOutputAsync([FromBody] Guid id)
    {
        var entityToBeRemoved = (await _meissaRepository.GetAllQueryWithRefreshAsync<TestRunOutput>().ConfigureAwait(false)).FirstOrDefault(x => x.TestRunOutputId.Equals(id));
        if (entityToBeRemoved == null)
        {
            return NotFound();
        }

        await _meissaRepository.DeleteWithSaveAsync(entityToBeRemoved).ConfigureAwait(false);

        return NoContent();
    }
}
