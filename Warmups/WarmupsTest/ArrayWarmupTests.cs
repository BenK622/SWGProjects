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
    class ArrayWarmupTests
    {
        ArrayWarmups obj = new ArrayWarmups();

        [TestCase(new int[] { 2, 5  }, true)]
        [TestCase(new int[] { 4, 3 }, true)]
        [TestCase(new int[] { 7, 5 }, false)]
        public void HasEven_Test(int[] numbers, bool expected)
        {
            bool actual = obj.HasEven(numbers);

            Assert.AreEqual(actual, expected);
        }

        [TestCase(new int[] { 4, 5, 6 }, new int[] { 0, 0, 0, 0, 0, 6 })]
        [TestCase(new int[] { 1, 2 }, new int[] { 0, 0, 0, 2 })]
        [TestCase(new int[] { 3 }, new int[] { 0, 3 })]
        public void KeepLast(int[] numbers, int[] expected)
        {
            int[] actual = obj.KeepLast(numbers);

            Assert.AreEqual(actual, expected);
        }
    }
}
