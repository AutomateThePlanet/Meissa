﻿// <copyright file="ReadAllText_Should.cs" company="Automate The Planet Ltd.">
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
using AutoFixture;
using Meissa.Infrastructure.UnitTests.Factories;
using NUnit.Framework;

namespace Meissa.Infrastructure.UnitTests.FileProviderTests;

[TestFixture]
public class ReadAllText_Should
{
    [Test]
    public void TextSuccessfullyRead()
    {
        // Arrange
        var fixture = new Fixture();
        var expectedText = fixture.Create<string>();
        string destinationFile = FileFactory.CreateTestFile(expectedText, string.Empty);

        // Act
        var directoryProvider = new FileProvider();
        string actualText = directoryProvider.ReadAllText(destinationFile);

        // Assert
        Assert.That(actualText, Is.EqualTo(expectedText));
    }
}