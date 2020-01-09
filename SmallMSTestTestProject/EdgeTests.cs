using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmallMSTestTestProject
{
    [TestClass]
    public class EdgeTests
    {
        [TestMethod]
        [TestCategory("CI")]
        public void OperaTest1()
        {
            Thread.Sleep(87);
        }

        [TestMethod]
        public void OperaTest2()
        {
            Thread.Sleep(14);
        }

        [TestMethod]
        public void OperaTest3()
        {
            Thread.Sleep(88);
        }

        [TestMethod]
        public void OperaTest4()
        {
            Console.WriteLine("EXECUTEs OperaTest4");
            Thread.Sleep(44);
        }

        [TestMethod]
        public void OperaTest5()
        {
            Thread.Sleep(66);
        }

        [TestMethod]
        [TestCategory("CI")]
        public void OperaTest12()
        {
            Thread.Sleep(1000);
        }

        [TestMethod]
        public void OperaTest22()
        {
            Thread.Sleep(55);
        }

        [TestMethod]
        public void OperaTest33()
        {
            Thread.Sleep(50);
        }

        [TestMethod]
        public void OperaTest43()
        {
            Thread.Sleep(50);
        }

        [TestMethod]
        public void OperaTest53()
        {
            Thread.Sleep(50);
        }
    }
}
