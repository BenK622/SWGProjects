using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups
{
    public class ConditionalWarmups
    {
        /* 1. We have two children, a and b, and the parameters aSmile and 
         bSmile indicate if each is smiling. We are in trouble if they 
        are both smiling or if neither of them is smiling. Return true 
        if we are in trouble. */
        public bool AreWeInTrouble(bool aSmile, bool bSmile)
        {
            if (aSmile && bSmile)
                return true;

            if (!aSmile && !bSmile)
                return true;

            return false;
        }

        /* 4. Given an int n, return the absolute value of the difference between n and 21,
       except return double the absolute value of the difference if n is over 21. */
        public int Diff21(int n)
        {
            if (n <= 21)
            {
                return 21 - n;
            }
            else
            {
                return (n - 21) * 2;
            }

        }

        /* 5. We have a loud talking parrot. The "hour" parameter is the current hour time in the range 0..23. 
        * We are in trouble if the parrot is talking and 
        * the hour is before 7 or after 20. Return true if we are in trouble. */
        public bool ParrotTrouble(bool isTalking, int hour)
        {
            if (isTalking == false)
            {
                return false;

            }
            else if (hour >= 7 && hour <= 20)
            {
                return false;

            }
            else
            {
                return true;
            }
        }


        /* 10. Given a non-empty string and an int n, return a new string 
         * where the char at index n has been removed. The value of n will
         *  be a valid index of a char in the original string */
        public string MissingChar(string str, int n)
        {
            string final = null;

            for (int i = 0; i < str.Length; i++)
            { 
                if(i != n)
                {
                    final += str[i];
                }
               

            }

            return final;
        }

        /*15. Given a string, return true if the string starts with 
         * "hi" and false otherwise. */
        public bool StartHi(string str)
        {
            if (str.Length == 2 && str.Substring(0, 2) == "hi")
            {
                return true;
            }
            else if (str.Substring(0, 2) == "hi" && str.Substring(2, 1) == " ")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /* 20. Given a string, if the string "del" appears starting at index 1, 
         * return a string where that "del" has been deleted. Otherwise, return 
         * the string unchanged.*/
        public string RemoveDel(string str)
        {
            if(str.Substring(1,3) == "del")
            {
                return str.Replace("del", "");
            }
            else
            {
                return str;
            }
        }
    }
}
