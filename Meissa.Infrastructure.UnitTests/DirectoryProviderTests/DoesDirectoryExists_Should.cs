// <copyright file="DoesDirectoryExists_Should.cs" company="Automate The Planet Ltd.">
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
using System.IO;
using AutoFixture;
using Meissa.Infrastructure.UnitTests.Factories;
using NUnit.Framework;

namespace Meissa.Infrastructure.UnitTests.DirectoryProviderTests
{
    [TestFixture]
    public class DoesDirectoryExists_Should
    {
        [Test]
        public void ReturnTrue_When_FolderExists()
        {
            // Arrange
            string newFolder = DirectoryFactory.CreateTestDirectory();
            var directoryProvider = new DirectoryProvider();

            // Act
            bool doesFolderExists = directoryProvider.DoesDirectoryExists(newFolder);

            // Assert
            Assert.That(doesFolderExists, Is.True);

            // Clean-up
            Directory.Delete(newFolder);
        }

        [Test]
        public void ReturnFalse_When_FolderExists()
        {
            // Arrange
            var fixture = new Fixture();
            string newFolder = Path.Combine(Path.GetTempPath(), fixture.Create<string>());
            var directoryProvider = new DirectoryProvider();

            // Act
            bool doesFolderExists = directoryProvider.DoesDirectoryExists(newFolder);

            // Assert
            Assert.That(doesFolderExists, Is.False);
        }
    }
}