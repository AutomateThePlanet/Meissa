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
using System.Linq;
using System.Reflection;

namespace LoadAssemblySpike
{
    public class NativeTestsRunnerTestCasesPluginService
    {
        private const string MsTestCategoryAttributeName = "Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute";
        private const string MsTestClassAttributeName = "Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute";
        private const string MsTestTestAttributeName = "Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute";

        public string Name => "MSTest";

        public void ExtractAllTestCasesFromTestLibrary(string testLibraryPath)
        {
            try
            {
                var assembly = GetAssemblyFromFile(testLibraryPath);

                foreach (var currentType in assembly.GetTypes())
                {
                    if (currentType.GetCustomAttributesData().Any(x => x.ToString().Contains(MsTestClassAttributeName)))
                    {
                        foreach (var currentMethod in currentType.GetMethods())
                        {
                            if (currentMethod.GetCustomAttributes().Any(x => x.GetType().FullName.Equals(MsTestTestAttributeName)))
                            {
                                var currentTestCase = string.Concat(currentMethod?.ReflectedType?.FullName, ".", currentMethod.Name);
                                Console.WriteLine(currentTestCase);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private Assembly GetAssemblyFromFile(string fullFilePath)
        {
            var assembly = Assembly.LoadFrom(fullFilePath);

            return assembly;
        }
    }
}