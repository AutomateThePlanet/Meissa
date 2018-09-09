
// <copyright file="NativeTestsRunnerTestCasesPluginService.cs" company="Automate The Planet Ltd.">
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
using System;
using System.Collections.Generic;
using System.Composition;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Meissa.Core.Model;
using Meissa.Plugins.Contracts;

namespace Meissa.Plugins.Protractor
{
    [Export(typeof(INativeTestsRunnerTestCasesPluginService))]
    public class NativeTestsRunnerTestCasesPluginService : INativeTestsRunnerTestCasesPluginService
    {
        private const string ItNamePattern = @"(?'before'.*)(?'itBegin'it\(')(?'itName'.*)(?'thirdPart'(',).*)";

        public string Name => "Protractor";

        // Should point the path where all spec files are placed.
        public List<TestCase> ExtractAllTestCasesFromTestLibrary(string testLibraryPath)
        {
            if (!File.Exists(testLibraryPath))
            {
                throw new ArgumentException($"{testLibraryPath} doesn't exist.");
            }

            ////var ext = new List<string> { "js" };
            var specFiles = Directory.GetFiles(new FileInfo(testLibraryPath).Directory.FullName, "*.js", SearchOption.TopDirectoryOnly);
            var testCases = new List<TestCase>();

            foreach (var specFile in specFiles)
            {
                string fileContent = File.ReadAllText(specFile);
                List<string> itNames = Regex.Matches(fileContent, ItNamePattern, RegexOptions.IgnoreCase)
                                            .Cast<Match>()
                                            .Where(m => m.Groups.Count > 5)
                                            .Select(match => match.Groups[4].Value)
                                            .ToList();
                foreach (var itName in itNames)
                {
                    testCases.Add(new TestCase(itName, specFile));
                }
            }

            return testCases;
        }
    }
}