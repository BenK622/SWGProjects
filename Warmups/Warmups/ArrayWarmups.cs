using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups
{
    public class ArrayWarmups
    {
        /*10.Given an int array , return true if it contains an even number (HINT: Use Mod (%)). */
        public bool HasEven(int[] numbers)
        {
            bool output = false;

            for (int i = 0; i < numbers.Length; i++)
            {
                if(numbers[i] % 2 == 0)
                {
                    output = true;
                }
            }

            return output;
        }

        /* 11. Given an int array, return a new array with double the length where its last element 
         * is the same as the original array, and all the other elements are 0. The original array 
         * will be length 1 or more. Note: by default, a new int array contains all 0's. */
        public int[] KeepLast(int[] numbers)
        {
            int[] output = new int[numbers.Length * 2];

            output[output.Length-1] = numbers[numbers.Length-1];

            return output;

        }

    }
}
