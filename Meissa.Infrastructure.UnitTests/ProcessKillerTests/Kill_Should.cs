// <copyright file="Kill_Should.cs" company="Automate The Planet Ltd.">
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
using System.Diagnostics;
using NUnit.Framework;

namespace Meissa.Infrastructure.UnitTests.ProcessKillerTests
{
    [TestFixture]
    public class Kill_Should
    {
        [Test]
        public void TerminateProcess()
        {
            // Arrange
            var process = new Process();
            var startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "cmd.exe",
            };
            process.StartInfo = startInfo;
            process.Start();

            // Act
            var processKiller = new ProcessKiller();
            processKiller.Kill("cmd");

            // Assert
            Assert.That(process.HasExited, Is.True);
        }
    }
}