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
        public static void Main(string[] args) => GenerateLoadTestsNUnit();

        ////private static void GenerateLoadTestsNUnit()
        ////{
        ////    var numberOfTestFiles = 10;
        ////    var numberOfTests = 100;
        ////    var deployLocation = @"D:\OneDrive\SourceCode\AutomateThePlanet\Meissa\LoadTestsProject.NUnit";
        ////    for (var i = 0; i < numberOfTestFiles; i++)
        ////    {
        ////        var sb = new StringBuilder();
        ////        sb.AppendLine("using System;");
        ////        sb.AppendLine("using System.Threading;");
        ////        sb.AppendLine("using NUnit.Framework;");
        ////        sb.AppendLine();
        ////        sb.AppendLine("namespace LoadTestsProject");
        ////        sb.AppendLine("{");
        ////        sb.AppendLine("    [TestFixture]");
        ////        sb.AppendLine($"    public class Cosmos{i}Tests");
        ////        sb.AppendLine("    {");
        ////        sb.AppendLine("        private readonly Random _random = new Random();");
        ////        for (var j = 0; j < numberOfTests; j++)
        ////        {
        ////            sb.AppendLine("        ");
        ////            sb.AppendLine("        [Test]");
        ////            sb.AppendLine($"        public void TestMethod{j}()");
        ////            sb.AppendLine("        {");
        ////            sb.AppendLine("            Thread.Sleep(1000);");
        ////            sb.AppendLine("        }");
        ////        }
        ////        sb.AppendLine("    }");
        ////        sb.AppendLine("}");
        ////        var fileLocation = Path.Combine(deployLocation, $"Cosmos{i}Tests.cs");
        ////        File.WriteAllText(fileLocation, sb.ToString());
        ////    }
        ////}
        
          private static void GenerateLoadTestsNUnit()
        {
            // MSTEST
            var numberOfTestFiles = 2;
            var numberOfTests = 1000;
            var deployLocation = @"D:\SourceCode\Meissa\LoadTestsProject.NUnit\";
            for (var i = 1; i < numberOfTestFiles; i++)
            {
                var sb = new StringBuilder();
                sb.AppendLine("using System;");
                sb.AppendLine("using System.Threading;");
                sb.AppendLine("using NUnit.Framework;");
                sb.AppendLine("using System.IO;");
                sb.AppendLine("using OpenQA.Selenium;");
                sb.AppendLine("using OpenQA.Selenium.Support.UI;");
                sb.AppendLine("using System.Reflection;");
                sb.AppendLine();
                sb.AppendLine("namespace LoadTestsProject");
                sb.AppendLine("{");
                sb.AppendLine("    [TestFixture]");
                sb.AppendLine($"   public class Cosmos{i}Tests");
                sb.AppendLine("    {");
                for (var j = 0; j < numberOfTests; j++)
                {
                    sb.AppendLine("        ");
                    sb.AppendLine("        [Test]");
                    sb.AppendLine($"        public void TestMethod{j}()");
                    sb.AppendLine("        {");
                    sb.AppendLine("              var driver = DriverFactory.GetDriver();");
                    sb.AppendLine("              var assembly = Assembly.GetExecutingAssembly();");
                    sb.AppendLine("              string path = Path.GetDirectoryName(assembly.Location);");
                    sb.AppendLine("              string pageFilePath = Path.Combine(path, \"button.html\");");
                    sb.AppendLine("              driver.Navigate().GoToUrl(new System.Uri(pageFilePath, uriKind: System.UriKind.Absolute));");
                    sb.AppendLine("              var buttonElement = driver.FindElement(By.Id(\"myButton\"));");
                    sb.AppendLine("              buttonElement.Click();");
                    sb.AppendLine("              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));");
                    sb.AppendLine("              wait.Until(d => d.FindElement(By.Id(\"myButton\")).GetAttribute(\"value\").Equals(\"Stop\"));");
                    sb.AppendLine("              driver.Quit();");
                    sb.AppendLine("        }");
                }
                sb.AppendLine("    }");
                sb.AppendLine("}");
                var fileLocation = Path.Combine(deployLocation, $"Cosmos{i}Tests.cs");
                File.WriteAllText(fileLocation, sb.ToString());
            }
        }

        ////private static void GenerateLoadTestsMsTest()
        ////{
        ////    // MSTEST
        ////    var numberOfTestFiles = 2;
        ////    var numberOfTests = 1000;
        ////    var deployLocation = @"D:\SourceCode\AutomateThePlanet\Meissa\LoadTestsProject.NUnit";
        ////    for (var i = 1; i < numberOfTestFiles; i++)
        ////    {
        ////        var sb = new StringBuilder();
        ////        sb.AppendLine("using System;");
        ////        sb.AppendLine("using System.Threading;");
        ////        sb.AppendLine("using Microsoft.VisualStudio.TestTools.UnitTesting;");
        ////        sb.AppendLine("using System.IO;");
        ////        sb.AppendLine("using OpenQA.Selenium;");
        ////        sb.AppendLine("using OpenQA.Selenium.Support.UI;");
        ////        sb.AppendLine("using System.Reflection;");
        ////        sb.AppendLine();
        ////        sb.AppendLine("namespace LoadTestsProject");
        ////        sb.AppendLine("{");
        ////        sb.AppendLine("    [TestClass]");
        ////        sb.AppendLine($"   public class Cosmos{i}Tests");
        ////        sb.AppendLine("    {");
        ////        sb.AppendLine("       [TestInitialize]");
        ////        sb.AppendLine("       public void TestInit()");
        ////        sb.AppendLine("       {");
        ////        sb.AppendLine("          var assembly = Assembly.GetExecutingAssembly();");
        ////        sb.AppendLine("          string path = Path.GetDirectoryName(assembly.Location);");
        ////        sb.AppendLine("          string pageFilePath = Path.Combine(path, \"button.html\");");
        ////        sb.AppendLine("          DriverFactory.GetDriver().Navigate().GoToUrl(new System.Uri(pageFilePath, uriKind: System.UriKind.Absolute));");
        ////        sb.AppendLine("       }");
        ////        for (var j = 0; j < numberOfTests; j++)
        ////        {
        ////            sb.AppendLine("        ");
        ////            sb.AppendLine("        [TestMethod]");
        ////            sb.AppendLine($"        public void TestMethod{j}()");
        ////            sb.AppendLine("        {");
        ////            sb.AppendLine("              var driver = DriverFactory.GetDriver();");
        ////            sb.AppendLine("              var buttonElement = driver.FindElement(By.Id(\"myButton\"));");
        ////            sb.AppendLine("              buttonElement.Click();");
        ////            sb.AppendLine("              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));");
        ////            sb.AppendLine("              wait.Until(d => d.FindElement(By.Id(\"myButton\")).GetAttribute(\"value\").Equals(\"Stop\"));");
        ////            sb.AppendLine("        }");
        ////        }
        ////        sb.AppendLine("    }");
        ////        sb.AppendLine("}");
        ////        var fileLocation = Path.Combine(deployLocation, $"Cosmos{i}Tests.cs");
        ////        File.WriteAllText(fileLocation, sb.ToString());
        ////    }
        ////}
    }
}
