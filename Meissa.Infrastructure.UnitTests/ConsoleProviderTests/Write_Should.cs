// <copyright file="Write_Should.cs" company="Automate The Planet Ltd.">
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
using NUnit.Framework;

namespace Meissa.Infrastructure.UnitTests.ConsoleProviderTests
{
    [TestFixture]
    public class Write_Should
    {
        [Test]
        public void PrintFormattedString_When_OneArgumentIsSpecified()
        {
            // Arrange
            var originalConsoleOut = System.Console.Out;
            string formattedStringToBePrinted;
            var fixture = new Fixture();
            var expectedText = fixture.Create<string>();
            using (var writer = new StringWriter())
            {
                System.Console.SetOut(writer);

                // Act
                var consoleProvider = new ConsoleProvider();
                consoleProvider.Write(expectedText);

                writer.Flush();

                formattedStringToBePrinted = writer.GetStringBuilder().ToString();
            }

            // Assert
            Assert.That(formattedStringToBePrinted, Is.EqualTo(expectedText));

            // Clean-up
            System.Console.SetOut(originalConsoleOut);
        }

        [Test]
        public void PrintFormattedString_When_FormatAndOneArgumentAreSpecified()
        {
            // Arrange
            var fixture = new Fixture();
            var expectedText = fixture.Create<string>();
            var originalConsoleOut = System.Console.Out;
            string formattedStringToBePrinted;
            using (var writer = new StringWriter())
            {
                System.Console.SetOut(writer);

                // Act
                var consoleProvider = new ConsoleProvider();
                consoleProvider.Write("{0}", expectedText);

                writer.Flush();

                formattedStringToBePrinted = writer.GetStringBuilder().ToString();
            }

            // Assert
            Assert.That(formattedStringToBePrinted, Is.EqualTo(expectedText));

            // Clean-up
            System.Console.SetOut(originalConsoleOut);
        }

        [Test]
        public void PrintFormattedString_When_FormatAndTwoArgumentAreSpecified()
        {
            // Arrange
            var fixture = new Fixture();
            var expectedText1 = fixture.Create<string>();
            var expectedText2 = fixture.Create<string>();
            var originalConsoleOut = System.Console.Out;
            string formattedStringToBePrinted;
            using (var writer = new StringWriter())
            {
                System.Console.SetOut(writer);

                // Act
                var consoleProvider = new ConsoleProvider();
                consoleProvider.Write("{0}{1}", expectedText1, expectedText2);

                writer.Flush();

                formattedStringToBePrinted = writer.GetStringBuilder().ToString();
            }

            // Assert
            Assert.That(formattedStringToBePrinted, Is.EqualTo(string.Concat(expectedText1, expectedText2)));

            // Clean-up
            System.Console.SetOut(originalConsoleOut);
        }
    }
}
