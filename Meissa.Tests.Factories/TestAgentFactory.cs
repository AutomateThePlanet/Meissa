// <copyright file="TestAgentFactory.cs" company="Automate The Planet Ltd.">
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

public static class TestAgentFactory
{
    public static IQueryable<TestAgentDto> CreateEmpty()
    {
        var fixture = new Fixture();

        var result = fixture.CreateMany<TestAgentDto>(0).AsQueryable();

        return result;
    }

    public static IQueryable<TestAgentDto> CreateWithCurrentMachineName(TestAgentStatus status, int count)
    {
        var fixture = new Fixture();
        string agentTag = fixture.Create<string>();
        fixture.Register(() => status);
        fixture.Customize<TestAgentDto>(ta => ta.With(x => x.MachineName, Environment.MachineName).With(x => x.AgentTag, agentTag));

        var result = fixture.CreateMany<TestAgentDto>(count).AsQueryable();

        return result;
    }

    public static IQueryable<TestAgentDto> CreateWithoutCurrentMachineName(TestAgentStatus status)
    {
        var fixture = new Fixture();

        fixture.Register(() => status);

        var result = fixture.CreateMany<TestAgentDto>().AsQueryable();

        return result;
    }

    public static IQueryable<TestAgentDto> CreateWithoutCurrentMachineName(TestAgentStatus status, int count, int testAgentId)
    {
        var fixture = new Fixture();

        fixture.Register(() => status);
        fixture.Customize<TestAgentDto>(ta => ta.With(x => x.TestAgentId, testAgentId));

        var result = fixture.CreateMany<TestAgentDto>(count).AsQueryable();

        return result;
    }

    public static IQueryable<TestAgentDto> CreateWithoutCurrentMachineNameInActiveStatus(int count)
    {
        var fixture = new Fixture();

        fixture.Register(() => TestAgentStatus.Active);

        var result = fixture.CreateMany<TestAgentDto>(count).AsQueryable();

        return result;
    }

    public static IQueryable<TestAgentDto> CreateManyActiveOnlyOneWithCurrentMachineName(int currentMachineTestAgentId)
    {
        var fixture = new Fixture();

        fixture.Register(() => TestAgentStatus.Active);
        var withoutCurrentMachineTestAgents = fixture.CreateMany<TestAgentDto>().AsQueryable();
        fixture.Customize<TestAgentDto>(ta => ta.With(x => x.MachineName, Environment.MachineName).With(x => x.TestAgentId, currentMachineTestAgentId));
        var currentMachineTestAgent = fixture.CreateMany<TestAgentDto>(1).AsQueryable();

        return currentMachineTestAgent.Union(withoutCurrentMachineTestAgents);
    }

    public static IQueryable<TestAgentDto> CreateManyOnlyOneWithCurrentMachineName(TestAgentStatus status)
    {
        var fixture = new Fixture();

        fixture.Register(() => status);
        var withoutCurrentMachineTestAgents = fixture.CreateMany<TestAgentDto>().AsQueryable();
        fixture.Customize<TestAgentDto>(ta => ta.With(x => x.MachineName, Environment.MachineName));
        var currentMachineTestAgent = fixture.CreateMany<TestAgentDto>(1).AsQueryable();

        return currentMachineTestAgent.Union(withoutCurrentMachineTestAgents);
    }

    public static IQueryable<TestAgentDto> CreateMany()
    {
        var fixture = new Fixture();

        var result = fixture.CreateMany<TestAgentDto>().AsQueryable();

        return result;
    }

    public static IQueryable<TestAgentDto> CreateMany(TestAgentStatus status)
    {
        var fixture = new Fixture();

        fixture.Register(() => status);
        var result = fixture.CreateMany<TestAgentDto>().AsQueryable();

        return result;
    }

    public static IQueryable<TestAgentDto> CreateSingle(string agentTag)
    {
        var fixture = new Fixture();

        fixture.Customize<TestAgentDto>(ta => ta.With(x => x.AgentTag, agentTag));

        var result = fixture.CreateMany<TestAgentDto>(1).AsQueryable();

        return result;
    }

    public static IQueryable<TestAgentDto> CreateMany(string agentTag)
    {
        var fixture = new Fixture();

        fixture.Customize<TestAgentDto>(ta => ta.With(x => x.AgentTag, agentTag));

        var result = fixture.CreateMany<TestAgentDto>().AsQueryable();

        return result;
    }

    public static IQueryable<TestAgentDto> CreateMany(string agentTag, TestAgentStatus status)
    {
        var fixture = new Fixture();

        fixture.Register(() => status);
        fixture.Customize<TestAgentDto>(ta => ta.With(x => x.AgentTag, agentTag));

        var result = fixture.CreateMany<TestAgentDto>().AsQueryable();

        return result;
    }
}
