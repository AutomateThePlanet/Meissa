// <copyright file="ReadLine_Should.cs" company="Automate The Planet Ltd.">
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
using System.IO;
using AutoFixture;
using NUnit.Framework;

namespace Meissa.Infrastructure.UnitTests.ConsoleProviderTests;

[TestFixture]
public class ReadLine_Should
{
    [Test]
    public void ReturnsCorrectInput()
    {
        // Arrange
        var fixture = new Fixture();
        var expectedInput = fixture.Create<string>();
        var sr = new StringReader(expectedInput);
        System.Console.SetIn(sr);

        // Act
        var consoleProvider = new ConsoleProvider();
        var actualResult = consoleProvider.ReadLine();

        // Assert
        Assert.That(actualResult, Is.EqualTo(expectedInput));
    }
}
