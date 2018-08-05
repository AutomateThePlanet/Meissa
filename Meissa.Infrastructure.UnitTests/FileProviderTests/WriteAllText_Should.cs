// <copyright file="WriteAllText_Should.cs" company="Automate The Planet Ltd.">
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
using System;
using System.IO;
using NUnit.Framework;

namespace Meissa.Infrastructure.UnitTests.FileProviderTests
{
    [TestFixture]
    public class WriteAllText_Should
    {
        [Test]
        public void TextSuccessfullyWritten()
        {
            // Arrange
            string path = Path.GetTempFileName();
            string contents = Guid.NewGuid().ToString();

            // Act
            var directoryProvider = new FileProvider();
            directoryProvider.WriteAllText(path, contents);

            string actualText = File.ReadAllText(path);

            // Assert
            Assert.That(actualText, Is.EqualTo(contents));
        }
    }
}