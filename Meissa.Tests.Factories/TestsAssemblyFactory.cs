// <copyright file="TestsAssemblyFactory.cs" company="Automate The Planet Ltd.">
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
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AutoFixture;
using Moq;
using NUnit.Framework;

namespace Meissa.Tests.Factories
{
    public static class TestsAssemblyFactory
    {
        public static Assembly CreateAssembly()
        {
            var assembly = new Mock<Assembly>().Object;

            return assembly;
        }

        public static IEnumerable<Attribute> CreateTestFixtureAttribute()
        {
            var fixture = FixtureFactory.Create();

            var result = fixture.CreateMany<TestFixtureAttribute>(1);

            return result;
        }

        public static IEnumerable<Attribute> CreateTestAttribute()
        {
            var fixture = FixtureFactory.Create();

            var result = fixture.CreateMany<TestAttribute>(1);

            return result;
        }

        public static Type[] CreateTypes()
        {
            var fixture = FixtureFactory.Create();

            var result = fixture.CreateMany<Type>();

            return result.ToArray();
        }

        public static Type[] CreateTypes(int count)
        {
            var fixture = FixtureFactory.Create();

            var result = fixture.CreateMany<Type>(count);

            return result.ToArray();
        }

        public static MethodInfo[] CreateMethodInfo()
        {
            var method = new Mock<MethodInfo>().Object;

            return new[] { method };
        }

        public static MethodInfo[] CreateMethodInfos()
        {
            List<MethodInfo> result = new List<MethodInfo>();

            for (int i = 0; i < 3; i++)
            {
                result.Add(new Mock<MethodInfo>().Object);
            }

            return result.ToArray();
        }

        public static MethodInfo[] CreateMethodInfos(int count)
        {
            List<MethodInfo> result = new List<MethodInfo>();

            for (int i = 0; i < count; i++)
            {
                result.Add(new Mock<MethodInfo>().Object);
            }

            return result.ToArray();
        }

        public static IEnumerable<Attribute> CreateNunitCategoryAttribute(string categoryName)
        {
            var testCategory = new CategoryAttribute(categoryName);

            return new List<CategoryAttribute> { testCategory };
        }

        public static IEnumerable<Attribute> CreateNunitCategoryAttributes(int count)
        {
            var fixture = new Fixture();
            List<CategoryAttribute> result = new List<CategoryAttribute>();

            for (int i = 0; i < count; i++)
            {
                result.Add(new CategoryAttribute(fixture.Create<string>()));
            }

            return result;
        }
    }
}
