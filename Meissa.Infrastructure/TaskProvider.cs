// <copyright file="TaskProvider.cs" company="Automate The Planet Ltd.">
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
using System.Threading;
using System.Threading.Tasks;
using Meissa.Core.Contracts;

namespace Meissa.Infrastructure
{
    public class TaskProvider : ITaskProvider
    {
        private readonly IDistributeLogger _logger;

        public TaskProvider(IDistributeLogger logger) => _logger = logger;

        public Task StartNewLongRunningRepeating(CancellationTokenSource cancellationTokenSource, Action action, int frequency)
        {
            var waitTask = Task.Factory.StartNew(
                () =>
                {
                    try
                    {
                        do
                        {
                            if (action == null)
                            {
                                return;
                            }

                            if (cancellationTokenSource.Token.IsCancellationRequested)
                            {
                                return;
                            }

                            action.Invoke();

                            if (cancellationTokenSource.Token.IsCancellationRequested)
                            {
                                return;
                            }

                            Thread.Sleep(frequency);
                        }
                        while (true);
                    }
                    catch (AggregateException aex)
                    {
                        foreach (var ex in aex.InnerExceptions)
                        {
                            Console.WriteLine(ex);
                            _logger.LogErrorAsync(ex.GetType().Name, ex).Wait();
                        }
                        ////throw;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        _logger.LogErrorAsync(ex.Message, ex).Wait();
                        ////throw;
                    }
                },
                cancellationTokenSource.Token,
                TaskCreationOptions.LongRunning,
                TaskScheduler.Default);
            return waitTask;
        }

        public Task StartNewLongRunning(Action<CancellationTokenSource> action, CancellationTokenSource cancellationTokenSource)
        {
            var waitTask = Task.Factory.StartNew(
                () =>
                {
                    try
                    {
                        action.Invoke(cancellationTokenSource);
                    }
                    catch (AggregateException aex)
                    {
                        foreach (var ex in aex.InnerExceptions)
                        {
                            _logger.LogErrorAsync(ex.GetType().Name, ex).Wait();
                        }
                        ////throw;
                    }
                    catch (Exception ex)
                    {
                        _logger.LogErrorAsync(ex.Message, ex).Wait();
                        ////throw;
                    }
                },
                cancellationTokenSource.Token,
                TaskCreationOptions.LongRunning,
                TaskScheduler.Default);
            return waitTask;
        }
    }
}