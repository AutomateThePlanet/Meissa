// <copyright file="CreateDump_Should.cs" company="Automate The Planet Ltd.">
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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meissa.API.Models;
using Meissa.Core.Contracts;
using Meissa.Infrastructure.UnitTests.Factories;
using Meissa.Tests.Factories;
using Moq;
using NUnit.Framework;

namespace Meissa.Infrastructure.UnitTests.ExceptionLogDumpCreatorTests
{
    [TestFixture]
    public class CreateDump_Should
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
        public async Task EmptyFileGenerated_When_NoLogsExist()
        {
            // Arrange
            var logs = LogFactory.CreateEmpty();
            _logRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(logs));
            _directoryProvider.Setup(x => x.DoesDirectoryExists(It.IsAny<string>())).Returns(true);
            _dateTimeProvider.Setup(x => x.GetCurrentTime()).Returns(DateTime.Now);
            _pathProvider.Setup(x => x.Combine(It.IsAny<string>(), It.IsAny<string>())).Returns((string path1, string filePath) => Path.Combine(path1, filePath));
            _fileProvider.Setup(x => x.WriteAllText(It.IsAny<string>(), It.IsAny<string>())).Callback((string filePath, string content) => File.WriteAllText(filePath, content));
            string dumpFileLocation = DirectoryFactory.CreateTestDirectory();
            var exceptionLogDumpCreator = new DistributeLogDumpCreator(
                                                                      _logRepositoryMock.Object,
                                                                      _dateTimeProvider.Object,
                                                                      _fileProvider.Object,
                                                                      _directoryProvider.Object,
                                                                      _pathProvider.Object,
                                                                      _consoleProvider.Object,
                                                                      _reflectionProvider.Object);

            // Act
            string dumpFile = await exceptionLogDumpCreator.CreateDumpAsync(dumpFileLocation);

