// <copyright file="SheduleAgentsForShutdownByTag_Should.cs" company="Automate The Planet Ltd.">
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
using System.Threading.Tasks;
using AutoFixture;
using Meissa.API.Models;
using Meissa.Core.Contracts;
using Meissa.Core.Model;
using Meissa.Tests.Factories;
using Moq;
using NUnit.Framework;

namespace Meissa.Core.Services.UnitTests.TestAgentsServiceTests
{
    [TestFixture]
    public class ScheduleAgentsForShutdownByTag_Should
    {
        private Mock<IServiceClient<TestAgentDto>> _testAgentRepositoryMock;
        private ITestAgentsService _testAgentsService;
        private Fixture _fixture;
        private string _agentTag;

        [SetUp]
        public void TestInit()
        {
            _testAgentRepositoryMock = new Mock<IServiceClient<TestAgentDto>>();
            _testAgentsService = new TestAgentsService(_testAgentRepositoryMock.Object);
            _fixture = new Fixture();
            _agentTag = _fixture.Create<string>();
        }
    }
}