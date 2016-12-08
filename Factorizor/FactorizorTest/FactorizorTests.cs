using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Factorizor;



namespace FactorizorTest
{
    [TestFixture]
    class FactorizorTests
    {
        FactorizorGame obj = new FactorizorGame();

        [TestCase(6, 3)]
        [TestCase(8, 3)]
        [TestCase(2, 1)]
        [TestCase(20, 5)]
        public void Factorizor_NumberofFactors_Test(int number, int expected)
        {
            int actual = obj.FactorNumber(number);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(6, 3, true)]
        [TestCase(5, 1, true)]
        [TestCase(12, 5, false)]
        public void Factorizor_Prime_or_Perfect_Test(int number, int numberofFactors, bool expected)
        {
            bool actual = obj.IsPerfectOrPrime(number, numberofFactors);

            Assert.AreEqual(expected, actual);
        }
    }
}
