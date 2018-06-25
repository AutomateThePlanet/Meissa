using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;

namespace LoadTestsProject
{
    ////[TestClass]
    ////public class CheckoutPageTests
    ////{
    ////    [AssemblyCleanup]
    ////    public static void AssemblyCleanup()
    ////    {
    ////        DriverFactory.GetDriver().Quit();
    ////    }

    ////    [TestInitialize]
    ////    public void TestInit()
    ////    {
    ////        var assembly = Assembly.GetExecutingAssembly();
    ////        var path = Path.GetDirectoryName(assembly.Location);
    ////        var pageFilePath = Path.Combine(path, "checkout-page", "index.html");
    ////        DriverFactory.GetDriver().
    ////            Navigate().
    ////            GoToUrl(url: new System.Uri(pageFilePath, uriKind: System.UriKind.Absolute));
    ////    }

    ////    [TestMethod]
    ////    public void TestFinal()
    ////    {
    ////        var driver = DriverFactory.GetDriver();
    ////        try
    ////        {
    ////            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    ////            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
    ////            wait.Until(d => d.FindElement(By.Id("firstName")) != null);
    ////            var firstName = driver.FindElement(By.Id("firstName"));
    ////            firstName.SendKeys("Anton");
    ////            var lastName = driver.FindElement(By.Id("lastName"));
    ////            lastName.SendKeys("Angelov");
    ////            var userName = driver.FindElement(By.Id("username"));
    ////            userName.SendKeys("angelovstanton");
    ////            var address = driver.FindElement(By.Id("address"));
    ////            address.SendKeys("Bulgarsko Opulchenie 76 B");
    ////            var email = driver.FindElement(By.Id("email"));
    ////            email.SendKeys("aangelov@bellatrix.solutions");
    ////            var countriesSelect = new SelectElement(driver.FindElement(By.Id("country")));
    ////            countriesSelect.SelectByText("United States");
    ////            var statesSelect = new SelectElement(driver.FindElement(By.Id("state")));
    ////            statesSelect.SelectByText("California");
    ////            var zip = driver.FindElement(By.Id("zip"));
    ////            zip.SendKeys("1000");

    ////            var ccname = driver.FindElement(By.Id("cc-name"));
    ////            ccname.SendKeys("Anton Angelov");
    ////            var ccnumber = driver.FindElement(By.Id("cc-number"));
    ////            ccnumber.SendKeys("5610591081018250");
    ////            var ccexpiration = driver.FindElement(By.Id("cc-expiration"));
    ////            ccexpiration.SendKeys("20/10/2020");
    ////            var cccvv = driver.FindElement(By.Id("cc-cvv"));
    ////            cccvv.SendKeys("888");

    ////            var proceedButton = driver.FindElement(By.XPath("/html/body/div/div[2]/div[2]/form/button"));
    ////            proceedButton.Click();
    ////        }
    ////        finally
    ////        {
    ////            driver.Quit();
    ////        }
    ////    }
    ////}
}