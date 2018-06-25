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

        ////  private static void GenerateLoadTestsNUnit()
        ////{
        ////    // MSTEST
        ////    var numberOfTestFiles = 2;
        ////    var numberOfTests = 1000;
        ////    var deployLocation = @"D:\SourceCode\Meissa\LoadTestsProject.NUnit\";
        ////    for (var i = 1; i < numberOfTestFiles; i++)
        ////    {
        ////        var sb = new StringBuilder();
        ////        sb.AppendLine("using System;");
        ////        sb.AppendLine("using System.Threading;");
        ////        sb.AppendLine("using NUnit.Framework;");
        ////        sb.AppendLine("using System.IO;");
        ////        sb.AppendLine("using OpenQA.Selenium;");
        ////        sb.AppendLine("using OpenQA.Selenium.Support.UI;");
        ////        sb.AppendLine("using System.Reflection;");
        ////        sb.AppendLine();
        ////        sb.AppendLine("namespace LoadTestsProject");
        ////        sb.AppendLine("{");
        ////        sb.AppendLine("    [TestFixture]");
        ////        sb.AppendLine($"   public class Cosmos{i}Tests");
        ////        sb.AppendLine("    {");
        ////        for (var j = 0; j < numberOfTests; j++)
        ////        {
        ////            sb.AppendLine("        ");
        ////            sb.AppendLine("        [Test]");
        ////            sb.AppendLine($"        public void TestMethod{j}()");
        ////            sb.AppendLine("        {");
        ////            sb.AppendLine("              var driver = DriverFactory.GetDriver();");
        ////            sb.AppendLine("              var assembly = Assembly.GetExecutingAssembly();");
        ////            sb.AppendLine("              string path = Path.GetDirectoryName(assembly.Location);");
        ////            sb.AppendLine("              string pageFilePath = Path.Combine(path, \"button.html\");");
        ////            sb.AppendLine("              driver.Navigate().GoToUrl(new System.Uri(pageFilePath, uriKind: System.UriKind.Absolute));");
        ////            sb.AppendLine("              var buttonElement = driver.FindElement(By.Id(\"myButton\"));");
        ////            sb.AppendLine("              buttonElement.Click();");
        ////            sb.AppendLine("              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));");
        ////            sb.AppendLine("              wait.Until(d => d.FindElement(By.Id(\"myButton\")).GetAttribute(\"value\").Equals(\"Stop\"));");
        ////            sb.AppendLine("              driver.Quit();");
        ////            sb.AppendLine("        }");
        ////        }
        ////        sb.AppendLine("    }");
        ////        sb.AppendLine("}");
        ////        var fileLocation = Path.Combine(deployLocation, $"Cosmos{i}Tests.cs");
        ////        File.WriteAllText(fileLocation, sb.ToString());
        ////    }
        ////}

        private static void GenerateLoadTestsMsTest()
        {
            // MSTEST
            var numberOfTestFiles = 2;
            var numberOfTests = 1000;
            var deployLocation = @"D:\SourceCode\Meissa\LoadTestsProject";
            for (var i = 1; i < numberOfTestFiles; i++)
            {
                var sb = new StringBuilder();
                sb.AppendLine("using System;");
                sb.AppendLine("using Microsoft.VisualStudio.TestTools.UnitTesting;");
                sb.AppendLine("using System.IO;");
                sb.AppendLine("using OpenQA.Selenium;");
                sb.AppendLine("using OpenQA.Selenium.Support.UI;");
                sb.AppendLine("using System.Reflection;");
                sb.AppendLine();
                sb.AppendLine("namespace LoadTestsProject");
                sb.AppendLine("{");
                sb.AppendLine("    [TestClass]");
                sb.AppendLine($"   public class CheckoutPage{i}Tests");
                sb.AppendLine("    {");
                sb.AppendLine("       ");
                sb.AppendLine("       private string _pageFilePath;");
                sb.AppendLine("       ");
                sb.AppendLine("       [TestInitialize]");
                sb.AppendLine("       public void TestInit()");
                sb.AppendLine("       {");
                sb.AppendLine("          var assembly = Assembly.GetExecutingAssembly();");
                sb.AppendLine("          string path = Path.GetDirectoryName(assembly.Location);");
                sb.AppendLine("          string pageFilePath = Path.Combine(path, \"checkout-page\", \"index.html\");");
                sb.AppendLine("            _pageFilePath = Path.Combine(path, \"checkout-page\", \"index.html\");");
                sb.AppendLine("       }");
                for (var j = 0; j < numberOfTests; j++)
                {
                    sb.AppendLine("        ");
                    sb.AppendLine("        [TestMethod]");
                    sb.AppendLine($"        public void SuccessfullyPruchaseItem{j}()");
                    sb.AppendLine("        {");
                    sb.AppendLine("              var driver = DriverFactory.GetDriver();");
                    sb.AppendLine("              driver.Navigate().GoToUrl(new System.Uri(_pageFilePath, uriKind: System.UriKind.Absolute));");
                    sb.AppendLine("              try");
                    sb.AppendLine("              {");
                    sb.AppendLine("                 var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));");
                    sb.AppendLine("                 wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));");
                    sb.AppendLine("                 wait.Until(d => d.FindElement(By.Id(\"firstName\")) != null);");
                    sb.AppendLine("                 var firstName = driver.FindElement(By.Id(\"firstName\"));");
                    sb.AppendLine("                 firstName.SendKeys(\"Anton\");");
                    sb.AppendLine("                 var lastName = driver.FindElement(By.Id(\"lastName\"));");
                    sb.AppendLine("                 lastName.SendKeys(\"Angelov\");");
                    sb.AppendLine("                 var userName = driver.FindElement(By.Id(\"username\"));");
                    sb.AppendLine("                 userName.SendKeys(\"angelovstanton\");");
                    sb.AppendLine("                 var address = driver.FindElement(By.Id(\"address\"));");
                    sb.AppendLine("                 address.SendKeys(\"Bulgarsko Opulchenie 76 B\");");
                    sb.AppendLine("                 var email = driver.FindElement(By.Id(\"email\"));");
                    sb.AppendLine("                 email.SendKeys(\"aangelov@bellatrix.solutions\");");
                    sb.AppendLine("                 var countriesSelect = new SelectElement(driver.FindElement(By.Id(\"country\")));");
                    sb.AppendLine("                 countriesSelect.SelectByText(\"United States\");");
                    sb.AppendLine("                 var statesSelect = new SelectElement(driver.FindElement(By.Id(\"state\")));");
                    sb.AppendLine("                 statesSelect.SelectByText(\"California\");");
                    sb.AppendLine("                 var zip = driver.FindElement(By.Id(\"zip\"));");
                    sb.AppendLine("                 zip.SendKeys(\"1000\");");
                    sb.AppendLine("                 var ccname = driver.FindElement(By.Id(\"cc-name\"));");
                    sb.AppendLine("                 ccname.SendKeys(\"Anton Angelov\");");
                    sb.AppendLine("                 var ccnumber = driver.FindElement(By.Id(\"cc-number\"));");
                    sb.AppendLine("                 ccnumber.SendKeys(\"5610591081018250\");");
                    sb.AppendLine("                 var ccexpiration = driver.FindElement(By.Id(\"cc-expiration\"));");
                    sb.AppendLine("                 ccexpiration.SendKeys(\"20/10/2020\");");
                    sb.AppendLine("                 var cccvv = driver.FindElement(By.Id(\"cc-cvv\"));");
                    sb.AppendLine("                 cccvv.SendKeys(\"888\");");
                    sb.AppendLine("                 var proceedButton = driver.FindElement(By.XPath(\"/html/body/div/div[2]/div[2]/form/button\"));");
                    sb.AppendLine("                 proceedButton.Click();");
                    sb.AppendLine("              }");
                    sb.AppendLine("              finally");
                    sb.AppendLine("              {");
                    sb.AppendLine("                  driver.Quit();");
                    sb.AppendLine("              }");
                    sb.AppendLine("        }");
                }
                sb.AppendLine("    }");
                sb.AppendLine("}");
                var fileLocation = Path.Combine(deployLocation, $"CheckoutPage{i}Tests.cs");
                File.WriteAllText(fileLocation, sb.ToString());
            }
        }
    }
}
