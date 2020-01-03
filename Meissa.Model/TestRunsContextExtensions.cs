// <copyright file="TestRunsContextExtensions.cs" company="Automate The Planet Ltd.">
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
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;

namespace Meissa.Model
{
    public static class TestRunsContextExtensions
    {
        public static void EnsureSeedDataForContext(this TestsRunsContext context)
        {
            if (context.Logs.Any())
            {
                return;
            }

            var logs = new List<Log>()
            {
                new Log
                {
                    Date = DateTime.Now,
                    Thread = "1",
                    Level = "2",
                    Logger = "COOL LOGGER",
                    Message = "BELLATRIX FOR THE WIN!",
                    Exception = "NO EXCEPTIONS HERE",
                },
                new Log
                {
                    Date = DateTime.Now,
                    Thread = "1",
                    Level = "2",
                    Logger = "COOL LOGGER",
                    Message = "BELLATRIX FOR THE WIN!",
                    Exception = "NO EXCEPTIONS HERE",
                },
                new Log
                {
                    Date = DateTime.Now,
                    Thread = "1",
                    Level = "2",
                    Logger = "COOL LOGGER",
                    Message = "BELLATRIX FOR THE WIN!",
                    Exception = "NO EXCEPTIONS HERE",
                },
                new Log
                {
                    Date = DateTime.Now,
                    Thread = "1",
                    Level = "2",
                    Logger = "COOL LOGGER",
                    Message = "BELLATRIX FOR THE WIN!",
                    Exception = "NO EXCEPTIONS HERE",
                },
                new Log
                {
                    Date = DateTime.Now,
                    Thread = "1",
                    Level = "2",
                    Logger = "COOL LOGGER",
                    Message = "BELLATRIX FOR THE WIN!",
                    Exception = "NO EXCEPTIONS HERE",
                },
            };

            context.Logs.AddRange(logs);
            context.SaveChanges();
        }
    }
}
