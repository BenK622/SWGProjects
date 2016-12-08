using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TicTacToe;


namespace TicTacToeTest
{
    [TestFixture]
    public class TicTacToeTests
    {
        TicTacToeGame obj = new  TicTacToe.TicTacToeGame();

        [TestCase(10, false)]
        [TestCase(4, true)]
        [TestCase(32, false)]
        [TestCase(1, true)]
        public void checkChoiceTest(int convertChoice, bool expected)
        {
            bool actual = obj.checkChoice(convertChoice);

            Assert.AreEqual(actual, expected);
        }  
    }
}
