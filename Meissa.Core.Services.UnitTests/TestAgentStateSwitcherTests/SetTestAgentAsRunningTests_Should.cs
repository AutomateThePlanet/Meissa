// <copyright file="SetTestAgentAsRunningTests_Should.cs" company="Automate The Planet Ltd.">
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

namespace Meissa.Core.Services.UnitTests.TestAgentStateSwitcherTests
{
    [TestFixture]
    public class SetTestAgentAsRunningTests_Should
    {
        private Mock<IServiceClient<TestAgentDto>> _testAgentRepositoryMock;
        private ITestAgentStateSwitcher _testAgentStateSwitcher;

        [SetUp]
        public void TestInit()
        {
            _testAgentRepositoryMock = new Mock<IServiceClient<TestAgentDto>>();
            _testAgentStateSwitcher = new TestAgentStateSwitcher(_testAgentRepositoryMock.Object);
        }

        [Test]
        [TestCase(TestAgentStatus.Active)]
        [TestCase(TestAgentStatus.Inactive)]
        public async Task UpdateTestAgentStatusToRunningTests_When_CurrentTestAgentStatusIs(TestAgentStatus status)
        {
            // Arrange
            var testAgents = TestAgentFactory.CreateWithCurrentMachineName(status, 1);
            int testAgentId = testAgents.FirstOrDefault().TestAgentId;
            _testAgentRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(testAgents));

            // Act
            await _testAgentStateSwitcher.SetTestAgentAsRunningTestsAsync(FixtureFactory.Create().Create<string>());

            // Assert
            _testAgentRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<int>(), It.Is<TestAgentDto>(i => i.TestAgentId == testAgentId && i.Status == TestAgentStatus.Inactive)), Times.Never);
            _testAgentRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<TestAgentDto>()), Times.Never);
        }

        [Test]
        public async Task NotUpdateTestAgentStatus_When_TestAgentForCurrentMachineIsInRunningTestsStatus()
        {
            // Arrange
            var testAgents = TestAgentFactory.CreateWithCurrentMachineName(TestAgentStatus.RunningTests, 1);
            int testAgentId = testAgents.FirstOrDefault().TestAgentId;
            _testAgentRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(testAgents));

            // Act
            await _testAgentStateSwitcher.SetTestAgentAsRunningTestsAsync(testAgents.First().AgentTag);

            // Assert
            _testAgentRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<int>(), It.Is<TestAgentDto>(i => i.TestAgentId == testAgentId && i.Status == TestAgentStatus.Inactive)), Times.Never);
        }

        [Test]
        public async Task NotUpdateTestAgentStatus_When_TestAgentForCurrentMachineIsNotExistingInDatabase()
        {
            // Arrange
            var testAgents = TestAgentFactory.CreateWithoutCurrentMachineName(TestAgentStatus.Active);
            _testAgentRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(testAgents));

            // Act
            await _testAgentStateSwitcher.SetTestAgentAsRunningTestsAsync(testAgents.First().AgentTag);

            // Assert
            _testAgentRepositoryMock.Verify(x => x.GetAllAsync(), Times.Once);
            _testAgentRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<TestAgentDto>()), Times.Never);
        }

        [Test]
        public async Task NotUpdateTestAgentStatus_When_TestAgentForCurrentMachineIsNotExistingInDatabaseSecondTime()
        {
            // Arrange
            var testAgents = TestAgentFactory.CreateWithCurrentMachineName(TestAgentStatus.Active, 1);
            _testAgentRepositoryMock.SetupSequence(x => x.GetAllAsync()).Returns(Task.FromResult(testAgents)).Returns(Task.FromResult(TestAgentFactory.CreateEmpty()));

            // Act
            await _testAgentStateSwitcher.SetTestAgentAsRunningTestsAsync(FixtureFactory.Create().Create<string>());

            // Assert
            _testAgentRepositoryMock.Verify(x => x.GetAllAsync(), Times.Once);
            _testAgentRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<TestAgentDto>()), Times.Never);
        }

        [Test]
        public async Task NotUpdateTestAgentStatus_When_NoTestAgentsAreExistingInDatabase()
        {
            // Arrange
            var testAgents = TestAgentFactory.CreateEmpty();
            _testAgentRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(testAgents));

            // Act
            await _testAgentStateSwitcher.SetTestAgentAsRunningTestsAsync(FixtureFactory.Create().Create<string>());

            // Assert
            _testAgentRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<TestAgentDto>()), Times.Never);
            _testAgentRepositoryMock.Verify(x => x.GetAllAsync(), Times.Once);
        }

        [Test]
        [TestCase(TestAgentStatus.Active)]
        [TestCase(TestAgentStatus.Inactive)]
        public async Task UpdateTestAgentStatusToRunningTests_When_TestAgentsForDifferentMachineNamesExist_AndCurrentTestAgentStatusIs(TestAgentStatus status)
        {
            // Arrange
            var testAgentsWithCurrentMachine = TestAgentFactory.CreateWithCurrentMachineName(status, 1);
            var testAgentsWithoutCurrentMachine = TestAgentFactory.CreateWithoutCurrentMachineName(status);
            int testAgentId = testAgentsWithCurrentMachine.FirstOrDefault().TestAgentId;
            var testAgents = testAgentsWithCurrentMachine.Union(testAgentsWithoutCurrentMachine);
            _testAgentRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(testAgents));

            // Act
            await _testAgentStateSwitcher.SetTestAgentAsRunningTestsAsync(FixtureFactory.Create().Create<string>());

            // Assert
            _testAgentRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<TestAgentDto>()), Times.Never);
            _testAgentRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<int>(), It.Is<TestAgentDto>(i => i.TestAgentId == testAgentId && i.Status == TestAgentStatus.Inactive)), Times.Never);
        }

        [Test]
        [TestCase(TestAgentStatus.Active)]
        [TestCase(TestAgentStatus.Inactive)]
        public void ThrowException_When_MoreThanOneTestAgentExistsForCurrentMachineInStatus(TestAgentStatus status)
        {
            // Arrange
            var testAgents = TestAgentFactory.CreateWithCurrentMachineName(status, 2);
            _testAgentRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(testAgents));

            // Act
            var action = new TestDelegate(() => _testAgentStateSwitcher.SetTestAgentAsRunningTestsAsync(testAgents.First().AgentTag));

            // Assert
            Assert.That(action, Throws.Exception.TypeOf<InvalidOperationException>());
        }
    }
}
