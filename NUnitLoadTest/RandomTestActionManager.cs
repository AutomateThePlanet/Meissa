using System;
using System.Threading;
using NUnit.Framework;

namespace NUnitLoadTest
{
    public static class RandomTestActionManager
    {
        public static void PerformRandomAction()
        {
            var random = new Random();
            if (random.Next(10) % 2 == 0)
            {
                Assert.Fail("RandomlyFailed");
            }
            else
            {
                Thread.Sleep(random.Next(100));
            }
        }
    }
}
