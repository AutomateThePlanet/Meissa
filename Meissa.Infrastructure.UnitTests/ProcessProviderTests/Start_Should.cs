// <copyright file="Start_Should.cs" company="Automate The Planet Ltd.">
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
// <site>https://bellatrix.solutions/</site>
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NUnit.Framework;

namespace Meissa.Infrastructure.UnitTests.ProcessProviderTests
{
    [TestFixture]
    public class Start_Should
    {
        private string _pathToTestConsoleApp;

        [OneTimeSetUp]
        public void TestFixtureSetUp()
        {
            var currrentAssemblyDirectoryPath = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory.FullName;
            _pathToTestConsoleApp = Path.Combine(currrentAssemblyDirectoryPath, "DistributedNUnit.Tests.ConsoleApp.exe");
        }

        [Test]
        public void ReturnZero_When_ProcessExitedCorrectly()
        {
            // Arrange
            var processProvider = new ProcessProvider();

            // Act
            var exitCode = processProvider.StartProcessAndWaitToFinish(_pathToTestConsoleApp, null, "exit", 300);

            // Assert
            Assert.That(exitCode, Is.EqualTo(0));
        }

        [Test]
        public void ReturnNotMinusOne_When_ProcessExitedWithError()
        {
            // Arrange
            var processProvider = new ProcessProvider();

            // Act
            var exitCode = processProvider.StartProcessAndWaitToFinish(_pathToTestConsoleApp, null, "exception", 0);

            // Assert
            Assert.That(exitCode, Is.EqualTo(-2));
        }

        [Test]
        public void ExecuteStandardOutputCallback_When_StandardOutputIsReceived()
        {
            // Arrange
            var processProvider = new ProcessProvider();
            var actualStartdardOutputMessages = new List<string>();

            // Act
            processProvider.StartProcessAndWaitToFinish(_pathToTestConsoleApp, null, "writeInfo", 20, message => actualStartdardOutputMessages.Add(message));

            // Assert
            Assert.That(actualStartdardOutputMessages.Count, Is.EqualTo(3));
            Assert.That(actualStartdardOutputMessages[0], Is.EqualTo("write first line"));
            Assert.That(actualStartdardOutputMessages[1], Is.EqualTo("write second line"));
        }

        [Test]
        public void ExecuteErrorOutputCallback_When_ErrorOutputIsReceived()
        {
            // Arrange
            var processProvider = new ProcessProvider();
            var actualErrorOutputMessages = new List<string>();

            // Act
            processProvider.StartProcessAndWaitToFinish(_pathToTestConsoleApp, null, "writeError", 10, errorOutputCallback: message => { actualErrorOutputMessages.Add(message); });

            // Assert
            Assert.That(actualErrorOutputMessages.Count, Is.EqualTo(3));
            Assert.That(actualErrorOutputMessages[0], Is.EqualTo("write error first line"));
            Assert.That(actualErrorOutputMessages[1], Is.EqualTo("write error second line"));
        }

        [Test]
        public void ExecuteStandardOutputCallback_And_ErrorOutputCallback__When_StandardOutputAndErrorOutputAreReceived()
        {
            // Arrange
            var processProvider = new ProcessProvider();
            var actualErrorOutputMessages = new List<string>();
            var actualStartdardOutputMessages = new List<string>();

            // Act
            processProvider.StartProcessAndWaitToFinish(
                                         _pathToTestConsoleApp,
                                         null,
                                         "writeInfoError",
                                         10,
                                         message => actualStartdardOutputMessages.Add(message),
                                         message => actualErrorOutputMessages.Add(message));

            // Assert
            Assert.That(actualStartdardOutputMessages.Count, Is.EqualTo(3));
            Assert.That(actualStartdardOutputMessages[0], Is.EqualTo("write first line"));
            Assert.That(actualStartdardOutputMessages[1], Is.EqualTo("write second line"));

            Assert.That(actualStartdardOutputMessages.Count, Is.EqualTo(3));
            Assert.That(actualStartdardOutputMessages[0], Is.EqualTo("write first line"));
            Assert.That(actualStartdardOutputMessages[1], Is.EqualTo("write second line"));
        }

        [Test]
        public void ExitWithMinusOneExitCode_When_ProcessTimeouts()
        {
            // Arrange
            var processProvider = new ProcessProvider();

            // Act
            var exitCode = processProvider.StartProcessAndWaitToFinish(_pathToTestConsoleApp, null, "sleep", 0);

            // Assert
            Assert.That(exitCode, Is.EqualTo(-2));
        }
    }
}
