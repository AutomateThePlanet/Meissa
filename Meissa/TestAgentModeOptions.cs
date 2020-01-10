// <copyright file="TestAgentModeOptions.cs" company="Automate The Planet Ltd.">
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
    [Verb("agent", HelpText = "Executes Meissa in --testAgent mode. When Meissa is started in this mode it will wait for test run commands from test runners connected to the same test execution server.")]
    public class TestAgentModeOptions
    {
        [Option('u', "server", HelpText = "The test server URL with port that will be used by the test agents and runners to communicate between the machines.")]
        public string ServerUrl { get; set; }

        [Option('t', "tag", Required = true, HelpText = "The tag will be used to control the test agent remotely and to build a group of test agents. This way you will be able to run a specific set of tests to a group of your test agents.")]
        public string AgentTag { get; set; }

        [Option('r', "runTimeout", HelpText = "The time in minutes after which the test agent run will be stopped.")]
        public int TestAgentRunTimeout { get; set; } = 180;

        [Option("restarted", HelpText = "Used for internal purposes only.")]
        public bool Restarted { get; set; }
    }
}