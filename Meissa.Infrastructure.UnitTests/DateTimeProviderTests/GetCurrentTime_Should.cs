// <copyright file="GetCurrentTime_Should.cs" company="Automate The Planet Ltd.">
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
using System;
using NUnit.Framework;

namespace Meissa.Infrastructure.UnitTests.DateTimeProviderTests;

[TestFixture]
public class GetCurrentTime_Should
{
    [Test]
    public void CorrectCurrentTimeReturned()
    {
        // Arrange
        var dateTimeProvider = new DateTimeProvider();

        // Act
        var now = dateTimeProvider.GetCurrentTime();

        // Assert
        Assert.That(now, Is.EqualTo(DateTime.Now).Within(TimeSpan.FromMilliseconds(5)));
    }
}
