using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorizor
{
    public class FactorizorGame
    {
        int number;
        int pTest;
        int numberofFactors;

        public void Start()
        {
            Console.WriteLine("Welcome to Factorizor!");

            //Get the number from Player
            number = GetNumber();

            //Get how many factors for the number(use for test) also print out factors
            FactorNumber(number);

            //Check to see if perfect or prime, return true or false
            IsPerfectOrPrime(number, numberofFactors);

        }

        public bool IsPerfectOrPrime(int number, int numberofFactors)
        {
            if(pTest == number)
            {
                Console.WriteLine("{0} is a perfect number", number);
                return true;
            }
            else if(numberofFactors == 1)
            {
                Console.WriteLine("{0} is a prime number", number);
                return true;
            }
            else
            {
                Console.WriteLine("{0} is not a prime or perfect number", number);
                return false;
            }
            
        }

        public int FactorNumber(int number)
        {
            Console.WriteLine("The factors of {0} are: ",number);


            for (int i = 1; i <= number/2; i++)
            {
                if(number % i == 0)
                {
                    Console.WriteLine(i);
                    pTest += i;
                    numberofFactors++;
                }
            }
            return numberofFactors;
        }

        public int GetNumber()
        {
            bool validinput = false;
            while(validinput == false)
            {
                Console.Write("Please enter the number you would like to Factorize: ");
                string inputNumber = Console.ReadLine();
                if (int.TryParse(inputNumber, out number))
                {
                    validinput = true;
                }
                else
                {
                    Console.WriteLine("Why dont you try a number?");
                    validinput = false;
                }

            }
            return number;
        }
    }
}
