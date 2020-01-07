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
using System.IO;
using System.Threading.Tasks;
using Meissa.Server.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Meissa.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("MEISSA Server has been started and listens on http://localhost:5000/.");
            var webHost = CreateHostBuilder(args).Build();
            webHost.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                    .ConfigureWebHostDefaults(webBuilder =>
                    {
                        webBuilder.ConfigureKestrel(serverOptions =>
                        {
                            serverOptions.Limits.MaxConcurrentConnections = 10000;
                            serverOptions.Limits.MaxConcurrentUpgradedConnections = 1000;
                            serverOptions.Limits.KeepAliveTimeout = TimeSpan.FromSeconds(30);
                            serverOptions.Limits.MaxRequestBodySize = 500000 * 1024;
                            serverOptions.Limits.MinRequestBodyDataRate =
                                new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(30));
                            serverOptions.Limits.MinResponseDataRate =
                                new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(30));
                        })
                        .UseContentRoot(Directory.GetCurrentDirectory())
                        .UseIISIntegration()
                        .ConfigureAppConfiguration((hostingContext, c) =>
                        {
                            var env = hostingContext.HostingEnvironment;
                            c.AddJsonFile("api-appsettings.json", optional: true, reloadOnChange: true)
                                .AddJsonFile($"api-appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true);
                        })
                        .ConfigureLogging((hostingContext, logging) =>
                        {
                            logging.AddConfiguration(hostingContext.Configuration.GetSection("logging"));
                            logging.AddConsole();
                            logging.AddDebug();
                            logging.SetMinimumLevel(LogLevel.Error);
                        })
                        .UseStartup<Startup>();
                    }).ConfigureServices(services =>
                    {
                        services.AddHostedService<TimedHostedService>();
                    });
        }
    }
}
