// <copyright file="LogTestRunMessages_Should.cs" company="Automate The Planet Ltd.">
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
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoFixture;
using Meissa.API.Models;
using Meissa.Core.Contracts;
using Meissa.Core.Model;
using Meissa.Tests.Factories;
using Moq;
using NUnit.Framework;

namespace Meissa.Infrastructure.UnitTests.TestAgentsLoggerServiceTests
{
    [TestFixture]
    public class LogTestRunMessages_Should
    {
        private Mock<IServiceClient<TestRunLogDto>> _testRunLogRepositoryMock;
        private Mock<ITaskProvider> _taskProviderMock;
        private Mock<IConsoleProvider> _consoleProviderMock;

        [SetUp]
        public void TestInit()
        {
            _testRunLogRepositoryMock = new Mock<IServiceClient<TestRunLogDto>>();
            _taskProviderMock = new Mock<ITaskProvider>();
            _consoleProviderMock = new Mock<IConsoleProvider>();
        }

        [Test]
        public async Task TestRunMessagesNotUpdated_When_NoTestRunLogMessagesExist()
        {
            // Arrange
            var fixture = new Fixture();
            var expectedTestRunId = fixture.Create<Guid>();
            var testRunLogs = TestRunLogFactory.CreateEmpty();
            _testRunLogRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(testRunLogs));

            var testAgentsLoggerServicePrivate =
                new TestAgentsLoggerService(_testRunLogRepositoryMock.Object, _taskProviderMock.Object, _consoleProviderMock.Object);

            // Act
            testAgentsLoggerServicePrivate.LogTestRunMessages(expectedTestRunId);

            // Assert
            _consoleProviderMock.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Never());
            _testRunLogRepositoryMock.Verify(x => x.GetAsync(It.IsAny<int>()), Times.Never());
            _testRunLogRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<TestRunLogDto>()), Times.Never());
        }

        [Test]
        public async Task TestRunMessagesNotUpdated_When_NoNewTestRunLogMessagesExist()
        {
            // Arrange
            var fixture = new Fixture();
            var expectedTestRunId = fixture.Create<Guid>();
            var testRunLogs = TestRunLogFactory.CreateMany(expectedTestRunId);
            _testRunLogRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(testRunLogs));
            var testAgentsLoggerServicePrivate =
                    new TestAgentsLoggerService(_testRunLogRepositoryMock.Object, _taskProviderMock.Object, _consoleProviderMock.Object);

            // Act
            testAgentsLoggerServicePrivate.LogTestRunMessages(expectedTestRunId);

            // Assert
            _consoleProviderMock.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Never());
            _testRunLogRepositoryMock.Verify(x => x.GetAsync(It.IsAny<int>()), Times.Never());
            _testRunLogRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<TestRunLogDto>()), Times.Never());
        }

        [Test]
        public async Task OneTestRunMessageUpdated_When_OneTestRunLogMessageExistsInStatusNew()
        {
            // Arrange
            var fixture = new Fixture();
            var expectedTestRunId = fixture.Create<Guid>();
            var actualTestRunLog = default(TestRunLogDto);
            var testRunLogs = TestRunLogFactory.CreateMany(expectedTestRunId, TestRunLogStatus.New, 1);
            Debug.WriteLine(testRunLogs.Count());
            _testRunLogRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(testRunLogs));
            _testRunLogRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<TestRunLogDto>())).Callback((TestRunLogDto testRunLog) => actualTestRunLog = testRunLog);
            var testAgentsLoggerServicePrivate =
                    new TestAgentsLoggerService(_testRunLogRepositoryMock.Object, _taskProviderMock.Object, _consoleProviderMock.Object);

            // Act
            testAgentsLoggerServicePrivate.LogTestRunMessages(expectedTestRunId);

            // Assert
            _consoleProviderMock.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Once());
            _testRunLogRepositoryMock.Verify(x => x.GetAsync(It.IsAny<int>()), Times.Once());
            Assert.That(actualTestRunLog.Status, Is.EqualTo(TestRunLogStatus.Published));
        }

        [Test]
        public async Task TwoTestRunMessagesUpdated_When_TwoTestRunLogMessagesExistInStatusNew()
        {
            // Arrange
            var fixture = new Fixture();
            var expectedTestRunId = fixture.Create<Guid>();
            List<TestRunLogDto> actualTestRunLogs = new List<TestRunLogDto>();
            var testRunLogs = TestRunLogFactory.CreateMany(expectedTestRunId, TestRunLogStatus.New, 2);
            Debug.WriteLine(testRunLogs.Count());
            _testRunLogRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(testRunLogs));
            _testRunLogRepositoryMock.Setup(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<TestRunLogDto>())).Callback((TestRunLogDto testRunLog) => actualTestRunLogs.Add(testRunLog));
            var testAgentsLoggerServicePrivate =
                    new TestAgentsLoggerService(_testRunLogRepositoryMock.Object, _taskProviderMock.Object, _consoleProviderMock.Object);

            // Act
            testAgentsLoggerServicePrivate.LogTestRunMessages(expectedTestRunId);

            // Assert
            _consoleProviderMock.Verify(x => x.WriteLine(It.IsAny<string>()), Times.Exactly(2));
            _testRunLogRepositoryMock.Verify(x => x.GetAsync(It.IsAny<int>()), Times.Exactly(2));
            Assert.That(actualTestRunLogs[0].Status, Is.EqualTo(TestRunLogStatus.Published));
            Assert.That(actualTestRunLogs[1].Status, Is.EqualTo(TestRunLogStatus.Published));
        }
    }
}