// <copyright file="LogTestAgentsRunsResults_Should.cs" company="Automate The Planet Ltd.">
// Copyright 2024 Automate The Planet Ltd.
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
using System.Threading;
using Meissa.Core.Contracts;
using Meissa.Server.Models;
using Moq;
using NUnit.Framework;

namespace Meissa.Infrastructure.UnitTests.TestAgentsLoggerServiceTests;

[TestFixture]
public class LogTestAgentsRunsResults_Should
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
    public void StartNewLongRunningTaskCreatedSuccessfully()
    {
        // Arrange
        var cancellationTokenSource = new CancellationTokenSource();
        var actualCancellationTokenSource = new CancellationTokenSource();
        int executionFrequency = default(int);
        _taskProviderMock.Setup(x => x.StartNewLongRunningRepeating(cancellationTokenSource, It.IsAny<Action>(), It.IsAny<int>())).Callback((CancellationTokenSource c, Action a, int f) =>
                                                                                                                                      {
                                                                                                                                          actualCancellationTokenSource = c;
                                                                                                                                          executionFrequency = f;
                                                                                                                                      });

        // Act
        var testAgentsLoggerService = new TestAgentsLoggerService(_testRunLogRepositoryMock.Object, _taskProviderMock.Object, _consoleProviderMock.Object);
        testAgentsLoggerService.LogTestAgentsRunsResults(cancellationTokenSource, Guid.NewGuid());

        // Assert
        Assert.That(cancellationTokenSource, Is.EqualTo(actualCancellationTokenSource));
        Assert.That(executionFrequency, Is.EqualTo(5000));
    }
}
