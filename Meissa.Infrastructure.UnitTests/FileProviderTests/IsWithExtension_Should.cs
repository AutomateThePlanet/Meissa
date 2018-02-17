// <copyright file="IsWithExtension_Should.cs" company="Automate The Planet Ltd.">
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
using Meissa.Infrastructure.UnitTests.Factories;
using NUnit.Framework;

namespace Meissa.Infrastructure.UnitTests.FileProviderTests
{
    [TestFixture]
    public class IsWithExtension_Should
    {
        private const string XmlExtension = "xml";
        private const string XmlExtensionWithDot = ".xml";
        private const string JsonExtensionWithDot = ".json";

        [Test]
        public void ReturnTrue_When_FileExistsAndExtensionsMatch()
        {
            // Arrange
            string destinationFile = FileFactory.CreateTestFile(extension: XmlExtension);

            // Act
            var fileProvider = new FileProvider();
            bool doExtensionsMatch = fileProvider.IsWithExtension(destinationFile, XmlExtensionWithDot);

            // Assert
            Assert.That(doExtensionsMatch, Is.True);
        }

        [Test]
        public void ReturnFalse_When_FileExistsAndExtensionDoNotMatch()
        {
            // Arrange
            string destinationFile = FileFactory.CreateTestFile(extension: XmlExtension);

            // Act
            var fileProvider = new FileProvider();
            bool doExtensionsMatch = fileProvider.IsWithExtension(destinationFile, JsonExtensionWithDot);

            // Assert
            Assert.That(doExtensionsMatch, Is.False);
        }

        [Test]
        public void ThrowFileNotFoundException_When_FileDoesNotExist()
        {
            // Act
            var fileProvider = new FileProvider();

            // Assert
            Assert.Throws<FileNotFoundException>(() => fileProvider.IsWithExtension(Guid.NewGuid().ToString(), XmlExtensionWithDot), "The specified file does not exist");
        }
    }
}
