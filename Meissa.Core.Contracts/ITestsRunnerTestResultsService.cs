// <copyright file="ITestsRunnerTestResultsService.cs" company="Automate The Planet Ltd.">
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
using System.Threading.Tasks;
using Meissa.Core.Model;

namespace Meissa.Core.Contracts
{
    public interface ITestsRunnerTestResultsService
    {
        Task SaveTestResultsForCurrentRunAsync(string testTechnology, string testResultsFilePath, string retriedResultsFilePath, Guid testRunId);

        List<TestCase> GetAllPassesTests(string testTechnology, string testResultsFileContent);

        List<TestCase> GetAllNotPassedTests(string testTechnology, string testResultsFilePath);

        double CalculatedFailedTestsPercentage(List<TestCase> failedTests, List<TestCase> allTests);
    }
}