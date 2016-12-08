using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warmups
{
    public class StringWarmups
    {
        public string SayHi(string name)
        {
            return string.Format("Hello {0}!", name);
        }

        public string Abba(string a, string b)
        {
            return a + b + b + a;

        }

        public string MakeTags(string tag, string content)
        {
            return string.Format("<{0}>{1}<{0}>", tag, content);
        }

        /* Given an "out" string length 4, such as "<<>>", and a word, 
         * return a new string where the word is in the middle of the out string, 
         * e.g. "<<word>>".*/
        public string InsertWord(string container, string word)
        {
            return container.Substring(0, 2) + word + container.Substring(2, 2);

        }

        /*Given a string, return a new string made of 3 copies of the last 2 chars
         *  of the original string. The string length will be at least 2. */
        public string MultipleEndings(string str)
        {
            string end = str.Substring(str.Length - 2, 2);

            return end + end + end;
        }

        /*Given a string of even length, return the first half. So the string 
         * "WooHoo" yields "Woo". */

        public string FirstHalf(string str)
        {
            return str.Substring(0, str.Length / 2);
        }

        /*Given a string, return a version without the first 2 chars.
         * Except keep the first char if it is 'a' and keep the 
         * second char if it is 'b'. The string may be any length.*/
        public string TweakFront(string str)
        {
            if (str.Substring(0, 1) == "a" && str.Substring(1, 1) != "b")
            {
                return str.Remove(1, 1);
            }
            else if (str.Substring(1, 1) == "b" && str.Substring(0, 1) != "a")
            {
                return str.Remove(0, 1);
            }
            else if (str.Substring(0, 1) == "a" && str.Substring(1, 1) == "b")
            {
                return str;
            }
            else
            {
                return str.Remove(0, 2);
            }
        }

        /*Given a string, return true if "bad" appears starting at index 0 or 1
         * in the string, such as with "badxxx" or "xbadxx" but not "xxbadxx". 
         * The string may be any length, including 0.*/
        public bool HasBad(string str)
        {
            if (str.Substring(0, 3) == "bad" || str.Substring(1, 3) == "bad")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string RotateRight2(string str)
        {
            return str.Substring(str.Length - 2, 2) + str.Substring(0, str.Length - 2);
        }

        /*Given a string and an index, return a string length 2 starting at the given index.
         *  If the index is too big or too small to define a string length 2, use the first 2 chars.
         *   The string length will be at least 2. */
        public string TakeTwoFromPosition(string str, int n)
        {
            if(n > str.Length - 2)
            {
                return str.Substring(0, 2);
            }
            else
            {
                return str.Substring(n, 2);
            }

            
        }

        

     }
}
