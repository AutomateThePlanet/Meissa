// <copyright file="ProcessKiller.cs" company="Automate The Planet Ltd.">
// Copyright 2020 Automate The Planet Ltd.
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
using System.Diagnostics;
using Meissa.Core.Contracts;

namespace Meissa.Infrastructure
{
    public class ProcessKiller : IProcessKiller
    {
        public void KillNUnitConsoleRunner()
        {
            Kill("nunit3-console");
            Kill("nunit-agent");
        }

        public void KillBrowsers()
        {
            Kill("iexplore");
            Kill("firefox");
            Kill("chrome");
            Kill("Safari");
        }

        public void Kill(string processName)
        {
            var psiArgument = $"Get-Process {processName} | stop-process";

            var psi = new ProcessStartInfo
            {
                FileName = "powershell",
                Arguments = psiArgument,
                WindowStyle = ProcessWindowStyle.Hidden,
            };
            var process = new Process
            {
                StartInfo = psi,
            };
            process.Start();
            process.WaitForExit();
        }
    }
}