// <copyright file="TestRunSettings.cs" company="Automate The Planet Ltd.">
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
using System.Collections.Generic;
using System.IO;

namespace Meissa.Core.Model.Settings;

public class TestRunSettings
{
    public string TestsFilter { get; set; }
    public string ResultsFilePath { get; set; }
    public string TestLibraryPath { get; set; }
    public string TestTechnology { get; set; }
    public string AgentTag { get; set; }
    public string NativeArguments { get; set; }
    public bool RunInParallel { get; set; }
    public int MaxParallelProcessesCount { get; set; }
    public bool TimeBasedBalance { get; set; }
    public bool SameMachineByClass { get; set; }
    public int TestRunTimeout { get; set; }
    public IEnumerable<string> CustomArguments { get; set; }
    public int RetriesCount { get; set; }
    public double Threshold { get; set; }
    public string RetriedResultsFilePath { get; set; }

    public string GetOutputFilesLocation()
    {
        return Path.GetDirectoryName(TestLibraryPath);
    }
}
