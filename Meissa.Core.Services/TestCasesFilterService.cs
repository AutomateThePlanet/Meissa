// <copyright file="TestCasesFilterService.cs" company="Automate The Planet Ltd.">
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
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using Meissa.Core.Contracts;
using Meissa.Core.Model;

namespace Meissa.Core.Services
{
    public class TestCasesFilterService : ITestCasesFilterService
    {
        public List<TestCase> FilterCases(List<TestCase> testCasesToBeFiltered, string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return testCasesToBeFiltered;
            }

            var filteredTestCases = new List<TestCase>();
            var parameter = Expression.Parameter(typeof(TestCase), "test");
            var lambdaExpression = DynamicExpressionParser.ParseLambda(new[] { parameter }, null, filter);
            foreach (var testCase in testCasesToBeFiltered)
            {
                bool shouldAdd = (bool)lambdaExpression.Compile().DynamicInvoke(testCase);
                if (shouldAdd)
                {
                    filteredTestCases.Add(testCase);
                }
            }

            return filteredTestCases;
        }
    }
}