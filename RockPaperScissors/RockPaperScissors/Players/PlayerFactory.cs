using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    public class PlayerFactory
    {
        public static IPlayer CreatePlayer(string playerChoice)
        {

            switch (playerChoice.ToUpper())
            {
                case "C":
                    return new ComputerPlayer();
                case "H":
                    return new HumanPlayer();
                case "CT":
                    return new TestComputerPlayer();
                default:
                    throw new NotSupportedException(String.Format("{0} is not a valid choice!", playerChoice));

            }
            //swtich statement depending on choice of player to instantiate 
           
        }
    }
}
