// <copyright file="TestsRunsContext.cs" company="Automate The Planet Ltd.">
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

using Microsoft.EntityFrameworkCore;

namespace Meissa.Model
{
    public sealed class TestsRunsContext : DbContext
    {
        public TestsRunsContext()
        {
        }

        public TestsRunsContext(DbContextOptions<TestsRunsContext> options)
           : base(options)
        {
            this.EnsureSeedDataForContext();
        }

        public DbSet<TestAgent> TestAgents { get; set; }
        public DbSet<TestAgentRun> TestAgentRuns { get; set; }
        public DbSet<TestRun> TestRuns { get; set; }
        public DbSet<TestRunLog> TestRunLogs { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<TestRunOutput> TestRunOutputs { get; set; }
        public DbSet<TestRunCustomArgument> TestRunCustomArguments { get; set; }
        public DbSet<TestRunAvailability> TestRunAvailabilities { get; set; }
        public DbSet<TestAgentRunAvailability> TestAgentRunAvailabilities { get; set; }
        public DbSet<TestCaseHistory> TestCasesHistory { get; set; }
        public DbSet<TestCaseHistoryEntry> TestCaseHistoryEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseInMemoryDatabase("meissa");
            }
        }
    }
}
