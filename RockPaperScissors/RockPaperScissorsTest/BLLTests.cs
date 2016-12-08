using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RockPaperScissors.Enums;
using RockPaperScissors;


namespace RockPaperScissorsTest
{
    [TestFixture]
    class BLLTests
    {
        RockPaperScissorsBLL obj = new RockPaperScissorsBLL();

        [TestCase(Choice.Paper, Choice.Rock, Response.Win)]
        [TestCase(Choice.Paper, Choice.Paper, Response.Tie)]
        [TestCase(Choice.Scissors, Choice.Rock, Response.Lose)]
        public void CompareResultTest(Choice p1, Choice p2, Response expected)
        {
            Response actual = obj.CheckChoice(p1, p2);

            Assert.AreEqual(expected, actual);

        }


        [TestCase("C", "ComputerPlayer")]
        public void PlayerCreateTest(string choice, string expectedName)
        {
            IPlayer player = PlayerFactory.CreatePlayer(choice);

            Assert.AreEqual(expectedName, player.playerName);

        }

    }
}
