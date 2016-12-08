using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToeGame newGame = new TicTacToeGame();

            newGame.PlayGame();

            Console.ReadLine();
        }
    }
}
