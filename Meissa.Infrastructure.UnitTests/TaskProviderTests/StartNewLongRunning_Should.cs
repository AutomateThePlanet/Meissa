// <copyright file="StartNewLongRunning_Should.cs" company="Automate The Planet Ltd.">
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
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using Meissa.Core.Contracts;
using Moq;
using NUnit.Framework;

namespace Meissa.Infrastructure.UnitTests.TaskProviderTests;

[TestFixture]
public class StartNewLongRunning_Should
{
    private Mock<IDistributeLogger> _exceptionLoggerMock;
    private Fixture _fixture;

    [SetUp]
    public void TestInit()
    {
        _exceptionLoggerMock = new Mock<IDistributeLogger>();
        _fixture = new Fixture();
    }

    [Test]
    public void WaitedForCorrectFrequency_When_OneSecondFrequencyIsSpecified()
    {
        // Arrange
        var taskProvider = new TaskProvider(_exceptionLoggerMock.Object);
        var cancellationTokenSource = new CancellationTokenSource();
        int actionTimesCalled = 0;

        // Act
        var stopwatch = new Stopwatch();
        var task = taskProvider.StartNewLongRunningRepeating(cancellationTokenSource, () => actionTimesCalled++, 200);
        Thread.Sleep(400);
        cancellationTokenSource.Cancel();
        task?.Wait();
        stopwatch.Stop();

        // Assert
        Assert.That(actionTimesCalled, Is.AtLeast(2));
        Assert.That(task?.Status, Is.EqualTo(TaskStatus.RanToCompletion));
        Assert.That(stopwatch.Elapsed, Is.EqualTo(TimeSpan.FromMilliseconds(200)).Within(250).Milliseconds);
    }

    [Test]
    public void LongRunningTaskCreated()
    {
        // Arrange
        var taskProvider = new TaskProvider(_exceptionLoggerMock.Object);
        var cancellationTokenSource = new CancellationTokenSource();

        // Act
        var task = taskProvider.StartNewLongRunningRepeating(cancellationTokenSource, () => { }, 100);

        // Assert
        Assert.That(task.CreationOptions, Is.EqualTo(TaskCreationOptions.LongRunning));

        // Clean up
        cancellationTokenSource.Cancel();
    }

    [Test]
    public void TaskCancelled_And_ActionExecutedOnlyOnce_When_CancellationRequested()
    {
        // Arrange
        var taskProvider = new TaskProvider(_exceptionLoggerMock.Object);
        var cancellationTokenSource = new CancellationTokenSource();
        int actionTimesCalled = 0;

        // Act
        var stopwatch = new Stopwatch();
        var task = taskProvider.StartNewLongRunningRepeating(cancellationTokenSource, () => actionTimesCalled++, 200);
        Thread.Sleep(100);
        cancellationTokenSource.Cancel();
        stopwatch.Stop();
        Thread.Sleep(200);

        // Assert
        Assert.That(actionTimesCalled, Is.EqualTo(1));
        Assert.That(task.Status, Is.EqualTo(TaskStatus.RanToCompletion));
    }

    [Test]
    public void NoExceptionThrown_When_NoExceptionsAreThrownInsideAction()
    {
        // Arrange
        var taskProvider = new TaskProvider(_exceptionLoggerMock.Object);
        var cancellationTokenSource = new CancellationTokenSource();

        // Act
        taskProvider.StartNewLongRunningRepeating(cancellationTokenSource, () => { }, 200);
        cancellationTokenSource.Cancel();

        // Assert
        _exceptionLoggerMock.Verify(x => x.LogErrorAsync(It.IsAny<string>(), It.IsAny<Exception>()), Times.Never);
    }

