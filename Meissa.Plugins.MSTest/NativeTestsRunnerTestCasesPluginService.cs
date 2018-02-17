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
// <site>https://automatetheplanet.com/</site>
using System;
using System.Collections.Generic;
using System.Composition;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Meissa.API.Models;
using Meissa.Core.Model;
using Meissa.Plugins.Contracts;

namespace Meissa.Plugins.MSTest
{
    [Export(typeof(INativeTestsRunnerTestCasesPluginService))]
    public class NativeTestsRunnerTestCasesPluginService : INativeTestsRunnerTestCasesPluginService
    {
        private const string MsTestCategoryAttributeName = "Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute";
        private const string MsTestClassAttributeName = "Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute";
        private const string MsTestTestAttributeName = "Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute";

        public string Name => "MSTestCore";

        public List<TestCase> ExtractAllTestCasesFromTestLibrary(string testLibraryPath)
        {
            var assembly = GetAssemblyFromFile(testLibraryPath);
            var testCases = new List<TestCase>();

            foreach (var currentType in assembly.GetTypes())
            {
                if (currentType.GetCustomAttributesData().Any(x => x.ToString().Contains(MsTestClassAttributeName)))
                {
                    // This is a Nunit test class - create new test suite for it.
                    ////var currentTestSuite = CreateTestSuite(currentType);

                    foreach (var currentMethod in currentType.GetMethods())
                    {
                        if (currentMethod.GetCustomAttributes().Any(x => x.GetType().FullName.Equals(MsTestTestAttributeName)))
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
            var testCaseCategoryAttributes = testMethod.GetCustomAttributes().Where(x => x.GetType().FullName.Equals(MsTestCategoryAttributeName));
            testCase.Categories = GetCategoryNamesFromAttributes(testCaseCategoryAttributes);

            return testCase;
        }

        private List<string> GetCategoryNamesFromAttributes(IEnumerable<Attribute> attributes)
        {
            var categoryNames = new List<string>();
            if (attributes != null)
            {
                foreach (var categoryAttribute in attributes)
                {
                    var testCategories = categoryAttribute.GetType().GetProperty("TestCategories").GetValue(categoryAttribute, null);
                    if (testCategories != null && ((List<string>)testCategories).Any())
                    {
                        categoryNames.AddRange((List<string>)testCategories);
                    }
                }
            }

            return categoryNames;
        }

        private Assembly GetAssemblyFromFile(string fullFilePath)
        {
            var assembly = Assembly.LoadFrom(fullFilePath);

            return assembly;
        }
    }
}