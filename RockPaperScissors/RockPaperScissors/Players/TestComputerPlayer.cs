using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissors.Enums;

namespace RockPaperScissors
{
    class TestComputerPlayer : IPlayer
    {
        public string playerName { get; set; }
        public string playerType { get; private set; }

        public TestComputerPlayer()
        {
            playerName = "Computer";
            playerType = "Computer";
        }

        public Choice GetChoice()
        {
            Choice result = Choice.Paper;

            return result;
        }
    }
}
