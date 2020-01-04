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

            ////var testCasesHistory = new List<TestCaseHistory>()
            ////{
            ////    new TestCaseHistory
            ////    {
            ////        AvgDuration = TimeSpan.FromSeconds(260),
            ////        FullName = "Microsoft.EntityFrameworkCore.Internal",
            ////        LastUpdatedTime = DateTime.Now,
            ////        TestCaseHistoryId = 1,
            ////    },
            ////    new TestCaseHistory
            ////    {
            ////        AvgDuration = TimeSpan.FromSeconds(5),
            ////        FullName = "Microsoft.EntityFrameworkCore.Generic",
            ////        LastUpdatedTime = DateTime.Now,
            ////        TestCaseHistoryId = 2,
            ////    },
            ////    new TestCaseHistory
            ////    {
            ////        AvgDuration = TimeSpan.FromSeconds(15),
            ////        FullName = "Microsoft.EntityFrameworkCore.Linq",
            ////        LastUpdatedTime = DateTime.Now,
            ////        TestCaseHistoryId = 3,
            ////    },
            ////    new TestCaseHistory
            ////    {
            ////        AvgDuration = TimeSpan.FromSeconds(20),
            ////        FullName = "Microsoft.EntityFrameworkCore.System",
            ////        LastUpdatedTime = DateTime.Now,
            ////        TestCaseHistoryId = 4,
            ////    },
            ////};
            ////context.TestCasesHistory.AddRange(testCasesHistory);
            ////var testCaseHistoryEntries = new List<TestCaseHistoryEntry>
            ////{
            ////    new TestCaseHistoryEntry
            ////    {
            ////        TestCaseHistoryEntryId = 1,
            ////        TestCaseHistoryId = 1,
            ////        AvgDuration = TimeSpan.FromSeconds(2),
            ////    },
            ////    new TestCaseHistoryEntry
            ////    {
            ////        TestCaseHistoryEntryId = 2,
            ////        TestCaseHistoryId = 1,
            ////        AvgDuration = TimeSpan.FromSeconds(3),
            ////    },
            ////    new TestCaseHistoryEntry
            ////    {
            ////        TestCaseHistoryEntryId = 3,
            ////        TestCaseHistoryId = 1,
            ////        AvgDuration = TimeSpan.FromSeconds(4),
            ////    },
            ////    new TestCaseHistoryEntry
            ////    {
            ////        TestCaseHistoryEntryId = 4,
            ////        TestCaseHistoryId = 2,
            ////        AvgDuration = TimeSpan.FromSeconds(8),
            ////    },
            ////    new TestCaseHistoryEntry
            ////    {
            ////        TestCaseHistoryEntryId = 5,
            ////        TestCaseHistoryId = 3,
            ////        AvgDuration = TimeSpan.FromSeconds(25),
            ////    },
            ////    new TestCaseHistoryEntry
            ////    {
            ////        TestCaseHistoryEntryId = 6,
            ////        TestCaseHistoryId = 4,
            ////        AvgDuration = TimeSpan.FromSeconds(90),
            ////    },
            ////    new TestCaseHistoryEntry
            ////    {
            ////        TestCaseHistoryEntryId = 7,
            ////        TestCaseHistoryId = 4,
            ////        AvgDuration = TimeSpan.FromSeconds(80),
            ////    },
            ////};
            ////context.TestCaseHistoryEntries.AddRange(testCaseHistoryEntries);
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
