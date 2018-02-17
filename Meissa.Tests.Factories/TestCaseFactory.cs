// <copyright file="TestCaseFactory.cs" company="Automate The Planet Ltd.">
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
using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Meissa.Core.Model;

namespace Meissa.Tests.Factories
{
    public static class TestCaseFactory
    {
        private static string singleMachineTestCaseCategory = "CI";

        public static List<TestCase> CreateMany()
        {
            var fixture = FixtureFactory.Create();

            var result = fixture.CreateMany<TestCase>();

            return result.ToList();
        }

        public static List<TestCase> CreateMany(string testCaseCategoryName)
        {
            var testCaseCategories = new List<string> { testCaseCategoryName };
            var fixture = FixtureFactory.Create();
            fixture.Customize<TestCase>(tc => tc.With(x => x.Categories, testCaseCategories));

            var result = fixture.CreateMany<TestCase>();

            return result.ToList();
        }

        public static List<TestCase> CreateMany(List<string> testCaseCategoryNames)
        {
            var fixture = FixtureFactory.Create();
            fixture.Customize<TestCase>(tc => tc.With(x => x.Categories, testCaseCategoryNames));

            var result = fixture.CreateMany<TestCase>();

            return result.ToList();
        }

        public static List<TestCase> CreateSingleWithOneTestCase(string testCaseCategoryName)
        {
            var testCaseCategories = new List<string> { testCaseCategoryName };
            var fixture = FixtureFactory.Create();
            fixture.Customize<TestCase>(tc => tc.With(x => x.Categories, testCaseCategories));

            var result = fixture.CreateMany<TestCase>(1);

            return result.ToList();
        }

        public static List<TestCase> CreateSingleWithTestCases(int testCasesCount)
        {
            var fixture = FixtureFactory.Create();

            var result = fixture.CreateMany<TestCase>(1);

            return result.ToList();
        }

        public static List<TestCase> CreateSingleWithManyTestCasesOnlyOneTestCaseWithCategory(string testCaseCategoryName)
        {
            var testCaseCategories = new List<string> { testCaseCategoryName };
            var fixture = FixtureFactory.Create();
            fixture.Customize<TestCase>(tc => tc.With(x => x.Categories, testCaseCategories));

            var result = fixture.CreateMany<TestCase>(1);

            return result.ToList();
        }

        public static List<TestCase> CreateManyWithSingleMachineCategory(int testCasesCount)
        {
            var fixture = FixtureFactory.Create();
            var testCaseCategories = fixture.CreateMany<string>().ToList();
            testCaseCategories.Add(singleMachineTestCaseCategory);

            fixture.Customize<TestCase>(ts => ts.With(x => x.Categories, testCaseCategories));

            var result = fixture.CreateMany<TestCase>(testCasesCount);

            return result.ToList();
        }
    }
}