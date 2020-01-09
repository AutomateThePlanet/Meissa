using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmallMSTestTestProject
{
    [TestClass]
    public class FirefoxTests
    {
        [TestMethod]
        public void FirefoxTest1()
        {
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void FirefoxTest2()
        {
            Console.WriteLine("EXECUTEs FirefoxTest2");
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void FirefoxTestt3()
        {
            Console.WriteLine("EXECUTEs FirefoxTestt3");
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void FirefoxTest4()
        {
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void FirefoxTest5()
        {
            Thread.Sleep(1000);
        }
    }
}
