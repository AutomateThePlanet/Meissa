// <copyright file="Program.cs" company="Automate The Planet Ltd.">
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
using System.Linq;
using System.Threading.Tasks;
using Meissa.Server.Client.Clients;

namespace Meissa.Server.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Console.WriteLine("Enter controller IP: ");
            string url = Console.ReadLine();
            var client1 = new TestRunServiceClient(url, 1000);

            ////var specificRun = client1.Get(new Guid("c413e3c6-2ef7-4946-f4ee-08d51f8e4f15"));
            ////specificRun.ResultsOutputLocation = $"{specificRun.ResultsOutputLocation}Updated";
            ////client1.Update(specificRun.TestRunId, specificRun);

            var specificRun = (await client1.GetAllAsync().ConfigureAwait(false)).ToArray().First();
            Console.WriteLine(specificRun.TestAssemblyName);

            ////var newTestRun = new TestRunDto()
            ////                        {
            ////                            TestOutputLocation = "C:\\TestOutputLocation4\\",
            ////                            Status = 1,
            ////                            TestAssemblyName = "CityInfo.API4",
            ////                            ResultsOutputLocation = "C:\\ResultsOutputLocation4\\",
            ////                        };
            ////client1.Delete(new Guid("c413e3c6-2ef7-4946-f4ee-08d51f8e4f15"));
        }
    }
}
