// <copyright file="GetCustomAttributes_Should.cs" company="Automate The Planet Ltd.">
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
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Meissa.Infrastructure.UnitTests.ReflectionProviderTests
{
    [TestFixture]
    public class GetCustomAttributes_Should
    {
        [Test]
        public void OneAttributeReturned_When_OneAttributeExists()
        {
            // Act
            var reflectionProvider = new ReflectionProvider();
            var actualAttributes = reflectionProvider.GetCustomAttributes(GetType().GetMethods()[0]);

            // Assert
            Assert.That(actualAttributes.ToList().Count, Is.EqualTo(1));
        }

        [Test]
        public void CorrectAttributeReturned_When_OneAttributeExists()
        {
            // Arrange
            var expectedAttributes = GetType().GetMethods()[0].GetCustomAttributes();

            // Act
            var reflectionProvider = new ReflectionProvider();
            var actualAttributes = reflectionProvider.GetCustomAttributes(GetType().GetMethods()[0]);

            // Assert
            Assert.That(actualAttributes.First().GetType().Name, Is.EqualTo(expectedAttributes.First().GetType().Name));
        }
    }
}