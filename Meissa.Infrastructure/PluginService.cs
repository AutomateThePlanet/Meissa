// <copyright file="PluginService.cs" company="Automate The Planet Ltd.">
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
using System.Composition.Hosting;
using System.Linq;
using System.Reflection;
using Meissa.Core.Contracts;
using Meissa.Plugins.Contracts;

namespace Meissa.Infrastructure
{
    public class PluginService : IPluginService
    {
        private readonly IPathProvider _pathProvider;
        private readonly IReflectionProvider _reflectionProvider;
        private readonly IDirectoryProvider _directoryProvider;
        private readonly IAssemblyProvider _assemblyProvider;

        public PluginService(IPathProvider pathProvider, IReflectionProvider reflectionProvider, IDirectoryProvider directoryProvider, IAssemblyProvider assemblyProvider)
        {
            _pathProvider = pathProvider;
            _reflectionProvider = reflectionProvider;
            _directoryProvider = directoryProvider;
            _assemblyProvider = assemblyProvider;
        }

        public void ExecuteAllTestRunnerPluginsPreTestRunLogic()
        {
            var testRunnerPlugins = LoadTestRunnerPluginServices();
            if (testRunnerPlugins != null && testRunnerPlugins.Any())
            {
                foreach (var testRunnerPlugin in testRunnerPlugins)
                {
                    testRunnerPlugin.ExecutePreTestRunLogic();
                }
            }
        }

        public void ExecuteAllTestRunnerPluginsPostTestRunLogic()
        {
            var testRunnerPlugins = LoadTestRunnerPluginServices();
            if (testRunnerPlugins != null && testRunnerPlugins.Any())
            {
                foreach (var testRunnerPlugin in testRunnerPlugins)
                {
                    testRunnerPlugin.ExecutePostTestRunLogic();
                }
            }
        }

        public void ExecuteAllTestAgentPluginsPreTestRunLogic()
        {
            var testAgentPlugins = LoadTestAgentPluginServices();
            if (testAgentPlugins != null && testAgentPlugins.Any())
            {
                foreach (var testRunnerPlugin in testAgentPlugins)
                {
                    testRunnerPlugin.ExecutePreTestRunLogic();
                }
            }
        }

        public void ExecuteAllTestAgentPluginsPostTestRunLogic()
        {
            var testAgentPlugins = LoadTestAgentPluginServices();
            if (testAgentPlugins != null && testAgentPlugins.Any())
            {
                foreach (var testRunnerPlugin in testAgentPlugins)
                {
                    testRunnerPlugin.ExecutePostTestRunLogic();
                }
            }
        }

        public void ExecuteAllTestAgentPluginsAbortTestRunLogic()
        {
            var testAgentPlugins = LoadTestAgentPluginServices();
            if (testAgentPlugins != null && testAgentPlugins.Any())
            {
                foreach (var testRunnerPlugin in testAgentPlugins)
                {
                    testRunnerPlugin.ExecuteAbortTestRunLogic();
                }
            }
        }

        public INativeTestsRunnerPluginService GetNativeTestRunnerService(string name)
        {
            var testAgentPlugins = LoadNativeTestsRunnerPluginServices();
            if (testAgentPlugins == null || !testAgentPlugins.Any(x => x.Name.Equals(name)))
            {
                throw new ArgumentException($"There are no native test runners with name = '{name}'");
            }

            return testAgentPlugins.FirstOrDefault(x => x.Name.Equals(name));
        }

        public INativeTestsRunnerTestCasesPluginService GetNativeTestsRunnerTestCasesPluginService(string name)
        {
            var testAgentPlugins = LoadNativeTestsRunnerTestCasesPluginServices();
            if (testAgentPlugins == null || !testAgentPlugins.Any(x => x.Name.Equals(name)))
            {
                throw new ArgumentException($"There are no native test runners test cases services with name = '{name}'");
            }

            return testAgentPlugins.FirstOrDefault(x => x.Name.Equals(name));
        }

        private IEnumerable<INativeTestsRunnerTestCasesPluginService> LoadNativeTestsRunnerTestCasesPluginServices() => LoadPlugins<INativeTestsRunnerTestCasesPluginService>();

        private IEnumerable<INativeTestsRunnerPluginService> LoadNativeTestsRunnerPluginServices() => LoadPlugins<INativeTestsRunnerPluginService>();

        private IEnumerable<ITestAgentPluginService> LoadTestAgentPluginServices() => LoadPlugins<ITestAgentPluginService>();

        private IEnumerable<ITestRunnerPluginService> LoadTestRunnerPluginServices() => LoadPlugins<ITestRunnerPluginService>();

        private IEnumerable<TPluginService> LoadPlugins<TPluginService>()
        {
            string path = _pathProvider.Combine(_reflectionProvider.GetRunningAssemblyPath(), "Plugins");

            if (!_directoryProvider.Exists(path))
            {
                _directoryProvider.CreateDirectory(path);
            }

            var allAssemblies = new List<Assembly>();

            foreach (string dll in _directoryProvider.GetFiles(path, "*.dll"))
            {
                allAssemblies.Add(_assemblyProvider.LoadFile(dll));
            }

            var configuration = new ContainerConfiguration().WithAssemblies(allAssemblies);
            var container = configuration.CreateContainer();
            var services = container.GetExports<TPluginService>();

            return services;
        }
    }
}
