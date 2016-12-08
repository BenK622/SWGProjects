using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissors.Enums;


namespace RockPaperScissors
{
    public class ComputerPlayer : IPlayer
    {
       public  string playerName { get; set; }
        public string playerType { get; private set; }

        public ComputerPlayer() 
        {
            playerName = "ComputerPlayer";
            playerType = "Computer";
        }

        public Choice GetChoice()
        {
            Random rng = new Random();
            Choice result = Choice.Unknown;
            int number = rng.Next(1, 4);
           // result = Enum.GetName(typeof(Choice), number);  How can I get this to work?

            switch (number)
            {
                case 1:
                    result = Choice.Rock;
                    break;
                case 2 :
                    result = Choice.Paper;
                    break;
                case 3:
                    result = Choice.Scissors;
                    break;
            }

            return result;

        }
    }
}
