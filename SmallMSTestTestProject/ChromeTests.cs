using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SmallMSTestTestProject;

[TestClass]
public class ChromeTests
{
    [TestMethod]
    [TestCategory("CI")]
    public void ChromeTest1()
    {
        Thread.Sleep(87);
    }

    [TestMethod]
    public void ChromeTest2()
    {
        Console.WriteLine("EXECUTEs ChromeTest2");
        Thread.Sleep(14);
    }

    [TestMethod]
    public void ChromeTest3()
    {
        Thread.Sleep(88);
    }

    [TestMethod]
    public void ChromeTest4()
    {
        Thread.Sleep(44);
    }

    [TestMethod]
    public void ChromeTest5()
    {
        Thread.Sleep(66);
    }

    [TestMethod]
    [TestCategory("CI")]
    public void ChromeTest12()
    {
        Thread.Sleep(1000);
    }

    [TestMethod]
    public void ChromeTest22()
    {
        Thread.Sleep(55);
    }

    [TestMethod]
    public void ChromeTest33()
    {
        Thread.Sleep(50);
    }

    [TestMethod]
    public void ChromeTest43()
    {
        Thread.Sleep(50);
    }

    [TestMethod]
    public void ChromeTest53()
    {
        Thread.Sleep(50);
    }
}
