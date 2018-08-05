// <copyright file="TestRunLogService.cs" company="Automate The Planet Ltd.">
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
// <site>https://bellatrix.solutions/</site>
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Meissa.API.Models;
using Meissa.Core.Contracts;
using Meissa.Core.Model;

namespace Meissa.Core.Services
{
    public class TestRunLogService : ITestRunLogService
    {
        private readonly IServiceClient<TestRunLogDto> _testRunLogRepository;
        private readonly IConsoleProvider _consoleProvider;

        public TestRunLogService(
            IServiceClient<TestRunLogDto> testRunLogRepository,
            IConsoleProvider consoleProvider)
        {
            _testRunLogRepository = testRunLogRepository;
            _consoleProvider = consoleProvider;
        }

        public async Task CreateTestRunLogAsync(string message, Guid testRunId)
        {
            if (!string.IsNullOrEmpty(message))
            {
                var testRunLog = new TestRunLogDto
                {
                    Message = message,
                    TestRunId = testRunId,
                    Status = TestRunLogStatus.New,
                };
                try
                {
                    await _testRunLogRepository.CreateAsync(testRunLog);
                    _consoleProvider.WriteLine(message);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    _consoleProvider.WriteLine(e.Message);
                }
            }
        }
    }
}
