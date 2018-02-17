// <copyright file="Startup.cs" company="Automate The Planet Ltd.">
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
using Meissa.API.Models;
using Meissa.API.Services;
using Meissa.Infrastructure;
using Meissa.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Meissa.API
{
    public class Startup
    {
        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
                .AddMvcOptions(o => o.OutputFormatters.Add(
                    new XmlDataContractSerializerOutputFormatter()));

            services.AddDbContext<TestsRunsContext>(options =>
            {
                options.UseSqlite("Data Source=meissa.db");
                ////options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
            services.AddScoped<DbRepository<TestsRunsContext>, MeissaRepository>();
            services.AddScoped<MeissaRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseStatusCodePages();

            AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TestRun, TestRunDto>();
                cfg.CreateMap<TestAgent, TestAgentDto>();
                cfg.CreateMap<TestAgentRun, TestAgentRunDto>();
                cfg.CreateMap<TestRunLog, TestRunLogDto>();
                cfg.CreateMap<Log, LogDto>();
                cfg.CreateMap<TestRunCustomArgument, TestRunCustomArgumentDto>();
                cfg.CreateMap<TestCaseHistory, TestCaseHistoryDto>();
                cfg.CreateMap<TestCaseHistoryEntry, TestCaseHistoryEntryDto>();
                cfg.CreateMap<TestRunOutput, TestRunOutputDto>();
                cfg.CreateMap<TestAgentRunAvailability, TestAgentRunAvailabilityDto>();
                cfg.CreateMap<TestRunAvailability, TestRunAvailabilityDto>();

                cfg.CreateMap<TestRunDto, TestRun>();
                cfg.CreateMap<TestAgentDto, TestAgent>();
                cfg.CreateMap<TestAgentRunDto, TestAgentRun>();
                cfg.CreateMap<TestRunLogDto, TestRunLog>();
                cfg.CreateMap<LogDto, Log>();
                cfg.CreateMap<TestRunCustomArgumentDto, TestRunCustomArgument>();
                cfg.CreateMap<TestCaseHistoryEntryDto, TestCaseHistoryEntry>();
                cfg.CreateMap<TestCaseHistoryDto, TestCaseHistory>();
                cfg.CreateMap<TestRunOutputDto, TestRunOutput>();
                cfg.CreateMap<TestAgentRunAvailabilityDto, TestAgentRunAvailability>();
                cfg.CreateMap<TestRunAvailabilityDto, TestRunAvailability>();
            });

            app.UseMvc();
        }
    }
}
