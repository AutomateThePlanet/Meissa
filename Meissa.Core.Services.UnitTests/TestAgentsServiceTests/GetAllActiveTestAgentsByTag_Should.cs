// <copyright file="GetAllActiveTestAgentsByTag_Should.cs" company="Automate The Planet Ltd.">
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
using Meissa.Tests.Factories;
using Moq;
using NUnit.Framework;

namespace Meissa.Core.Services.UnitTests.TestAgentsServiceTests
{
    [TestFixture]
    public class GetAllActiveTestAgentsByTag_Should
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

        [Test]
        public async Task ReturnNoTestAgents_When_NoTestAgentsExists()
        {
            // Arrange
            var testAgents = TestAgentFactory.CreateEmpty();
            _testAgentRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(testAgents));

            // Act
            var actualTestAgents = _testAgentsService.GetAllActiveTestAgentsByTagAsync(_agentTag);

            // Assert
            Assert.That(actualTestAgents, Is.Empty);
        }

        [Test]
        public async Task ReturnNoTestAgents_When_NoTestAgentsExistsForTheProvidedTag()
        {
            // Arrange
            var testAgents = TestAgentFactory.CreateMany();
            _testAgentRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(testAgents));

            // Act
            var actualTestAgents = _testAgentsService.GetAllActiveTestAgentsByTagAsync(_agentTag);

            // Assert
            Assert.That(actualTestAgents, Is.Empty);
        }

        [Test]
        public async Task ThrowArgumentNullException_When_TheProvidedTagIsNull()
        {
            // Arrange
            var testAgents = TestAgentFactory.CreateMany();
            _testAgentRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(testAgents));

            // Act
            var action = new TestDelegate(() => _testAgentsService.GetAllActiveTestAgentsByTagAsync(null));

            // Assert
            Assert.That(action, Throws.Exception.TypeOf<ArgumentNullException>());
        }

        [Test]
        public async Task ReturnCorrectTestAgent_When_OnlyOneTestAgentExistsWithProvidedTag()
        {
            // Arrange
            var testAgent = TestAgentFactory.CreateSingle(_agentTag);
            _testAgentRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(testAgent));

            // Act
            var actualTestAgents = _testAgentsService.GetAllActiveTestAgentsByTagAsync(_agentTag);

            // Assert
            Assert.That(actualTestAgents, Has.Exactly(1).EqualTo(testAgent.First()));
        }

        [Test]
        public async Task ReturnCorrectTestAgent_When_OneTestAgentExistsWithProvidedTag_AndTestAgentsWithDifferentTagsExists()
        {
            // Arrange
            var currentTagTestAgent = TestAgentFactory.CreateSingle(_agentTag);
            var differentTagsTestAgents = TestAgentFactory.CreateMany();
            _testAgentRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(currentTagTestAgent.Union(differentTagsTestAgents)));

            // Act
            var actualTestAgents = _testAgentsService.GetAllActiveTestAgentsByTagAsync(_agentTag);

            // Assert
            Assert.That(actualTestAgents, Has.Exactly(1).EqualTo(currentTagTestAgent.First()));
        }

        [Test]
        public async Task ReturnCorrectTestAgents_When_ManyTestAgentExistsWithProvidedTag()
        {
            // Arrange
            var testAgents = TestAgentFactory.CreateMany(_agentTag, Model.TestAgentStatus.Active);
            _testAgentRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(testAgents));

            // Act
            var actualTestAgents = _testAgentsService.GetAllActiveTestAgentsByTagAsync(_agentTag);

            // Assert
            Assert.That(actualTestAgents, Is.EquivalentTo(testAgents.ToList()));
        }

        [Test]
        public async Task ReturnCorrectTestAgents_When_ManyTestAgentExistsWithProvidedTag_AndTestAgentsWithDifferentTagsExists()
        {
            // Arrange
            var currentTagTestAgents = TestAgentFactory.CreateMany(_agentTag, Model.TestAgentStatus.Active);
            var differentTagsTestAgents = TestAgentFactory.CreateMany(Model.TestAgentStatus.Active);
            _testAgentRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(currentTagTestAgents.Union(differentTagsTestAgents)));

            // Act
            var actualTestAgents = _testAgentsService.GetAllActiveTestAgentsByTagAsync(_agentTag);

            // Assert
            Assert.That(actualTestAgents, Is.EquivalentTo(currentTagTestAgents.ToList()));
        }
    }
}