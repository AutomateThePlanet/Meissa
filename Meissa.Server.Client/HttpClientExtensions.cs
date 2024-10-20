// <copyright file="HttpClientExtensions.cs" company="Automate The Planet Ltd.">
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
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Meissa.Server.Client;

public static class HttpClientExtensions
{
    public static async Task<HttpResponseMessage> SendAsyncWithRetry(this HttpClient client, Func<HttpRequestMessage> createRequest, int retriesCount = 3, int sleepIntervalMilliseconds = 500)
    {
        var response = default(HttpResponseMessage);
        for (int i = 0; i < retriesCount; i++)
        {
            var request = createRequest();
            try
            {
                response = await client.SendAsync(request).ConfigureAwait(false);

                if (response.IsSuccessStatusCode)
                {
                    return response;
                }

                Thread.Sleep(sleepIntervalMilliseconds);
            }
            catch (HttpRequestException e) when (e.InnerException != null && e.InnerException.Message.Contains("A connection with the server could not be established"))
            {
                if (i == retriesCount - 1)
                {
                    throw;
                }

                Console.WriteLine(e.ToString());
                Thread.Sleep(sleepIntervalMilliseconds);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                Thread.Sleep(sleepIntervalMilliseconds);
            }
        }

        return response;
    }
}