// <copyright file="RunnerModeOptions.cs" company="Automate The Planet Ltd.">
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
using CommandLine;

namespace Meissa
{
    [Verb("runner", HelpText = "Executes Meissa in --runner mode. You need to pass all native runner arguments using the argument nativeRunnerArguments.")]
    public class RunnerModeOptions
    {
        [Option("outputFilesLocation", Required = true, HelpText = "The folder where all test lib files should be present prior the tests run.")]
        public string OutputFilesLocation { get; set; }

        [Option("resultsFilePath", Required = true, HelpText = "The path to the file where all results will be stored.")]
        public string ResultsFilePath { get; set; }

        [Option('l', "testLibraryPath", Required = true, HelpText = "The path to the tests' library file.")]
        public string TestLibraryPath { get; set; }

        [Option('t', "agentTag", Required = true, HelpText = "The test agents' tag used to filter the machines where the tests will be executed.")]
        public string AgentTag { get; set; }

        [Option("testTechnology", HelpText = "The tests technology that will be used to execute the tests- MSTest, NUnit, etc.")]
        public string TestTechnology { get; set; } = "MSTest";

        [Option('n', "nativeRunnerArguments", HelpText = "The native runner arguments that we use in addition to Meissa arguments. (e.g. MSTest /nologo argument).")]
        public string NativeArguments { get; set; }

        [Option('u', "testServerUrl", HelpText = "The test server URL with port that will be used by the test agents and runners to communicate between the machines.")]
        public string TestServerUrl { get; set; }

        [Option('t', "testRunTimeout", HelpText = "The time in minutes after which the test run will be stopped.")]
        public int TestRunTimeout { get; set; } = 300;

        [Option('f', "testsFilter", HelpText = "The filter that will be applied to the whole set of tests.")]
        public string TestsFilter { get; set; }

        [Option('p', "runInParallel", HelpText = "Specifies whether the tests will be run in parallel on the test agent machine.")]
        public bool RunInParallel { get; set; }

        [Option('m', "maxParallelProcessesCount", HelpText = "Specifies the maximum count of parallel test run processes. The default one is equal to the machines' CPU cores count.")]
        public int MaxParallelProcessesCount { get; set; } = Environment.ProcessorCount;

        [Option("timeBasedBalance", HelpText = "Specifies whether the tests will be distributed based on previous execution times.")]
        public bool TimeBasedBalance { get; set; }

        [Option("sameMachineByClass", HelpText = "Specifies whether the tests from the same class will be executed on the same machine. The default is false.")]
        public bool SameMachineByClass { get; set; } = false;

        [Option("customArguments", HelpText = "Key value pairs. The first parameter will be the name of the environment variable holding the second one as value.")]
        public IEnumerable<string> CustomArguments { get; set; }

        [Option("retriesCount", HelpText = "How many times the failed tests will be retried.")]
        public int RetriesCount { get; set; } = 0;

        [Option("threshold", HelpText = "If the percentage of the failed tests is bigger than the specified threshold %, no next reruns will be performed.")]
        public double Threshold { get; set; } = 0;

        [Option("retriedResultsFilePath", HelpText = "The path to the file where all retied results will be stored.")]
        public string RetriedResultsFilePath { get; set; }
    }
}