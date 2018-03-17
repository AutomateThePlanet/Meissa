using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;

namespace LoadTestsProject
{
    [TestClass]
   public class Cosmos1Tests
    {
        [AssemblyCleanup]
        public void AssemblyCleanup(TestContext testContext)
        {
            DriverFactory.GetDriver().Quit();
        }

        [TestInitialize]
       public void TestInit()
       {
          var assembly = Assembly.GetExecutingAssembly();
          var path = Path.GetDirectoryName(assembly.Location);
          var pageFilePath = Path.Combine(path, "button.html");
          DriverFactory.GetDriver().Navigate().GoToUrl(new System.Uri(pageFilePath, uriKind: System.UriKind.Absolute));
       }
        
        [TestMethod]
        public void TestMethod0()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod1()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod2()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod3()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod4()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod5()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod6()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod7()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod8()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod9()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod10()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod11()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod12()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod13()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod14()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod15()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod16()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod17()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod18()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod19()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod20()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod21()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod22()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod23()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod24()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod25()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod26()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod27()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod28()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod29()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod30()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod31()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod32()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod33()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod34()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod35()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod36()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod37()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod38()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod39()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod40()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod41()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod42()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod43()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod44()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod45()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod46()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod47()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod48()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod49()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod50()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod51()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod52()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod53()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod54()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod55()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod56()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod57()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod58()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod59()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod60()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod61()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod62()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod63()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod64()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod65()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod66()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod67()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod68()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod69()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod70()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod71()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod72()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod73()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod74()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod75()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod76()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod77()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod78()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod79()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod80()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod81()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod82()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod83()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod84()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod85()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod86()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod87()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod88()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod89()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod90()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod91()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod92()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod93()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod94()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod95()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod96()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod97()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod98()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod99()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod100()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod101()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod102()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod103()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod104()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod105()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod106()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod107()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod108()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod109()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod110()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod111()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod112()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod113()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod114()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod115()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod116()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod117()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod118()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod119()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod120()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod121()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod122()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod123()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod124()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod125()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod126()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod127()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod128()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod129()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod130()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod131()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod132()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod133()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod134()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod135()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod136()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod137()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod138()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod139()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod140()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod141()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod142()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod143()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod144()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod145()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod146()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod147()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod148()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod149()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod150()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod151()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod152()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod153()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod154()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod155()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod156()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod157()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod158()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod159()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod160()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod161()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod162()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod163()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod164()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod165()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod166()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod167()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod168()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod169()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod170()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod171()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod172()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod173()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod174()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod175()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod176()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod177()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod178()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod179()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod180()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod181()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod182()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod183()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod184()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod185()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod186()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod187()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod188()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod189()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod190()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod191()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod192()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod193()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod194()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod195()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod196()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod197()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod198()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod199()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod200()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod201()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod202()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod203()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod204()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod205()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod206()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod207()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod208()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod209()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod210()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod211()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod212()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod213()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod214()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod215()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod216()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod217()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod218()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod219()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod220()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod221()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod222()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod223()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod224()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod225()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod226()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod227()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod228()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod229()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod230()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod231()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod232()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod233()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod234()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod235()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod236()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod237()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod238()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod239()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod240()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod241()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod242()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod243()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod244()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod245()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod246()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod247()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod248()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod249()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod250()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod251()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod252()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod253()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod254()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod255()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod256()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod257()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod258()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod259()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod260()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod261()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod262()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod263()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod264()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod265()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod266()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod267()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod268()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod269()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod270()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod271()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod272()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod273()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod274()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod275()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod276()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod277()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod278()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod279()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod280()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod281()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod282()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod283()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod284()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod285()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod286()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod287()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod288()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod289()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod290()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod291()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod292()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod293()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod294()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod295()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod296()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod297()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod298()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod299()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod300()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod301()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod302()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod303()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod304()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod305()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod306()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod307()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod308()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod309()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod310()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod311()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod312()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod313()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod314()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod315()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod316()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod317()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod318()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod319()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod320()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod321()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod322()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod323()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod324()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod325()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod326()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod327()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod328()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod329()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod330()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod331()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod332()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod333()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod334()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod335()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod336()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod337()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod338()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod339()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod340()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod341()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod342()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod343()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod344()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod345()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod346()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod347()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod348()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod349()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod350()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod351()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod352()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod353()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod354()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod355()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod356()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod357()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod358()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod359()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod360()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod361()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod362()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod363()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod364()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod365()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod366()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod367()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod368()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod369()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod370()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod371()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod372()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod373()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod374()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod375()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod376()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod377()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod378()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod379()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod380()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod381()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod382()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod383()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod384()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod385()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod386()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod387()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod388()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod389()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod390()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod391()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod392()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod393()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod394()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod395()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod396()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod397()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod398()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod399()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod400()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod401()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod402()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod403()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod404()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod405()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod406()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod407()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod408()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod409()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod410()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod411()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod412()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod413()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod414()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod415()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod416()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod417()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod418()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod419()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod420()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod421()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod422()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod423()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod424()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod425()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod426()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod427()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod428()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod429()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod430()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod431()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod432()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod433()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod434()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod435()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod436()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod437()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod438()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod439()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod440()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod441()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod442()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod443()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod444()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod445()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod446()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod447()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod448()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod449()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod450()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod451()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod452()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod453()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod454()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod455()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod456()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod457()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod458()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod459()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod460()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod461()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod462()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod463()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod464()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod465()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod466()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod467()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod468()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod469()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod470()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod471()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod472()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod473()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod474()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod475()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod476()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod477()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod478()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod479()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod480()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod481()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod482()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod483()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod484()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod485()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod486()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod487()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod488()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod489()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod490()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod491()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod492()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod493()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod494()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod495()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod496()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod497()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod498()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod499()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod500()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod501()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod502()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod503()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod504()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod505()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod506()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod507()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod508()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod509()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod510()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod511()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod512()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod513()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod514()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod515()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod516()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod517()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod518()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod519()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod520()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod521()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod522()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod523()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod524()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod525()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod526()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod527()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod528()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod529()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod530()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod531()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod532()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod533()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod534()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod535()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod536()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod537()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod538()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod539()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod540()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod541()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod542()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod543()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod544()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod545()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod546()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod547()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod548()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod549()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod550()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod551()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod552()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod553()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod554()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod555()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod556()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod557()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod558()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod559()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod560()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod561()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod562()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod563()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod564()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod565()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod566()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod567()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod568()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod569()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod570()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod571()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod572()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod573()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod574()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod575()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod576()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod577()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod578()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod579()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod580()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod581()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod582()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod583()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod584()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod585()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod586()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod587()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod588()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod589()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod590()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod591()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod592()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod593()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod594()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod595()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod596()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod597()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod598()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod599()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod600()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod601()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod602()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod603()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod604()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod605()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod606()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod607()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod608()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod609()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod610()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod611()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod612()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod613()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod614()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod615()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod616()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod617()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod618()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod619()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod620()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod621()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod622()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod623()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod624()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod625()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod626()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod627()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod628()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod629()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod630()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod631()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod632()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod633()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod634()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod635()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod636()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod637()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod638()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod639()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod640()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod641()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod642()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod643()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod644()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod645()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod646()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod647()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod648()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod649()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod650()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod651()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod652()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod653()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod654()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod655()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod656()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod657()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod658()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod659()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod660()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod661()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod662()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod663()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod664()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod665()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod666()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod667()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod668()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod669()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod670()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod671()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod672()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod673()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod674()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod675()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod676()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod677()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod678()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod679()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod680()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod681()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod682()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod683()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod684()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod685()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod686()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod687()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod688()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod689()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod690()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod691()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod692()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod693()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod694()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod695()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod696()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod697()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod698()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod699()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod700()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod701()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod702()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod703()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod704()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod705()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod706()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod707()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod708()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod709()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod710()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod711()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod712()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod713()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod714()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod715()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod716()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod717()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod718()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod719()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod720()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod721()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod722()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod723()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod724()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod725()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod726()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod727()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod728()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod729()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod730()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod731()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod732()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod733()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod734()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod735()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod736()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod737()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod738()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod739()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod740()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod741()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod742()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod743()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod744()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod745()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod746()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod747()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod748()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod749()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod750()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod751()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod752()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod753()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod754()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod755()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod756()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod757()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod758()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod759()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod760()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod761()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod762()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod763()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod764()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod765()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod766()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod767()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod768()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod769()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod770()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod771()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod772()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod773()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod774()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod775()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod776()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod777()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod778()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod779()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod780()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod781()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod782()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod783()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod784()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod785()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod786()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod787()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod788()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod789()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod790()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod791()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod792()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod793()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod794()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod795()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod796()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod797()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod798()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod799()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod800()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod801()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod802()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod803()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod804()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod805()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod806()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod807()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod808()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod809()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod810()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod811()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod812()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod813()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod814()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod815()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod816()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod817()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod818()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod819()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod820()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod821()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod822()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod823()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod824()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod825()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod826()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod827()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod828()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod829()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod830()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod831()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod832()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod833()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod834()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod835()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod836()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod837()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod838()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod839()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod840()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod841()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod842()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod843()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod844()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod845()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod846()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod847()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod848()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod849()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod850()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod851()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod852()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod853()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod854()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod855()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod856()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod857()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod858()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod859()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod860()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod861()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod862()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod863()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod864()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod865()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod866()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod867()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod868()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod869()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod870()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod871()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod872()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod873()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod874()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod875()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod876()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod877()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod878()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod879()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod880()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod881()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod882()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod883()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod884()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod885()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod886()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod887()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod888()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod889()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod890()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod891()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod892()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod893()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod894()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod895()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod896()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod897()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod898()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod899()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod900()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod901()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod902()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod903()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod904()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod905()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod906()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod907()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod908()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod909()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod910()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod911()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod912()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod913()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod914()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod915()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod916()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod917()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod918()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod919()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod920()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod921()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod922()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod923()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod924()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod925()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod926()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod927()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod928()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod929()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod930()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod931()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod932()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod933()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod934()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod935()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod936()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod937()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod938()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod939()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod940()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod941()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod942()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod943()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod944()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod945()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod946()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod947()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod948()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod949()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod950()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod951()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod952()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod953()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod954()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod955()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod956()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod957()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod958()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod959()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod960()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod961()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod962()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod963()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod964()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod965()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod966()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod967()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod968()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod969()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod970()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod971()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod972()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod973()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod974()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod975()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod976()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod977()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod978()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod979()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod980()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod981()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod982()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod983()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod984()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod985()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod986()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod987()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod988()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod989()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod990()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod991()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod992()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod993()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod994()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod995()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod996()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod997()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod998()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
        
        [TestMethod]
        public void TestMethod999()
        {
              var driver = DriverFactory.GetDriver();
              var buttonElement = driver.FindElement(By.Id("myButton"));
              buttonElement.Click();
              var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
              wait.Until(d => d.FindElement(By.Id("myButton")).GetAttribute("value").Equals("Stop"));
        }
    }
}
