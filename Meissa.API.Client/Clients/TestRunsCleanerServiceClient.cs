// <copyright file="TestRunsCleanerServiceClient.cs" company="Automate The Planet Ltd.">
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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Meissa.API.Models;
using Meissa.Core.Contracts;
using Meissa.Model;
using Newtonsoft.Json;

namespace Meissa.API.Client.Clients
{
    public class TestRunsCleanerServiceClient : ITestRunsCleanerServiceClient
    {
        private const string AppJson = "application/json";
        private const string ControllerUrl = "api/testrunscleaner";
        private readonly string _baseUrl;

        public TestRunsCleanerServiceClient(string ip, int port) => _baseUrl = $"http://{ip}:{port}/";

        public async Task DeleteOldTestRunsDataAsync()
        {
            if (HttpClientService.Client.BaseAddress == null)
            {
                HttpClientService.Client.BaseAddress = new Uri(_baseUrl);
            }

            var response = await HttpClientService.Client.SendAsyncWithRetry(() => new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"{_baseUrl}{ControllerUrl}"),
            },
            5,
            2000);
        }

        public async Task DeleteOldTestRunDataByTestRunIdAsync(Guid id)
        {
            if (HttpClientService.Client.BaseAddress == null)
            {
                HttpClientService.Client.BaseAddress = new Uri(_baseUrl);
            }

            string jsonToBeCreated = JsonConvert.SerializeObject(id);
            var httpContent = new StringContent(jsonToBeCreated, Encoding.UTF8, AppJson);

            var response = await HttpClientService.Client.SendAsyncWithRetry(() => new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri($"{_baseUrl}{ControllerUrl}/testRun"),
                Content = httpContent,
            },
            5,
            2000);
        }
    }
}