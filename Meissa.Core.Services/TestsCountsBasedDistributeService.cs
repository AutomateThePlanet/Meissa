﻿// <copyright file="TestsCountsBasedDistributeService.cs" company="Automate The Planet Ltd.">
// Copyright 2024 Automate The Planet Ltd.
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
using System.Linq;
using Meissa.Core.Contracts;
using Meissa.Core.Model;

namespace Meissa.Core.Services;

public class TestsCountsBasedCountsBasedDistributeService : ITestsCountsBasedDistributeService
{
    private readonly IJsonSerializer _jsonSerializer;

    public TestsCountsBasedCountsBasedDistributeService(IJsonSerializer jsonSerializer) => _jsonSerializer = jsonSerializer;

    public List<List<TestCase>> GenerateDistributionTestCasesLists(int testAgentsCount, bool sameMachineByClass, List<TestCase> testCasesToBeDistributed)
    {
        if (testAgentsCount <= 0)
        {
            throw new ArgumentException("Test Agents Count Must be Greater Than 0.");
        }

        var orderedByClassTestCases = testCasesToBeDistributed.OrderBy(x => x.ClassName).ToList();
        var numberOfTestsPerList = (int)Math.Ceiling(orderedByClassTestCases.Count / (double)testAgentsCount);

        var distributedTestCases = new List<List<TestCase>>();
        if (numberOfTestsPerList > 0)
        {
            var distributedIndex = 0;
            var tempDistributedTestsCount = numberOfTestsPerList;
            string previousClass = null;
            bool isListReset = false;
            for (var i = 0; i < orderedByClassTestCases.Count; i++)
            {
                bool shouldResetTestsPerList = ShouldResetTestsPerList(sameMachineByClass, orderedByClassTestCases[i].ClassName, previousClass);
                if (!isListReset && shouldResetTestsPerList)
                {
                    isListReset = true;
                }

                if (tempDistributedTestsCount <= 0 && isListReset)
                {
                    tempDistributedTestsCount = numberOfTestsPerList;
                    distributedIndex++;
                    isListReset = false;
                }

                if (tempDistributedTestsCount == numberOfTestsPerList)
                {
                    distributedTestCases.Add(new List<TestCase>());
                }

                distributedTestCases[distributedIndex].Add(orderedByClassTestCases[i]);
                previousClass = orderedByClassTestCases[i].ClassName;

                tempDistributedTestsCount--;
            }
        }
        else
        {
            distributedTestCases.Add(testCasesToBeDistributed);
        }

        return distributedTestCases;
    }

    private static bool ShouldResetTestsPerList(bool sameMachineByClass, string currentClass, string previousClass)
        => !sameMachineByClass || previousClass != currentClass;

    public List<string> GenerateDistributionLists(int testAgentsCount, bool sameMachineByClass, List<TestCase> testCasesToBeDistributed)
    {
        if (testAgentsCount <= 0)
        {
            throw new ArgumentException("Test Agents Count Must be Greater Than 0.");
        }

        var distributedTestCases = GenerateDistributionTestCasesLists(testAgentsCount, sameMachineByClass, testCasesToBeDistributed);

        var distributedTestsLists = new List<string>();
        foreach (var currentList in distributedTestCases)
        {
            distributedTestsLists.Add(_jsonSerializer.Serialize(currentList));
        }

        return distributedTestsLists;
    }
}