            // Assert
            string dumpFileContent = File.ReadAllText(dumpFile);
            Assert.That(dumpFileContent, Is.EqualTo(string.Empty));
        }

        [Test]
        public async Task OneLogWrittenInFile_When_OneLogExists()
        {
            // Arrange
            var logs = LogFactory.Create(1);
            _logRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(logs));
            _directoryProvider.Setup(x => x.DoesDirectoryExists(It.IsAny<string>())).Returns(true);
            _dateTimeProvider.Setup(x => x.GetCurrentTime()).Returns(DateTime.Now);
            _pathProvider.Setup(x => x.Combine(It.IsAny<string>(), It.IsAny<string>())).Returns((string path1, string filePath) => Path.Combine(path1, filePath));
            _fileProvider.Setup(x => x.WriteAllText(It.IsAny<string>(), It.IsAny<string>())).Callback((string filePath, string content) => File.WriteAllText(filePath, content));
            string dumpFileLocation = DirectoryFactory.CreateTestDirectory();
            var exceptionLogDumpCreator = new DistributeLogDumpCreator(
                _logRepositoryMock.Object,
                _dateTimeProvider.Object,
                _fileProvider.Object,
                _directoryProvider.Object,
                _pathProvider.Object,
                _consoleProvider.Object,
                _reflectionProvider.Object);

            // Act
            string dumpFile = await exceptionLogDumpCreator.CreateDumpAsync(dumpFileLocation);

            // Assert
            string dumpFileContent = File.ReadAllText(dumpFile);
            string expectedContent = GetExpectedDumpFileContent(logs);
            Assert.That(dumpFileContent, Is.EqualTo(expectedContent));
        }

        [Test]
        public async Task TwoLogWrittenInFile_When_TwoLogExist()
        {
            // Arrange
            var logs = LogFactory.Create(2);
            _logRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(logs));
            _directoryProvider.Setup(x => x.DoesDirectoryExists(It.IsAny<string>())).Returns(true);
            _dateTimeProvider.Setup(x => x.GetCurrentTime()).Returns(DateTime.Now);
            _pathProvider.Setup(x => x.Combine(It.IsAny<string>(), It.IsAny<string>())).Returns((string path1, string filePath) => Path.Combine(path1, filePath));
            _fileProvider.Setup(x => x.WriteAllText(It.IsAny<string>(), It.IsAny<string>())).Callback((string filePath, string content) => File.WriteAllText(filePath, content));
            string dumpFileLocation = DirectoryFactory.CreateTestDirectory();
            var exceptionLogDumpCreator = new DistributeLogDumpCreator(
                _logRepositoryMock.Object,
                _dateTimeProvider.Object,
                _fileProvider.Object,
                _directoryProvider.Object,
                _pathProvider.Object,
                _consoleProvider.Object,
                _reflectionProvider.Object);

            // Act
            string dumpFile = await exceptionLogDumpCreator.CreateDumpAsync(dumpFileLocation);

            // Assert
            string dumpFileContent = File.ReadAllText(dumpFile);
            string expectedContent = GetExpectedDumpFileContent(logs);
            Assert.That(dumpFileContent, Is.EqualTo(expectedContent));
        }

        [Test]
        public async Task UniqueTimestampFileNameGenerated_When_NoLogExists()
        {
            // Arrange
            var logs = LogFactory.Create(2);
            _logRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(logs));
            _directoryProvider.Setup(x => x.DoesDirectoryExists(It.IsAny<string>())).Returns(true);
            _dateTimeProvider.Setup(x => x.GetCurrentTime()).Returns(new DateTime(1989, 10, 28, 21, 21, 5, 999));
            _pathProvider.Setup(x => x.Combine(It.IsAny<string>(), It.IsAny<string>())).Returns((string path1, string filePath) => Path.Combine(path1, filePath));
            _fileProvider.Setup(x => x.WriteAllText(It.IsAny<string>(), It.IsAny<string>())).Callback((string filePath, string content) => File.WriteAllText(filePath, content));
            string dumpFileLocation = DirectoryFactory.CreateTestDirectory();
            var exceptionLogDumpCreator = new DistributeLogDumpCreator(
                _logRepositoryMock.Object,
                _dateTimeProvider.Object,
                _fileProvider.Object,
                _directoryProvider.Object,
                _pathProvider.Object,
                _consoleProvider.Object,
                _reflectionProvider.Object);

            // Act
            string dumpFile = await exceptionLogDumpCreator.CreateDumpAsync(dumpFileLocation);

            // Assert
            string expectedDumpFileName = "10-28-1989-09-21-05-9990.txt";
            Assert.That(new FileInfo(dumpFile).Name, Is.EqualTo(expectedDumpFileName));
        }

        [Test]
        public async Task ThrowArgumentException_When_DumpLocationDoesNotExist()
        {
            // Arrange
            var logs = LogFactory.Create(2);
            _logRepositoryMock.Setup(x => x.GetAllAsync()).Returns(Task.FromResult(logs));
            _directoryProvider.Setup(x => x.DoesDirectoryExists(It.IsAny<string>())).Returns(false);
            _dateTimeProvider.Setup(x => x.GetCurrentTime()).Returns(DateTime.Now);
            _pathProvider.Setup(x => x.Combine(It.IsAny<string>(), It.IsAny<string>())).Returns((string path1, string filePath) => Path.Combine(path1, filePath));
            _fileProvider.Setup(x => x.WriteAllText(It.IsAny<string>(), It.IsAny<string>())).Callback((string filePath, string content) => File.WriteAllText(filePath, content));
            var exceptionLogDumpCreator = new DistributeLogDumpCreator(
                _logRepositoryMock.Object,
                _dateTimeProvider.Object,
                _fileProvider.Object,
                _directoryProvider.Object,
                _pathProvider.Object,
                _consoleProvider.Object,
                _reflectionProvider.Object);

            // Act
            string dumpLocation = Guid.NewGuid().ToString();

            // Assert
            Assert.Throws<ArgumentException>(() => exceptionLogDumpCreator.CreateDumpAsync(dumpLocation),
                                             string.Format("The specified dump location '{0}' does not exist.", dumpLocation));
        }

        private string GetExpectedDumpFileContent(IQueryable<LogDto> logs)
        {
            var sb = new StringBuilder();
            foreach (var exceptionLog in logs)
            {
                sb.AppendLine(string.Format("{0} {1} {2}", exceptionLog.Date, exceptionLog.Message, exceptionLog.Exception));
            }

            return sb.ToString();
        }
    }
}
