﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            DiceGameClass obj = new DiceGameClass();

            obj.GetDiceRolls(obj.GetDictionary());

            Console.ReadLine();

        }
    }
}
