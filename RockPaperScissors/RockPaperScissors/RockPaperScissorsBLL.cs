using RockPaperScissors.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class RockPaperScissorsBLL
    {
        private IPlayer _playerSelect;

        public IPlayer OpponentSelect(string choice)
        {
            //Will use factory pattern to get the correct player object 
            return _playerSelect = PlayerFactory.CreatePlayer(choice);

        }

        public Response CheckChoice(Choice p1Choice, Choice p2Choice)
        {
            //response will just go to player 1- binary choice 

            if (p1Choice == p2Choice)
            {
                return Response.Tie;
            }
            else if ((p1Choice == Choice.Rock && p2Choice == Choice.Scissors) ||
                    (p1Choice == Choice.Scissors && p2Choice == Choice.Paper) ||
                    (p1Choice == Choice.Paper && p2Choice == Choice.Rock))
            {
                return Response.Win;
            }
            else
            {
                return Response.Lose;

            }

        }
    }
}
