// <copyright file="ConsoleArgumentsProvider.cs" company="Automate The Planet Ltd.">
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
using System;
using Fclp;
using Meissa.Core.Contracts;

namespace Meissa.Core.Services
{
    public class ConsoleArgumentsProvider : IConsoleArgumentsProvider
    {
        public string GetResultsOutputLocation(string[] arguments) => GetArgumentValueByArgumentName("resultsOutputFolder", null, arguments);

        public string GetOriginalOutputFilesLocation(string[] arguments) => GetArgumentValueByArgumentName("originalOutputFilesLocation", "You need to specify original output files location.", arguments);

        public string GetSharedOutputFilesLocation(string[] arguments) => GetArgumentValueByArgumentName("sharedOutputFilesLocation", "You need to specify shared output files location", arguments);

        public string GetTestCategories(string[] arguments) => GetArgumentValueByArgumentName("testCategories", null, arguments);

        public string GetTestResultsPath(string[] arguments) => GetArgumentValueByArgumentName("resultsFolder", "You need to specify path to test results.", arguments);

        public string GetTestAssemblyPath(string[] arguments) => GetArgumentValueByArgumentName("testAssembly", "You need to specify path to test assembly.", arguments);

        public string GetAgentTagName(string[] arguments) => GetArgumentValueByArgumentName("agentTag", "You need to specify agent tag.", arguments);

        private string GetArgumentValueByArgumentName(string argumentName, string exceptionMessage, string[] arguments)
        {
            var argumentValue = string.Empty;
            var commandLineParser = new FluentCommandLineParser();
            commandLineParser.Setup<string>(argumentName).Callback(s => argumentValue = s);
            commandLineParser.Parse(arguments);
            if (string.IsNullOrEmpty(argumentValue) && !string.IsNullOrEmpty(exceptionMessage))
            {
                throw new ArgumentException(exceptionMessage);
            }

            return argumentValue;
        }
    }
}