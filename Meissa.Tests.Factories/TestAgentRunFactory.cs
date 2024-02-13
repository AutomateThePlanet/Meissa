// <copyright file="TestAgentRunFactory.cs" company="Automate The Planet Ltd.">
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
// <site>https://bellatrix.solutions/</site>
using System;
using System.Linq;
using AutoFixture;
using Meissa.Core.Model;
using Meissa.Server.Models;

namespace Meissa.Tests.Factories
{
    public static class TestAgentRunFactory
    {
        public static IQueryable<TestAgentRunDto> CreateSingle(Guid testRunId, TestAgentRunStatus status)
        {
            var fixture = FixtureFactory.Create();

            fixture.Register(() => status);
            fixture.Customize<TestAgentRunDto>(ta => ta.With(x => x.TestRunId, testRunId));

            var result = fixture.CreateMany<TestAgentRunDto>(1).AsQueryable();

            return result;
        }

        public static IQueryable<TestAgentRunDto> CreateMany(Guid testRunId, TestAgentRunStatus status)
        {
            var fixture = FixtureFactory.Create();

            fixture.Register(() => status);
            fixture.Customize<TestAgentRunDto>(ta => ta.With(x => x.TestRunId, testRunId));

            var result = fixture.CreateMany<TestAgentRunDto>().AsQueryable();

            return result;
        }

        public static IQueryable<TestAgentRunDto> CreateMany(Guid testRunId, TestAgentRunStatus status, int testAgentId, int count)
        {
            var fixture = FixtureFactory.Create();

            fixture.Register(() => status);
            fixture.Customize<TestAgentRunDto>(ta => ta.With(x => x.TestRunId, testRunId).With(x => x.TestAgentId, testAgentId));

            var result = fixture.CreateMany<TestAgentRunDto>(count).AsQueryable();

            return result;
        }

        public static IQueryable<TestAgentRunDto> CreateMany(TestAgentRunStatus status, int testAgentId)
        {
            var fixture = FixtureFactory.Create();

            fixture.Register(() => status);
            fixture.Customize<TestAgentRunDto>(ta => ta.With(x => x.TestAgentId, testAgentId));

            var result = fixture.CreateMany<TestAgentRunDto>().AsQueryable();

            return result;
        }

        public static IQueryable<TestAgentRunDto> CreateSingle(Guid testRunId, TestAgentRunStatus status, int testAgentId)
        {
            var fixture = FixtureFactory.Create();

            fixture.Register(() => status);
            fixture.Customize<TestAgentRunDto>(ta => ta.With(x => x.TestRunId, testRunId).With(x => x.TestAgentId, testAgentId));

            var result = fixture.CreateMany<TestAgentRunDto>(1).AsQueryable();

            return result;
        }

        public static IQueryable<TestAgentRunDto> CreateSingle(Guid testRunId, TestAgentRunStatus status, int testAgentId, int testAgentRunId)
        {
            var fixture = FixtureFactory.Create();

            fixture.Register(() => status);
            fixture.Customize<TestAgentRunDto>(ta => ta.With(x => x.TestRunId, testRunId).With(x => x.TestAgentId, testAgentId).With(x => x.TestAgentRunId, testAgentRunId));

            var result = fixture.CreateMany<TestAgentRunDto>(1).AsQueryable();

            return result;
        }

        public static IQueryable<TestAgentRunDto> CreateEmpty()
        {
            var fixture = FixtureFactory.Create();

            var result = fixture.CreateMany<TestAgentRunDto>(0).AsQueryable();

            return result;
        }

        public static IQueryable<TestAgentRunDto> CreateOneCompletedAndOneAborted(Guid testRunId)
        {
            var fixture = FixtureFactory.Create();

            fixture.Customize<TestAgentRunDto>(ta => ta.With(x => x.TestRunId, testRunId));
            fixture.Register(() => TestAgentRunStatus.Completed);

            var completedTestAgentRun = fixture.CreateMany<TestAgentRunDto>(1);
            fixture.Register(() => TestAgentRunStatus.Aborted);
            var abortedTestAgentRun = fixture.CreateMany<TestAgentRunDto>(1);

            return completedTestAgentRun.Union(abortedTestAgentRun).AsQueryable();
        }

        public static IQueryable<TestAgentRunDto> CreateManyCompletedAndManyAborted(Guid testRunId)
        {
            var fixture = FixtureFactory.Create();

            fixture.Customize<TestAgentRunDto>(ta => ta.With(x => x.TestRunId, testRunId));
            fixture.Register(() => TestAgentRunStatus.Completed);

            var completedTestAgentRuns = fixture.CreateMany<TestAgentRunDto>();
            fixture.Register(() => TestAgentRunStatus.Aborted);
            var abortedTestAgentRuns = fixture.CreateMany<TestAgentRunDto>();

            return completedTestAgentRuns.Union(abortedTestAgentRuns).AsQueryable();
        }
    }
}