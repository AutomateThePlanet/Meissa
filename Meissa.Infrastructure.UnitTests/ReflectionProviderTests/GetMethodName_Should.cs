// <copyright file="GetMethodName_Should.cs" company="Automate The Planet Ltd.">
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
using System.Linq;
using NUnit.Framework;

namespace Meissa.Infrastructure.UnitTests.ReflectionProviderTests
{
    [TestFixture]
    public class GetMethodName_Should
    {
        [Test]
        public void CorrectMethodNameReturned()
        {
            // Arrange
            var expectedMethodName = GetType().GetMethods().FirstOrDefault()?.Name;

            // Act
            var reflectionProvider = new ReflectionProvider();
            var actualMethodName = reflectionProvider.GetMethodName(GetType().GetMethods().FirstOrDefault());

            // Assert
            Assert.That(actualMethodName, Is.EqualTo(expectedMethodName));
        }
    }
}