    [Test]
    public void AggregateExceptionThrown_When_AggregateExceptionThrownInsideAction_AndShouldRethrowExceptionIsTrue()
    {
        // Arrange
        var expectedException = new Exception(_fixture.Create<string>());
        string expectedAggregateExceptionMessage = _fixture.Create<string>();
        var aggregateException = new AggregateException(expectedAggregateExceptionMessage, expectedException);
        string message = string.Empty;
        var actualException = default(Exception);
        _exceptionLoggerMock.Setup(x => x.LogErrorAsync(It.IsAny<string>(), It.IsAny<Exception>())).Callback((string exMessage, Exception ex) =>
                                                                                                  {
                                                                                                      message = exMessage;
                                                                                                      actualException = ex;
                                                                                                  });
        var taskProvider = new TaskProvider(_exceptionLoggerMock.Object);
        var cancellationTokenSource = new CancellationTokenSource();

        // Act
        // Assert
        Assert.Throws<AggregateException>(() => taskProvider.StartNewLongRunningRepeating(cancellationTokenSource, () => throw aggregateException, 200).Wait(), expectedAggregateExceptionMessage);

        Assert.That(message, Is.EqualTo(typeof(Exception).Name));
        Assert.That(actualException, Is.EqualTo(expectedException));

        // Clean up
        cancellationTokenSource.Cancel();
    }

    [Test]
    public void AggregateExceptionWithTwoInnerExceptionsThrown_When_AggregateExceptionWithTwoInnerExceptionsThrownInsideAction_AndShouldRethrowExceptionIsTrue()
    {
        // Arrange
        var expectedInternalException1 = new Exception(_fixture.Create<string>());
        var expectedInternalException2 = new ArgumentException(_fixture.Create<string>());
        string expectedAggregateExceptionMessage = _fixture.Create<string>();
        var aggregateException = new AggregateException(expectedAggregateExceptionMessage, expectedInternalException1, expectedInternalException2);

        List<string> messages = new List<string>();
        List<Exception> actualExceptions = new List<Exception>();
        _exceptionLoggerMock.Setup(x => x.LogErrorAsync(It.IsAny<string>(), It.IsAny<Exception>())).Callback((string exMessage, Exception ex) =>
                                                                                                  {
                                                                                                      messages.Add(exMessage);
                                                                                                      actualExceptions.Add(ex);
                                                                                                  });
        var taskProvider = new TaskProvider(_exceptionLoggerMock.Object);
        var cancellationTokenSource = new CancellationTokenSource();

        // Act
        // Assert
        Assert.Throws<AggregateException>(() => taskProvider.StartNewLongRunningRepeating(cancellationTokenSource, () => throw aggregateException, 200).Wait(), expectedAggregateExceptionMessage);

        Assert.That(messages.First(), Is.EqualTo(typeof(Exception).Name));
        Assert.That(messages.Last(), Is.EqualTo(typeof(ArgumentException).Name));
        Assert.That(actualExceptions.First(), Is.EqualTo(expectedInternalException1));
        Assert.That(actualExceptions.Last(), Is.EqualTo(expectedInternalException2));

        // Clean up
        cancellationTokenSource.Cancel();
    }

    [Test]
    public void ExceptionLogged_When_ExceptionThrownInsideAction()
    {
        // Arrange
        string expectedInnerExceptionMessage = _fixture.Create<string>();
        var expectedInternalException = new Exception(expectedInnerExceptionMessage);

        string actualExceptionMessage = string.Empty;
        var actualException = default(Exception);
        _exceptionLoggerMock.Setup(x => x.LogErrorAsync(It.IsAny<string>(), It.IsAny<Exception>())).Callback((string exMessage, Exception ex) =>
                                                                                                  {
                                                                                                      actualExceptionMessage = exMessage;
                                                                                                      actualException = ex;
                                                                                                  });
        var taskProvider = new TaskProvider(_exceptionLoggerMock.Object);
        var cancellationTokenSource = new CancellationTokenSource();

        // Act
        // Assert
        taskProvider.StartNewLongRunningRepeating(cancellationTokenSource, () => throw expectedInternalException, 200);
        Thread.Sleep(1000);

        Assert.That(actualExceptionMessage, Is.EqualTo(expectedInnerExceptionMessage));
        Assert.That(actualException, Is.EqualTo(expectedInternalException));

        // Clean up
        cancellationTokenSource.Cancel();
    }
}
