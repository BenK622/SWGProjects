using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups
{
    public class LogicWarmups
    {
        public bool LastDigit(int a, int b, int c)
        {
            if (a % 10 == b % 10 || b % 10 == c % 10 || a % 10 == c %10)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        /*14. Given three ints, a b c, return true if b is greater than a, and c is greater 
         * than b. However, with the exception that if "bOk" is true, b does not need to be 
         greater than a.*/
         public bool AreInOrder(int a, int b, int c, bool bOk)
        {
            if( (a > b || b > c ) && bOk == false)
            {
                return false;
            }
            else if(b > c)
            {
                return false;
            }
            else
            {
                return true;
            }

  
        }

        /*15. Given three ints, a b c, return true if they are in strict 
         * increasing order, such as 2 5 11, or 5 6 7, but not 6 5 7 or 5 5 7. 
         * However, with the exception that if "equalOk" is true, equality is allowed, 
         * such as 5 5 7 or 5 5 5. */
        public bool InOrderEqual(int a, int b, int c, bool equalOk)
        {
            if (a > b)
            {
                return false;
            }
            else if ((a >= b || b >= c) && equalOk == false) 
            {
                return false;
            }
            else
            {
                return true;
            }

        }

    }
}
