// <copyright file="TestRunOutputServiceClient.cs" company="Automate The Planet Ltd.">
// Copyright 2020 Automate The Planet Ltd.
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
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Meissa.Core.Contracts;
using Meissa.Model;
using Newtonsoft.Json;

namespace Meissa.Server.Client.Clients
{
    public class TestRunOutputServiceClient : RestClientRepository<TestRunOutputDto>, ITestRunOutputServiceClient
    {
        public TestRunOutputServiceClient(string ip, int port)
            : base(ip, port, "testrunoutputs")
        {
        }

        public async Task DeleteAllTestRunsTestOutputFilesPackagesAsync()
        {
            if (HttpClientService.Client.BaseAddress == null)
            {
                HttpClientService.Client.BaseAddress = new Uri(BaseUrl);
            }

            await HttpClientService.Client.SendAsyncWithRetry(() =>
                    new HttpRequestMessage
                    {
                        Method = HttpMethod.Delete,
                        RequestUri = new Uri($"{BaseUrl}{ControllerUrl}/outputFiles"),
                    },
                1,
                0).ConfigureAwait(false);
        }

        public async Task DeleteTestRunOutputByTestRunIdAsync(Guid id)
        {
            if (HttpClientService.Client.BaseAddress == null)
            {
                HttpClientService.Client.BaseAddress = new Uri(BaseUrl);
            }

            var jsonToBeCreated = JsonConvert.SerializeObject(id);
            var httpContent = new StringContent(jsonToBeCreated, Encoding.UTF8, AppJson);

            await HttpClientService.Client.SendAsyncWithRetry(() =>
                    new HttpRequestMessage
                    {
                        Method = HttpMethod.Delete,
                        RequestUri = new Uri($"{BaseUrl}{ControllerUrl}/testRun"),
                        Content = httpContent,
                    },
                1,
                0).ConfigureAwait(false);
        }

        public async Task<TestRunOutputDto> GetTestRunOutputByTestRunIdAsync(Guid id)
        {
            if (HttpClientService.Client.BaseAddress == null)
            {
                HttpClientService.Client.BaseAddress = new Uri(BaseUrl);
            }

            string jsonToBeCreated = JsonConvert.SerializeObject(id);
            var httpContent = new StringContent(jsonToBeCreated, Encoding.UTF8, AppJson);

            var response = await HttpClientService.Client.SendAsyncWithRetry(() => new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"{BaseUrl}{ControllerUrl}/testRun"),
                Content = httpContent,
            },
            1,
            0).ConfigureAwait(false);
            if (response == null)
            {
                throw new InvalidDataException("The response for getting run output was null.");
            }

            var entity = await DeserializeResponse<TestRunOutputDto>(response).ConfigureAwait(false);

            return entity;
        }
    }
}