using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LoadTestsProject
{
    public class DriverFactory
    {
        public static IWebDriver GetDriver()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            chromeDriverService.Port = GetFreeTcpPort();
            var chromeHeadlessOptions = new ChromeOptions();
            chromeHeadlessOptions.AddArguments("headless");
            var driver = new ChromeDriver(chromeDriverService, chromeHeadlessOptions);

            return driver;
        }

        private static int GetFreeTcpPort()
        {
            Thread.Sleep(100);
            var tcpListener = new TcpListener(IPAddress.Loopback, 0);
            tcpListener.Start();
            var port = ((IPEndPoint)tcpListener.LocalEndpoint).Port;
            tcpListener.Stop();
            return port;
        }
    }
}
