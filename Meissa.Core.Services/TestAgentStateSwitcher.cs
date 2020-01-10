// <copyright file="TestAgentStateSwitcher.cs" company="Automate The Planet Ltd.">
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
using System.Linq;
using System.Threading.Tasks;
using Meissa.Core.Contracts;
using Meissa.Core.Model;
using Meissa.Server.Models;

namespace Meissa.Core.Services
{
    public class TestAgentStateSwitcher : ITestAgentStateSwitcher
    {
        private readonly IServiceClient<TestAgentDto> _testAgentRepository;

        public TestAgentStateSwitcher(IServiceClient<TestAgentDto> testAgentRepository) => _testAgentRepository = testAgentRepository;

        public async Task SetTestAgentAsActiveAsync(string testAgentTag)
        {
            var currentMachineName = Environment.MachineName;
            var currentAgentTag = testAgentTag;
            if ((await _testAgentRepository.GetAllAsync().ConfigureAwait(false)).Any(x => x.MachineName == currentMachineName && x.AgentTag == currentAgentTag))
            {
                var testAgent = (await _testAgentRepository.GetAllAsync().ConfigureAwait
                    (false)).SingleOrDefault(x => x.MachineName == currentMachineName && x.AgentTag == currentAgentTag);
                if (testAgent != null && testAgent.Status != TestAgentStatus.Active)
                {
                    testAgent.Status = TestAgentStatus.Active;
                    testAgent.AgentTag = currentAgentTag;
                    await _testAgentRepository.UpdateAsync(testAgent.TestAgentId, testAgent).ConfigureAwait(false);
                }
            }
            else
            {
                var testAgent = new TestAgentDto
                {
                    MachineName = currentMachineName,
                    AgentTag = currentAgentTag,
                    Status = TestAgentStatus.Active,
                };

                await _testAgentRepository.CreateAsync(testAgent).ConfigureAwait(false);
            }
        }

        public async Task SetTestAgentAsInactiveAsync(string testAgentTag)
        {
            var currentMachineName = Environment.MachineName;
            var currentAgentTag = testAgentTag;
            if ((await _testAgentRepository.GetAllAsync().ConfigureAwait(false)).Any(x => x.MachineName == currentMachineName && x.AgentTag == currentAgentTag))
            {
                var testAgent = (await _testAgentRepository.GetAllAsync().ConfigureAwait(false)).SingleOrDefault(x => x.MachineName == currentMachineName && x.AgentTag == currentAgentTag);
                if (testAgent != null && testAgent.Status != TestAgentStatus.Inactive)
                {
                    testAgent.Status = TestAgentStatus.Inactive;
                    await _testAgentRepository.UpdateAsync(testAgent.TestAgentId, testAgent).ConfigureAwait(false);
                }
            }
        }

        public async Task SetTestAgentAsRunningTestsAsync(string testAgentTag)
        {
            var currentMachineName = Environment.MachineName;
            var currentAgentTag = testAgentTag;
            var testAgents = await _testAgentRepository.GetAllAsync().ConfigureAwait(false);
            if (testAgents.Any(x => x.MachineName == currentMachineName && x.AgentTag == currentAgentTag))
            {
                var testAgent = testAgents.SingleOrDefault(x => x.MachineName == currentMachineName && x.AgentTag == currentAgentTag);
                if (testAgent != null && testAgent.Status != TestAgentStatus.RunningTests)
                {
                    testAgent.Status = TestAgentStatus.RunningTests;
                    await _testAgentRepository.UpdateAsync(testAgent.TestAgentId, testAgent).ConfigureAwait(false);
                }
            }
        }
    }
}