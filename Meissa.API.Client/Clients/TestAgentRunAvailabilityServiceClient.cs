// <copyright file="TestAgentRunAvailabilityServiceClient.cs" company="Automate The Planet Ltd.">
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
    public class TestAgentRunAvailabilityServiceClient : RestClientRepository<TestAgentRunAvailabilityDto>, ITestAgentRunAvailabilityServiceClient
    {
        public TestAgentRunAvailabilityServiceClient(string ip, int port)
            : base(ip, port, "testAgentRunAvailabilities")
        {
        }

        public async Task<TestAgentRunAvailabilityDto> GetLastTestAgentRunAvailabilityForTestRun(int id)
        {
            if (HttpClientService.Client.BaseAddress == null)
            {
                HttpClientService.Client.BaseAddress = new Uri(BaseUrl);
            }

            var entity = default(TestAgentRunAvailabilityDto);
            string jsonToBeCreated = JsonConvert.SerializeObject(id);
            var httpContent = new StringContent(jsonToBeCreated, Encoding.UTF8, AppJson);

            var response = await HttpClientService.Client.SendAsyncWithRetry(() => new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{BaseUrl}{ControllerUrl}/testAgentRun"),
                Content = httpContent,
            },
            5,
            2000);
            entity = await DeserializeResponse<TestAgentRunAvailabilityDto>(response);

            return entity;
        }
    }
}