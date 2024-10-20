// <copyright file="DeleteAllDumps_Should.cs" company="Automate The Planet Ltd.">
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
using System.Threading.Tasks;
using Meissa.Core.Contracts;
using Meissa.Server.Models;
using Meissa.Tests.Factories;
using Moq;
using NUnit.Framework;

namespace Meissa.Infrastructure.UnitTests.ExceptionLogDumpCreatorTests;

[TestFixture]
public class DeleteAllDumps_Should
{
    private Mock<IServiceClient<LogDto>> _logRepositoryMock;
    private Mock<IDateTimeProvider> _dateTimeProvider;
    private Mock<IFileProvider> _fileProvider;
    private Mock<IDirectoryProvider> _directoryProvider;
    private Mock<IPathProvider> _pathProvider;
    private Mock<IConsoleProvider> _consoleProvider;
    private Mock<IReflectionProvider> _reflectionProvider;

    [SetUp]
    public void TestInit()
    {
        _logRepositoryMock = new Mock<IServiceClient<LogDto>>();
        _dateTimeProvider = new Mock<IDateTimeProvider>();
        _fileProvider = new Mock<IFileProvider>();
        _directoryProvider = new Mock<IDirectoryProvider>();
        _pathProvider = new Mock<IPathProvider>();
        _consoleProvider = new Mock<IConsoleProvider>();
        _reflectionProvider = new Mock<IReflectionProvider>();
    }

    [Test]
    public async Task LogsDeleted_When_NoLogsExist()
    {
        // Arrange
        var logs = LogFactory.CreateEmpty();
        _logRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(logs));

        var exceptionLogDumpCreator = new DistributeLogDumpCreator(
            _logRepositoryMock.Object,
            _dateTimeProvider.Object,
            _fileProvider.Object,
            _directoryProvider.Object,
            _pathProvider.Object,
            _consoleProvider.Object,
            _reflectionProvider.Object);

        // Act
        await exceptionLogDumpCreator.DeleteAllDumpsAsync();

        // Assert
        await exceptionLogDumpCreator.DeleteAllDumpsAsync();
    }

    [Test]
    public async Task LogsDeleted_When_OneLogExists()
    {
        // Arrange
        var logs = LogFactory.Create(1);
        _logRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(logs));
        var exceptionLogDumpCreator = new DistributeLogDumpCreator(
            _logRepositoryMock.Object,
            _dateTimeProvider.Object,
            _fileProvider.Object,
            _directoryProvider.Object,
            _pathProvider.Object,
            _consoleProvider.Object,
            _reflectionProvider.Object);

        // Act
        await exceptionLogDumpCreator.DeleteAllDumpsAsync();

        // Assert
        _logRepositoryMock.Verify(x => x.DeleteAsync(logs), Times.AtLeastOnce);
    }

    [Test]
    public async Task LogsDeleted_When_TwoLogsExist()
    {
        // Arrange
        var logs = LogFactory.Create(2);
        _logRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(logs));
        var exceptionLogDumpCreator = new DistributeLogDumpCreator(
            _logRepositoryMock.Object,
            _dateTimeProvider.Object,
            _fileProvider.Object,
            _directoryProvider.Object,
            _pathProvider.Object,
            _consoleProvider.Object,
            _reflectionProvider.Object);

        // Act
        await exceptionLogDumpCreator.DeleteAllDumpsAsync();

        // Assert
        _logRepositoryMock.Verify(x => x.DeleteAsync(logs), Times.AtLeastOnce());
    }
}
