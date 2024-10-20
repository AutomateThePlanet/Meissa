// <copyright file="Program.cs" company="Automate The Planet Ltd.">
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
using System.IO;
using Meissa.Server.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Meissa.Server;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("MEISSA Server has been started and listens on http://localhost:89/.");
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
                        serverOptions.Limits.MaxConcurrentConnections = null;
                        serverOptions.Limits.MaxConcurrentUpgradedConnections = null;
                        serverOptions.Limits.KeepAliveTimeout = TimeSpan.FromSeconds(180);
                        serverOptions.Limits.MaxRequestBodySize = null;
                        serverOptions.Limits.MinRequestBodyDataRate = null;
                        serverOptions.Limits.MinResponseDataRate = null;
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
                    .UseUrls("http://0.0.0.0:89")
                    .UseStartup<Startup>()
                   ;
                }).ConfigureServices(services =>
                {
                    services.AddHostedService<TimedHostedService>();
                });
    }
}
