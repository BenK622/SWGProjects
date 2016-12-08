using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RockPaperScissors
{
    public class InputManger
    {

        public string GetPLayerName(string player)
        {
            Console.Write($"{player} what is your name?");
            string playerName = Console.ReadLine();
            return playerName; 
        }

        public string OppChoice()
        {
            Console.Write($"What type of player would you like to play? (C)omputer or (H)uman?");
            string choice = Console.ReadLine();
            return choice;

        }

        public string GetPlayerChoice(string player)
        {
            Console.Write($"{player} choose (R)ock, (P)aper or (S)cissors");
            string choice = Console.ReadLine();
            return choice;

        }


    }
}
