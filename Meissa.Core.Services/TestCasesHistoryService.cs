// <copyright file="TestCasesHistoryService.cs" company="Automate The Planet Ltd.">
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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meissa.Core.Contracts;
using Meissa.Core.Model;
using Meissa.Model;

namespace Meissa.Core.Services
{
    public class TestCasesHistoryService : ITestCasesHistoryService
    {
        private readonly IServiceClient<TestCaseHistoryDto> _testCaseHistoryRepository;
        private readonly ITestCaseRunsServiceClient _testCaseRunsServiceClient;

        public TestCasesHistoryService(
            IServiceClient<TestCaseHistoryDto> testCaseHistoryRepository, ITestCaseRunsServiceClient testCaseRunsServiceClient)
        {
            _testCaseHistoryRepository = testCaseHistoryRepository;
            _testCaseRunsServiceClient = testCaseRunsServiceClient;
        }

        public async Task<List<ExecutedTestCase>> GetExecutedTestCasesAsync(List<TestCase> testCasesToBeExecuted)
        {
            var executedTestCases = new List<ExecutedTestCase>();
            var testCasesHistory = await _testCaseHistoryRepository.GetAllAsync();
            foreach (var testCase in testCasesToBeExecuted)
            {
                if (testCasesHistory.Any(x => x.FullName.Equals(testCase.FullName)))
                {
                    var currentHistoryTestCase = testCasesHistory.FirstOrDefault(x => x.FullName.Equals(testCase.FullName));
                    executedTestCases.Add(new ExecutedTestCase(testCase, currentHistoryTestCase.AvgDuration));
                }
                else
                {
                    executedTestCases.Add(new ExecutedTestCase(testCase));
                }
            }

            return executedTestCases;
        }

        public async Task DeleteOlderTestCasesHistoryAsync() => await _testCaseRunsServiceClient.DeleteOlderTestCasesHistoryAsync();

        public async Task UpdateTestCaseExecutionHistoryAsync(List<TestCaseRun> testCaseRuns)
        {
            await _testCaseRunsServiceClient.UpdateTestCaseExecutionHistoryAsync(testCaseRuns);
        }
    }
}
