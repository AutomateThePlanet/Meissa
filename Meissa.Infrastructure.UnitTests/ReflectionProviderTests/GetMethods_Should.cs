// <copyright file="GetMethods_Should.cs" company="Automate The Planet Ltd.">
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
using NUnit.Framework;

namespace Meissa.Infrastructure.UnitTests.ReflectionProviderTests
{
    [TestFixture]
    public class GetMethods_Should
    {
        [Test]
        public void CorrectMethodsReturned()
        {
            // Arrange
            var expectedMethods = GetType().GetMethods();

            // Act
            var reflectionProvider = new ReflectionProvider();
            var actualMethod = reflectionProvider.GetMethods(GetType());

            // Assert
            Assert.That(actualMethod.FirstOrDefault()?.Name, Is.EqualTo(expectedMethods.FirstOrDefault()?.Name));
        }
    }
}