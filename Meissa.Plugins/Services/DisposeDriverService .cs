﻿// <copyright file="DisposeDriverService .cs" company="Automate The Planet Ltd.">
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
using System.Collections.Generic;
using System.Diagnostics;

namespace Meissa.Plugins.Services;

public static class DisposeDriverService
{
    private static readonly List<string> _processesToCheck = new List<string>
    { "chromedriver", "opera", "chrome", "firefox", "ie", "gecko", "phantomjs", "edge", "microsoftwebdriver", "webdriver" };

    public static DateTime? TestRunStartTime { get; set; }

    public static void Dispose()
    {
        var processes = Process.GetProcesses();
        foreach (var process in processes)
        {
            try
            {
                Debug.WriteLine(process.ProcessName);
                var shouldKill = false;
                foreach (var processName in _processesToCheck)
                {
                    if (process.ProcessName.ToLower().Contains(processName))
                    {
                        shouldKill = true;
                        break;
                    }
                }

                if (shouldKill)
                {
                    process.Kill();
                    process.WaitForExit();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }
    }
}
