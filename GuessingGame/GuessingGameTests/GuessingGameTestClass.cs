using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using GuessingGame;

namespace GuessingGameTests
{
    [TestFixture]
    public class GuessingGameTestClass
    {
        GuessingGameCl obj = new GuessingGameCl();

        [TestCase(5,5, true)]
        [TestCase(7, 5, false)]
        public void Test_for_Win(int input, int answer, bool expected)
        {
            bool actual = obj.CheckWin(input, answer);

            Assert.AreEqual(expected, actual);
        }
    }
}
