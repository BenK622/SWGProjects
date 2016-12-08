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
    class LoopWarmupsTest
    {
        LoopWarmups obj = new LoopWarmups();

        [TestCase(new int[]{1, 1, 2, 3, 1}, true)]
        [TestCase(new int[] { 1, 1, 2, 4, 1 }, false)]
        [TestCase(new int[] { 1, 1, 2, 1, 2, 3 }, true)]
        public void Array123_Test(int[] numbers, bool expected)
        {
            bool actual = obj.Array123(numbers);

            Assert.AreEqual(expected, actual);

        }

        [TestCase(new int []{6, 6, 2}, 1)]
        [TestCase(new int[]{ 6, 6, 2, 6}, 1)]
        [TestCase(new int[]{ 6, 7, 2, 6 }, 1)]
        public void Array667_Test(int[] numbers, int expected)
        {
            int actual = obj.Array667(numbers);

            Assert.AreEqual(expected, actual);
        }

        [TestCase("axxbb", true)]
        [TestCase("axaxxax", false)]
        [TestCase("xxxxx", true)]
        public void DoubleX_Test(string str, bool expected)
        {
            bool actual = obj.DoubleX(str);

            Assert.AreEqual(expected, actual);
        }


    }
}

