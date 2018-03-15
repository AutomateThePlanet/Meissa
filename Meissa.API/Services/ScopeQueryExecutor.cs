// <copyright file="ScopeQueryExecutor.cs" company="Automate The Planet Ltd.">
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
using System.Threading.Tasks;
using Meissa.Model;
using Microsoft.EntityFrameworkCore;

namespace Meissa.API.Services
{
    public static class ScopeQueryExecutor
    {
        public static async Task Execute(Action<MeissaRepository> action) =>
            await Task.Factory.StartNew(async () =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<TestsRunsContext>();
                optionsBuilder.UseSqlite("Data Source=meissa.db");

                using (var repo = new MeissaRepository(new TestsRunsContext(optionsBuilder.Options)))
                {
                    action(repo);
                }
            });
    }
}
