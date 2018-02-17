// <copyright file="DistributeLogger.cs" company="Automate The Planet Ltd.">
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
using System.Threading.Tasks;
using Meissa.API.Models;
using Meissa.Core.Contracts;

namespace Meissa.Infrastructure
{
    public class DistributeLogger : IDistributeLogger
    {
        private readonly IServiceClient<LogDto> _logRepository;

        public DistributeLogger(IServiceClient<LogDto> logRepository) => _logRepository = logRepository;

        public async Task ExecuteWithLoggingAsync(Action action, string exceptionMessage = null, bool shouldRethrowException = true)
        {
            try
            {
                action.Invoke();
            }
            catch (AggregateException aex)
            {
                foreach (var ex in aex.InnerExceptions)
                {
                    await LogErrorAsync(ex.GetType().Name, ex);
                }

                if (shouldRethrowException)
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                if (string.IsNullOrEmpty(exceptionMessage))
                {
                    exceptionMessage = ex.Message;
                }

                await LogErrorAsync(exceptionMessage, ex);
                if (shouldRethrowException)
                {
                    throw;
                }
            }
        }

        public async Task LogErrorAsync(string message, Exception ex)
        {
            var logDto = new LogDto
                         {
                             Message = message,
                             Date = DateTime.Now,
                             Exception = ex?.ToString(),
                         };
            await _logRepository.CreateAsync(logDto);
        }

        public async Task LogInfoAsync(string message)
        {
            var logDto = new LogDto
                         {
                             Message = message,
                             Date = DateTime.Now,
                         };
            await _logRepository.CreateAsync(logDto);
        }
    }
}