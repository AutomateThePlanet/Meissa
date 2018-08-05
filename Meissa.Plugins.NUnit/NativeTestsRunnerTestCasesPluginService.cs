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
using System.Globalization;
using System.Linq;
using System.Reflection;
using Meissa.Core.Model;
using Meissa.Plugins.Contracts;

namespace Meissa.Plugins.NUnit
{
    [Export(typeof(INativeTestsRunnerTestCasesPluginService))]
    public class NativeTestsRunnerTestCasesPluginService : INativeTestsRunnerTestCasesPluginService
    {
        private const string NunitCategoryAttributeName = "NUnit.Framework.CategoryAttribute";
        private const string NunitTestFixtureAttributeName = "NUnit.Framework.TestFixtureAttribute";
        private const string NunitTestAttributeName = "NUnit.Framework.TestAttribute";

        public string Name => "NUnit";

        public List<TestCase> ExtractAllTestCasesFromTestLibrary(string testLibraryPath)
        {
            var assembly = GetAssemblyFromFile(testLibraryPath);
            var testCases = new List<TestCase>();

            foreach (var currentType in assembly.GetTypes())
            {
                if (currentType.GetCustomAttributes().Any(x => x.GetType().FullName.Equals(NunitTestFixtureAttributeName)))
                {
                    foreach (var currentMethod in currentType.GetMethods())
                    {
                        if (currentMethod.GetCustomAttributes().Any(x => x.GetType().FullName.Equals(NunitTestAttributeName)))
                        {
                            // This is a Nunit test - add it to the current test class list of tests.
                            var currentTestCase = CreateTestCase(currentMethod);
                            testCases.Add(currentTestCase);
                        }
                    }
                }
            }

            return testCases;
        }

        private TestCase CreateTestCase(MethodInfo testMethod)
        {
            var testCase = new TestCase
            {
                FullName = string.Concat(testMethod?.ReflectedType?.FullName, ".", testMethod.Name),
                ClassName = testMethod.DeclaringType.FullName,
            };
            var testCaseCategoryAttributes = testMethod.GetCustomAttributes().Where(x => x.GetType().FullName.Equals(NunitCategoryAttributeName));
            testCase.Categories = GetCategoryNamesFromAttributes(testCaseCategoryAttributes);

            return testCase;
        }

        private List<string> GetCategoryNamesFromAttributes(IEnumerable<Attribute> attributes)
        {
            var categoryNames = new List<string>();

            foreach (var categoryAttribute in attributes)
            {
                var currentCategoryName = categoryAttribute.GetType().GetProperty("Name").GetValue(categoryAttribute, null);
                categoryNames.Add((string)currentCategoryName);
            }

            return categoryNames;
        }

        private Assembly GetAssemblyFromFile(string fullFilePath)
        {
            CultureInfo.CurrentUICulture = new CultureInfo("en-US");
            var assembly = Assembly.LoadFrom(fullFilePath);

            return assembly;
        }
    }
}