// <copyright file="TimedHostedService.cs" company="Automate The Planet Ltd.">
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
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Meissa.Server.Services;

public class TimedHostedService : BackgroundService
{
    private const int TestCaseHistoryUpdatePeriodMilliseconds = 60000;
    private readonly IServiceProvider _serviceScopeFactory;
    private bool _areTestCasesLoaded;

    public TimedHostedService(IServiceProvider serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var testCasesPersistsService = scope.ServiceProvider.GetRequiredService<TestCasesPersistsService>();
                if (!_areTestCasesLoaded)
                {
                    await testCasesPersistsService.LoadTestCaseHistoryCollectionAsync().ConfigureAwait(false);
                    _areTestCasesLoaded = true;
                }

                await testCasesPersistsService.PersistsHistoryToFileAsync().ConfigureAwait(false);
            }

            await Task.Delay(TestCaseHistoryUpdatePeriodMilliseconds, stoppingToken).ConfigureAwait(false);
        }
    }
}
