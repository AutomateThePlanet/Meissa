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
using System.Linq;
using System.Reflection;
using Meissa.Core.Model;
using Meissa.Plugins.Contracts;
using Mono.Cecil;
using Mono.Cecil.Rocks;

namespace Meissa.Plugins.MSTest
{
    [Export(typeof(INativeTestsRunnerTestCasesPluginService))]
    public class NativeTestsRunnerTestCasesPluginService : INativeTestsRunnerTestCasesPluginService
    {
        private const string MsTestCategoryAttributeName = "Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute";
        private const string MsTestClassAttributeName = "Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute";
        private const string MsTestTestAttributeName = "Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute";
        private const string MsCodedUITestClassAttributeName = "Microsoft.VisualStudio.TestTools.UITesting.CodedUITestAttribute"; // search codded UI tests

        public string Name => "MSTest";

        public List<TestCase> ExtractAllTestCasesFromTestLibrary(string testLibraryPath)
        {
            var module = ModuleDefinition.ReadModule(testLibraryPath);
            var testCases = new List<TestCase>();

            foreach (var currentType in module.GetTypes())
            {
                if (currentType.CustomAttributes.Any(x => x.AttributeType.FullName.ToString().Contains(MsTestClassAttributeName) || x.AttributeType.FullName.ToString().Contains(MsCodedUITestClassAttributeName)))
                {
                    // This is a Nunit test class - create new test suite for it.
                    ////var currentTestSuite = CreateTestSuite(currentType);

                    foreach (var currentMethod in currentType.GetMethods())
                    {
                        if (currentMethod.CustomAttributes.Any(x => x.GetType().FullName.Equals(MsTestTestAttributeName)))
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

        private TestCase CreateTestCase(MethodDefinition testMethod)
        {
            var testCase = new TestCase
            {
                FullName = string.Concat(testMethod?.DeclaringType?.FullName, ".", testMethod.Name),
                ClassName = testMethod.DeclaringType.FullName,
            };
            var testCaseCategoryAttributes = testMethod.CustomAttributes.Where(x => x.GetType().FullName.Contains(MsTestCategoryAttributeName));
            testCase.Categories = GetCategoryNamesFromAttributes(testCaseCategoryAttributes);

            return testCase;
        }

        private List<string> GetCategoryNamesFromAttributes(IEnumerable<CustomAttribute> attributes)
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
    }
}