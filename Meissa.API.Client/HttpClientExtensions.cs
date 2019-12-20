// <copyright file="HttpClientExtensions.cs" company="Automate The Planet Ltd.">
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
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Meissa.API.Client
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> SendAsyncWithRetry(this HttpClient client, Func<HttpRequestMessage> createRequest, int retriesCount = 3, int sleepIntervalMilliseconds = 1000)
        {
            var response = default(HttpResponseMessage);
            for (int i = 0; i < retriesCount; i++)
            {
                var request = createRequest();
                try
                {
                    response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        if (i > 0)
                        {
                            // DEBUG:
                            ////Console.WriteLine($"SendAsyncWithRetry- URI: {request.RequestUri} TYPE: {request.Method} - TRY {i + 1} SUCCESS");
                        }

                        return response;
                    }
                    else
                    {
                        // DEBUG:
                        ////Console.WriteLine($"The retried request was not successful- {response.Content} URI: {request.RequestUri} TYPE: {request.Method}");
                        Thread.Sleep(sleepIntervalMilliseconds);
                    }
                }
                catch (HttpRequestException e) when (e.InnerException.Message.Contains("A connection with the server could not be established"))
                {
                    if (i == retriesCount - 1)
                    {
                        throw;
                    }

                    Thread.Sleep(sleepIntervalMilliseconds);
                }
                catch (Exception)
                {
                    // DEBUG:
                    ////Console.WriteLine($"EXCEPTION SendAsyncWithRetry- {response?.Content} URI: {request.RequestUri} TYPE: {request.Method} - TRY {i + 1}");
                    ////Console.WriteLine($"EXCEPTION SendAsyncWithRetry- {e}");
                    Thread.Sleep(sleepIntervalMilliseconds);
                }
            }

            return response;
        }
    }
}
