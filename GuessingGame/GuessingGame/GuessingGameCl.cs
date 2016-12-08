using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessingGame
{
    public class GuessingGameCl
    {
        string name = "";
        Random rnd = new Random();
        int timesGuessed = 1;
        int numberGuessed;
        
        bool win = false;
        bool quit = false;
        int NumberToBeGuessed;
       

        public void StartGame()
        {
            
            Console.WriteLine("Welcome to the guessing game");
            Console.WriteLine("Please enter your name: ");
            name = Console.ReadLine();
            // Creat list for containing player guesses
            var numbersAlreadyGuessed = new List<int>();

            do
            {
                Console.Clear();
                NumberToBeGuessed = rnd.Next(1, 21);
                
                do
                {
                    Console.WriteLine("Press enter to continue");

                    Console.ReadLine();
                    
                    Console.Clear();
                    //sets the number the player guesses(also checks if its a number)
                    numberGuessed = GetPlayerGuess(numbersAlreadyGuessed);

                    //will check if number is in range and hasnt been guess already, will also check for win
                    win = CheckWin(numberGuessed, NumberToBeGuessed);

                    numbersAlreadyGuessed.Add(numberGuessed);

                } while (win == false); //if the number is good and they won will break out

                PrintNumbersGuessed(numbersAlreadyGuessed);


                //check to see if player wants to play again 
                quit = PlayAgain();
            } while (quit == false);

        }

        private void PrintNumbersGuessed(List<int> numbersAlreadyGuessed)
        {
            Console.WriteLine("Here are the numbers you guessed:");

            foreach (var number in numbersAlreadyGuessed)
            {
                Console.WriteLine($"{number}");
            }

            //Clear the list of guessed numbers 
            numbersAlreadyGuessed.Clear();
        }

        public bool PlayAgain()
        {
            Console.WriteLine("Press any key if you want to play again or Q to quit");
            string input = Console.ReadLine();

            if (input.ToUpper() == "Q")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckWin(int numberGuessed, int NumberToBeGuessed)
        {

            
            if(numberGuessed == NumberToBeGuessed && timesGuessed == 1)
            {
                Console.WriteLine("WOW you won on the first guess, nice!!");
                return true;
                    
            }
            else if (numberGuessed == NumberToBeGuessed)
            {
                Console.WriteLine("Nice Guess, you win");
                Console.WriteLine("It took you {0} tries ", timesGuessed);
                return true;
            }
            else
            {
                Console.WriteLine("Its not {0}, try again", numberGuessed);
                timesGuessed++;
                return false;
            }
 
        }

        public int GetPlayerGuess(List<int> numbersAlreadyGuessed)
        {
            
            bool isValidNumber = false;
            while (isValidNumber == false)
            {
                Console.Write("{0}, please enter a number between 1 and 20: ", name);
                string input = Console.ReadLine();

                if (!int.TryParse(input, out numberGuessed))
                {
                    Console.WriteLine("Thats not a number, please guess a number");
                    isValidNumber = false;
                }
                else if(!(numberGuessed <= 20 && numberGuessed >= 1))
                {
                    Console.WriteLine("Please guess a number 1-20");
                    isValidNumber = false;
                }
                else if(numbersAlreadyGuessed.Contains(numberGuessed))
                {
                    Console.WriteLine("That number has already been guessed!");
                    isValidNumber = false;
                }
                else
                {
                   
                    isValidNumber = true;
                   
                }
            }

            return numberGuessed;


            
        }
    }
}
