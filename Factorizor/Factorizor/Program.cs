using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor
{
    class Program
    {
        static void Main(string[] args)
        {
            FactorizorGame game = new FactorizorGame();

            game.Start();

            Console.ReadLine();
        }
    }
}
