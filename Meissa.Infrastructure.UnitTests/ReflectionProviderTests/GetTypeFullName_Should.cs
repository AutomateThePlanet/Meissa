// <copyright file="GetTypeFullName_Should.cs" company="Automate The Planet Ltd.">
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
using NUnit.Framework;

namespace Meissa.Infrastructure.UnitTests.ReflectionProviderTests;

[TestFixture]
public class GetTypeFullName_Should
{
    [Test]
    public void CorrectFullNameTypeReturned()
    {
        // Arrange
        var expectedTypeFullName = GetType().FullName;

        // Act
        var reflectionProvider = new ReflectionProvider();
        var actualTypeFullName = reflectionProvider.GetTypeFullName(GetType());

        // Assert
        Assert.That(actualTypeFullName, Is.EqualTo(expectedTypeFullName));
    }
}