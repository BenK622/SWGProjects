using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGame
{
    public class DiceGameClass
    {

        public void RollDice()
        {
            
            GetDiceRolls(GetDictionary());
            
        }

        public Dictionary<int, int> GetDictionary()
        {
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 2; i < 13; i++)
            {
                numbers.Add(i, 0);
            }
            return numbers;

        }

        public void GetDiceRolls(Dictionary<int, int> numbers)
        {
            Random rng = new Random();

            int dice1;
            int dice2;
            int sum;
            int currentcount = 0;


            for (int i = 0; i < 101; i++)
            {
                dice1 = rng.Next(1, 7);
                dice2 = rng.Next(1, 7);

                sum = dice1 + dice2;

                numbers.TryGetValue(sum, out currentcount);

                numbers[sum] = currentcount + 1;
            }

            foreach(KeyValuePair<int, int> kvp in numbers)
            {
                Console.WriteLine("Roll= {0}, Times = {1}", kvp.Key, kvp.Value);
            }



        }

    }


}
