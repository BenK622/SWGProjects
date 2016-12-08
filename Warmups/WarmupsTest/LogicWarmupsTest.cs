using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Warmups;

namespace WarmupsTest
{
    [TestFixture]
    class LogicWarmupsTest
    {

        LogicWarmups obj = new LogicWarmups();

        [TestCase(1, 2, 4, false,true)]
        [TestCase(1, 2, 1, false, false)]
        [TestCase(1, 1, 2, true, true)]
        public void AreInOrder_Test(int a, int b, int c, bool bOk, bool expected)
        {
            bool actual = obj.AreInOrder(a, b, c, bOk);

            Assert.AreEqual(actual, expected);
        }

        [TestCase(2, 5, 11, false, true)]
        [TestCase(5, 7, 6, false, false)]
        [TestCase(5, 5, 7, true, true)]
        public void InOrderEqual_Test(int a, int b, int c, bool equalOk, bool expected)
        {
            bool actual = obj.InOrderEqual(a, b, c, equalOk);

            Assert.AreEqual(expected, actual);
        }

    }
}
