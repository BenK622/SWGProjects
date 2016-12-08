using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissors.Enums;

namespace RockPaperScissors
{
    class HumanPlayer : IPlayer
    {
        public string playerName { get; set; }
        public string playerType { get; private set; }

        public HumanPlayer()
        {
            this.playerType = "Human";
        }


        public Choice GetChoice()
        {
            Choice result;

            InputManger input = new InputManger();

            string choice = input.GetPlayerChoice(this.playerName);

            

            switch (choice)
            {
                case "R":
                    result = Choice.Rock;
                    break;
                case "P":
                    result = Choice.Paper;
                    break;
                case "S":
                    result = Choice.Scissors;
                    break;
                default:
                    throw new NotSupportedException(String.Format("{0} is not a valid choice!", choice));
            }

            return result;
            
        }
    }
}
