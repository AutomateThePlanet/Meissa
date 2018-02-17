// <copyright file="TestAgentsLoggerService.cs" company="Automate The Planet Ltd.">
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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Meissa.API.Models;
using Meissa.Core.Contracts;
using Meissa.Core.Model;

namespace Meissa.Infrastructure
{
    public class TestAgentsLoggerService : ITestAgentsLoggerService
    {
        private const int ExecutionFrequency = 5000;
        private readonly IServiceClient<TestRunLogDto> _testRunLogRepository;
        private readonly ITaskProvider _taskProvider;
        private readonly IConsoleProvider _consoleProvider;

        public TestAgentsLoggerService(IServiceClient<TestRunLogDto> testRunLogRepository, ITaskProvider taskProvider, IConsoleProvider consoleProvider)
        {
            _testRunLogRepository = testRunLogRepository;
            _taskProvider = taskProvider;
            _consoleProvider = consoleProvider;
        }

        public Task LogTestAgentsRunsResults(CancellationTokenSource cancellationTokenSource, Guid testRunId)
            => _taskProvider.StartNewLongRunningRepeating(cancellationTokenSource, () => LogTestRunMessages(testRunId), ExecutionFrequency);

        public void LogTestRunMessages(Guid testRunId)
        {
            var newLogMessages = _testRunLogRepository.GetAllAsync().Result.Where(x => x.TestRunId.Equals(testRunId) && x.Status == TestRunLogStatus.New).ToList();
            if (newLogMessages.Count > 0)
            {
                foreach (var newLogMessage in newLogMessages)
                {
                    _consoleProvider.WriteLine(newLogMessage.Message);
                }
            }
        }
    }
}