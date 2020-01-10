// <copyright file="StatusModeOptions.cs" company="Automate The Planet Ltd.">
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
using CommandLine;

namespace Meissa
{
    [Verb("status", HelpText = "Displays the status of the test agents with a specific tag.")]
    public class StatusModeOptions
    {
        [Option('t', "tag", Required = true, HelpText = "The status of the test agents with this tag will be displayed.")]
        public string AgentTag { get; set; }

        [Option('u', "server", HelpText = "The test server URL with port that will be used by the test agents and runners to communicate between the machines.")]
        public string ServerUrl { get; set; }
    }
}