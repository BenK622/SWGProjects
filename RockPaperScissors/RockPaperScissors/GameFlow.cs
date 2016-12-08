using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RockPaperScissors.Enums;


namespace RockPaperScissors
{
    class GameFlow
    {
        HumanPlayer player1 = new HumanPlayer();
        IPlayer player2;
        InputManger input = new InputManger();
        RockPaperScissorsBLL bll = new RockPaperScissorsBLL();

        public void StartGame()
        {
            

            //Select Human or Comp opponent, set names- Will have players ready to go after this 
            SelectPlayers();
            //Get Choices from the players and evaluate 
            GetChoices();
            //Play Again Method 

        
        }

        private void GetChoices()
        {

            string choice = input.GetPlayerChoice(player1.playerName);

            Choice player1Choice = player1.GetChoice();
            Choice player2Choice = player2.GetChoice();

            Response result = bll.CheckChoice(player1Choice, player2Choice);

            ReturnWinner(result);

            Console.WriteLine(result);
            
            //Get player choices, R, P or S. Use choice selector method 
            
        }

        private string ReturnWinner(Response result)
        {
            if(result == Response.Win)
            {
                return $"{player1.playerName} wins!";

            }
            else if(result == Response.Tie)
            {
                return "Its a tie!";
            }
            else
            {
                return $"{player2.playerName} wins!";
            }
        }

        private void  SelectPlayers()
        {
            //Get Name of first player
            player1.playerName = input.GetPLayerName("Player 1");
            //Input manger get- selection for computer or human player, use BLL to get to the factory to creat object
            player2 = bll.OpponentSelect(input.OppChoice());
            //If human prompt for name
            if(player2.playerType == "Human")
            {
                player2.playerName = input.GetPLayerName("Player 2");
            }

          
        }
    }
}
