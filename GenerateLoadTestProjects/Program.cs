// <copyright file="Program.cs" company="Automate The Planet Ltd.">
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
using System.IO;
using System.Text;

namespace GenerateLoadTestProjects
{
    public class Program
    {
        public static void Main(string[] args) => GenerateLoadTestsMsTest();

        private static void GenerateLoadTestsNUnit()
        {
            var numberOfTestFiles = 10;
            var numberOfTests = 100;
            var deployLocation = @"D:\OneDrive\SourceCode\AutomateThePlanet\Meissa\LoadTestsProject.NUnit";
            for (var i = 0; i < numberOfTestFiles; i++)
            {
                var sb = new StringBuilder();
                sb.AppendLine("using System;");
                sb.AppendLine("using System.Threading;");
                sb.AppendLine("using NUnit.Framework;");
                sb.AppendLine();
                sb.AppendLine("namespace LoadTestsProject");
                sb.AppendLine("{");
                sb.AppendLine("    [TestFixture]");
                sb.AppendLine($"    public class Cosmos{i}Tests");
                sb.AppendLine("    {");
                sb.AppendLine("        private readonly Random _random = new Random();");
                for (var j = 0; j < numberOfTests; j++)
                {
                    sb.AppendLine("        ");
                    sb.AppendLine("        [Test]");
                    sb.AppendLine($"        public void TestMethod{j}()");
                    sb.AppendLine("        {");
                    sb.AppendLine("            Thread.Sleep(1000);");
                    sb.AppendLine("        }");
                }
                sb.AppendLine("    }");
                sb.AppendLine("}");
                var fileLocation = Path.Combine(deployLocation, $"Cosmos{i}Tests.cs");
                File.WriteAllText(fileLocation, sb.ToString());
            }
        }

        private static void GenerateLoadTestsMsTest()
        {
            // MSTEST
            var numberOfTestFiles = 10;
            var numberOfTests = 100;
            var deployLocation = @"D:\SourceCode\AutomateThePlanet\Meissa\CompareRunnersTestsProject";
            for (var i = 0; i < numberOfTestFiles; i++)
            {
                var sb = new StringBuilder();
                sb.AppendLine("using System;");
                sb.AppendLine("using System.Threading;");
                sb.AppendLine("using Microsoft.VisualStudio.TestTools.UnitTesting;");
                sb.AppendLine();
                sb.AppendLine("namespace LoadTestsProject");
                sb.AppendLine("{");
                sb.AppendLine("    [TestClass]");
                sb.AppendLine($"    public class Cosmos{i}Tests");
                sb.AppendLine("    {");
                sb.AppendLine("        private readonly Random _random = new Random();");
                for (var j = 0; j < numberOfTests; j++)
                {
                    sb.AppendLine("        ");
                    sb.AppendLine("        [TestMethod]");
                    sb.AppendLine($"        public void TestMethod{j}()");
                    sb.AppendLine("        {");
                    sb.AppendLine("            Thread.Sleep(1000);");
                    sb.AppendLine("        }");
                }
                sb.AppendLine("    }");
                sb.AppendLine("}");
                var fileLocation = Path.Combine(deployLocation, $"Cosmos{i}Tests.cs");
                File.WriteAllText(fileLocation, sb.ToString());
            }
        }
    }
}
