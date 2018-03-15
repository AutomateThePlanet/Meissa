// <copyright file="LogController.cs" company="Automate The Planet Ltd.">
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
    [Route("api/logs")]
    public class LogController : Controller
    {
        private readonly ILogger<LogController> _logger;
        private readonly MeissaRepository _meissaRepository;

        public LogController(ILogger<LogController> logger, MeissaRepository repository)
        {
            _logger = logger;
            _meissaRepository = repository;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetLog([FromBody] int id)
        {
            try
            {
                var log = await _meissaRepository.GetByIdAsync<Log>(id);
                if (log == null)
                {
                    _logger.LogInformation($"Log with id {id} wasn't found.");
                    return NotFound();
                }

                var logDto = Mapper.Map<LogDto>(log);

                return Ok(logDto);
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting test run with id {id}.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetLogs()
        {
            try
            {
                var logs = await _meissaRepository.GetAllQueryWithRefreshAsync<Log>();
                var logDto = Mapper.Map<IEnumerable<LogDto>>(logs);

                return Ok(logDto);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Exception while getting logs.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateLogAsync([FromBody] LogDto logDto)
        {
            if (logDto == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var log = Mapper.Map<Log>(logDto);

            var result = await _meissaRepository.InsertWithSaveAsync(log);

            var resultDto = Mapper.Map<LogDto>(result);

            return Ok(resultDto);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLogAsync([FromBody] KeyValuePair<int, LogDto> updateObject)
        {
            if (updateObject.Value == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var entityToBeUpdated = await _meissaRepository.GetByIdAsync<Log>(updateObject.Key);
            if (entityToBeUpdated == null)
            {
                return NotFound();
            }

            entityToBeUpdated = Mapper.Map(updateObject.Value, entityToBeUpdated);
            await _meissaRepository.UpdateWithSaveAsync(entityToBeUpdated);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteLogAsync([FromBody] int id)
        {
            var entityToBeRemoved = await _meissaRepository.GetByIdAsync<Log>(id);
            if (entityToBeRemoved == null)
            {
                return NotFound();
            }

            await _meissaRepository.DeleteWithSaveAsync(entityToBeRemoved);

            return NoContent();
        }
    }
}
