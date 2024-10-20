// <copyright file="TestRunLogFactory.cs" company="Automate The Planet Ltd.">
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
using System.Linq;
using AutoFixture;
using Meissa.Core.Model;
using Meissa.Server.Models;

namespace Meissa.Tests.Factories;

public static class TestRunLogFactory
{
    public static IQueryable<TestRunLogDto> CreateEmpty()
    {
        var fixture = FixtureFactory.Create();

        var result = fixture.CreateMany<TestRunLogDto>(0).AsQueryable();

        return result;
    }

    public static IQueryable<TestRunLogDto> CreateMany()
    {
        var fixture = FixtureFactory.Create();

        var result = fixture.CreateMany<TestRunLogDto>().AsQueryable();

        return result;
    }

    public static IQueryable<TestRunLogDto> CreateMany(Guid testRunId, TestRunLogStatus testRunLogStatus = TestRunLogStatus.Published, int count = 3)
    {
        var fixture = FixtureFactory.Create();

        fixture.Customize<TestRunLogDto>(tr => tr.With(x => x.TestRunId, testRunId).With(x => x.Status, testRunLogStatus));

        var result = fixture.CreateMany<TestRunLogDto>(count).AsQueryable();

        return result;
    }
}