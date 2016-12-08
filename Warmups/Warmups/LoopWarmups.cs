using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups
{
    public class LoopWarmups
    {
        /* 4. Given a string, return true if the first instance of "x" in the string is 
         * immediately followed by another "x"*/
        public bool DoubleX(string str)
        {
            bool output = false;

            for (int i = 0; i < str.Length-1; i++)
            {
                if(str[i] == 'x' && str[i + 1] != 'x')
                {
                    output = false;
                    break;
                }
                else if(str[i] == 'x' && str[i + 1] == 'x')
                {
                    output = true;
                    break;
                }
                else
                {
                    output = false;
                }
            }

            return output; 

        }

        /* 10. Given an array of ints, return true if .. 1, 2, 3, .. appears in the array somewhere. */
        public bool Array123(int[] numbers)
        {
            bool isTrue = false;

            for (int i = 0; i < numbers.Length-2; i++)
            {
                if (numbers[i] == 1 && numbers[i + 1] == 2 && numbers[i + 2] == 3)
                {
                    isTrue = true;
                    return isTrue;
                }
 
            }

            return isTrue;

        }

        /* 15. Given an array of ints, return the number of times that two 6's 
         * are next to each other in the array. Also count instances where the second 
         * "6" is actually a 7. */
        public int Array667(int[] numbers)
        {
            int count = 0;

            for (int i = 0; i < numbers.Length-1; i++)
            {
                if (numbers[i] == 6 && (numbers[i + 1] == 6 || numbers[i + 1] == 7))
                {
                    count++;
                }
            }
            return count;
        }


    }
}
