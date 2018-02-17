// <copyright file="TestRunLogServiceClient.cs" company="Automate The Planet Ltd.">
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
using Meissa.API.Models;
using Meissa.Core.Contracts;
using Newtonsoft.Json;

namespace Meissa.API.Client.Clients
{
    public class TestRunLogServiceClient : RestClientRepository<TestRunLogDto>
    {
        public TestRunLogServiceClient(string ip, int port)
            : base(ip, port, "testrunlogs")
        {
        }
    }
}