// <copyright file="TestCaseRunsServiceClient.cs" company="Automate The Planet Ltd.">
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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Meissa.Core.Contracts;
using Meissa.Core.Model;
using Newtonsoft.Json;

namespace Meissa.API.Client.Clients
{
    public class TestCaseRunsServiceClient : ITestCaseRunsServiceClient
    {
        private const string AppJson = "application/json";
        private readonly string _baseUrl;
        private readonly string _controllerUrlPart;
        private string _controllerUrl => $"api/{_controllerUrlPart}";

        public TestCaseRunsServiceClient(string ip, int port)
        {
            _baseUrl = $"http://{ip}:{port}/";
            _controllerUrlPart = "testcaseruns";
        }

        public async Task UpdateTestCaseExecutionHistoryAsync(List<TestCaseRun> testCaseRuns)
        {
            if (HttpClientService.Client.BaseAddress == null)
            {
                HttpClientService.Client.BaseAddress = new Uri(_baseUrl);
            }

            string jsonToBeUpdated = JsonConvert.SerializeObject(testCaseRuns);
            var httpContent = new StringContent(jsonToBeUpdated, Encoding.UTF8, AppJson);

            var response = await HttpClientService.Client.SendAsyncWithRetry(() => new HttpRequestMessage
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"{_baseUrl}{_controllerUrl}"),
                Content = httpContent,
            },
            5,
            2000);
        }

        public async Task DeleteOlderTestCasesHistoryAsync()
        {
            if (HttpClientService.Client.BaseAddress == null)
            {
                HttpClientService.Client.BaseAddress = new Uri(_baseUrl);
            }

            var response = await HttpClientService.Client.SendAsyncWithRetry(() => new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"{_baseUrl}{_controllerUrl}"),
            },
            5,
            2000);
        }
    }
}