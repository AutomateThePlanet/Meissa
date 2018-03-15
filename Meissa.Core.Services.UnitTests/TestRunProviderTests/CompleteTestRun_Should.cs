// <copyright file="CompleteTestRun_Should.cs" company="Automate The Planet Ltd.">
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

namespace Meissa.Core.Services.UnitTests.TestRunProviderTests
{
    [TestFixture]
    public class CompleteTestRun_Should
    {
        private Mock<IServiceClient<TestRunDto>> _testRunRepositoryMock;
        private Mock<IServiceClient<TestRunCustomArgumentDto>> _testRunCustomArgumentRepositoryMock;
        private Mock<ITestRunOutputServiceClient> _testRunOutputRepositoryMock;
        private Mock<IDateTimeProvider> _dateTimeProviderMock;
        private Mock<IGuidService> _guidServiceMock;
        private ITestRunProvider _testRunProvider;
        private Fixture _fixture;
        private Guid _testRunId;

        [SetUp]
        public void TestInit()
        {
            _testRunRepositoryMock = new Mock<IServiceClient<TestRunDto>>();
            _testRunCustomArgumentRepositoryMock = new Mock<IServiceClient<TestRunCustomArgumentDto>>();
            _dateTimeProviderMock = new Mock<IDateTimeProvider>();
            _guidServiceMock = new Mock<IGuidService>();
            _testRunOutputRepositoryMock = new Mock<ITestRunOutputServiceClient>();
            _testRunProvider = new TestRunProvider(_testRunRepositoryMock.Object, _testRunCustomArgumentRepositoryMock.Object, _testRunOutputRepositoryMock.Object, _dateTimeProviderMock.Object, _guidServiceMock.Object);
            _fixture = new Fixture();
            _testRunId = _fixture.Create<Guid>();
        }

        [Test]
        [TestCase(TestRunStatus.Aborted)]
        [TestCase(TestRunStatus.Completed)]
        public void ThrowInvalidOperationException_When_NoTestRunExistForProvidedTestRunId_AndStatus(TestRunStatus status)
        {
            // Arrange
            var testRuns = TestRunFactory.CreateMany();
            _testRunRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(testRuns));

            // Act
            var action = new TestDelegate(() => _testRunProvider.CompleteTestRunAsync(_testRunId, status));

            // Assert
            Assert.That(action, Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        [TestCase(TestRunStatus.Aborted)]
        [TestCase(TestRunStatus.Completed)]
        public void ThrowInvalidOperationException_When_MoreThanOneTestRunExistForProvidedTestRunId_AndStatus(TestRunStatus status)
        {
            // Arrange
            var testRuns = TestRunFactory.CreateMany(_testRunId);
            _testRunRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(testRuns));

            // Act
            var action = new TestDelegate(() => _testRunProvider.CompleteTestRunAsync(_testRunId, status));

            // Assert
            Assert.That(action, Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void ThrowArgumentException_When_ProvidedStatusIsInProgress()
        {
            // Arrange
            var testRuns = TestRunFactory.CreateSingleInProgress(_testRunId);
            _testRunRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(testRuns));

            // Act
            var action = new TestDelegate(() => _testRunProvider.CompleteTestRunAsync(_testRunId, TestRunStatus.InProgress));

            // Assert
            Assert.That(action, Throws.Exception.TypeOf<ArgumentException>());
        }

        [Test]
        [TestCase(TestRunStatus.Aborted)]
        [TestCase(TestRunStatus.Completed)]
        public async Task ShouldUpdateTestRunStatusToProvidedValue_When_OnlyOneTestRunExistForProvidedTestRunId_AndStatus(TestRunStatus status)
        {
            // Arrange
            var testRun = TestRunFactory.CreateSingleInProgress(_testRunId);
            _testRunRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(testRun));

            // Act
            await _testRunProvider.CompleteTestRunAsync(_testRunId, status);

            // Assert
            _testRunRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<int>(), It.Is<TestRunDto>(i => i.TestRunId == _testRunId && i.Status == status)), Times.Once);
        }

        [Test]
        [TestCase(TestRunStatus.Aborted)]
        [TestCase(TestRunStatus.Completed)]
        public async Task ShouldUpdateTestRunStatusToProvidedValue_When_OneTestRunExistForProvidedTestRunId_AndOtherTestRunsExists_AndStatus(TestRunStatus status)
        {
            // Arrange
            var currentTestRun = TestRunFactory.CreateSingleInProgress(_testRunId);
            var otherTestRuns = TestRunFactory.CreateMany();
            _testRunRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(currentTestRun.Union(otherTestRuns)));

            // Act
            await _testRunProvider.CompleteTestRunAsync(_testRunId, status);

            // Assert
            _testRunRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<int>(), It.Is<TestRunDto>(i => i.TestRunId == _testRunId && i.Status == status)), Times.Once);
            _testRunRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<int>(), It.IsAny<TestRunDto>()), Times.Once);
        }
    }
}