// <copyright file="Combine_Shouldcs.cs" company="Automate The Planet Ltd.">
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
using AutoFixture;
using NUnit.Framework;

namespace Meissa.Infrastructure.UnitTests.PathProviderTests
{
    [TestFixture]
    public class Combine_Should
    {
        [Test]
        public void ReturnCombinePath_When_TwoArgumetsPassed()
        {
            // Arrange
            var fixture = new Fixture();
            var expectedPath1 = fixture.Create<string>();
            var expectedPath2 = fixture.Create<string>();

            // Act
            var pathProvider = new PathProvider();
            string actualFileName = pathProvider.Combine(expectedPath1, expectedPath2);

            // Assert
            Assert.That(actualFileName, Is.EqualTo(string.Concat(expectedPath1, "\\", expectedPath2)));
        }

        [Test]
        public void ReturnCombinePath_When_ThreeArgumetsPassed()
        {
            // Arrange
            var fixture = new Fixture();
            var expectedPath1 = fixture.Create<string>();
            var expectedPath2 = fixture.Create<string>();
            var expectedPath3 = fixture.Create<string>();

            // Act
            var pathProvider = new PathProvider();
            string actualFileName = pathProvider.Combine(expectedPath1, expectedPath2, expectedPath3);

            // Assert
            Assert.That(actualFileName, Is.EqualTo(string.Concat(expectedPath1, "\\", expectedPath2, "\\", expectedPath3)));
        }
    }
}
