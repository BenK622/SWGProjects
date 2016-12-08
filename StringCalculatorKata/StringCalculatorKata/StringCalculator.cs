using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StringCalculatorKata
{
    public class StringCalculator
    {
        public int Add(string numbers)
        {
            int sum = 0;
            bool isNegative = false;
            Regex re = new Regex(@"-?\d+");
            MatchCollection isNumber = re.Matches(numbers);
            string negoutput = null;
            foreach (Match m in isNumber)
            {
                for (int i = 0; i < m.Groups.Count; i++)
                {
                    int tempSum = int.Parse(m.Groups[i].Value);
                    if (tempSum < 0)
                    {
                        isNegative = true;
                        negoutput += m.Groups[i].Value + ",";
                    }
                    else
                    {
                        if(tempSum <= 1000)
                        {
                            sum += tempSum;
                        }  
                    }
                }
            }//end of for each
            if (isNegative == true)
            {
                sum = -99;

                negoutput = negoutput.Substring(0, negoutput.Length-1);
                Console.WriteLine("Negative numbers not allowed {0}", negoutput);
            }
            return sum;
        }
    }
}
