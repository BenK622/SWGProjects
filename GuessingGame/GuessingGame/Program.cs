using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GuessingGameCl game = new GuessingGameCl();

            game.StartGame();

            Console.ReadLine();
            
            
            /*Console.Write("What is your name?  ");
            string name = Console.ReadLine();


            bool playAgain = false;
            do
            {
                Program something = new Program();
                something.PlayGame(name);

                Console.Write("Do you want to play again? (Y-Yes, N-no) ");
                string response = Console.ReadLine();
                switch (response.ToUpper())
                {
                    case "Y":
                    case "YES":
                        playAgain = true;
                        break;
                    default:
                        playAgain = false;
                        break;
                }

            } while (playAgain);

            
        }

        public void PlayGame(string name)
        {


            Random rnd = new Random();
            int NumberToBeGuessed = rnd.Next(1,21);
            int timesGuessed = 1;
            bool isValid = false; 
            do
            {
                Console.Write("{0}, please enter a number between 1 and 20: ", name);
                string input = Console.ReadLine();
                int numberGuessed;
                isValid = int.TryParse(input, out numberGuessed);
                if (isValid) //its a number 
                {
                    if(!(numberGuessed <= 20 && numberGuessed >= 1))
                    {
                        Console.WriteLine("The number needs to be between 1 and 20");
                        isValid = false;
                    }
                    else
                    {
                        if(numberGuessed == NumberToBeGuessed)
                        {
                            if(numberGuessed == NumberToBeGuessed && timesGuessed == 1)
                            {
                                Console.WriteLine("YOU GUESSED it WRITE FIST TRY!");
                            }
                            else
                            {
                                Console.WriteLine("//////////////\nYOU WIN!!\n/////////");
                                Console.WriteLine("It took you {0} guesses", timesGuessed);
                                break;
                            }

                        }
                        else
                        {
                            Console.WriteLine("Nope, try again...");
                            timesGuessed++;
                            isValid = false;

                        }
                    }
                }
                else //Did they type Q?
                {
                    if(input.ToUpper() == "Q")
                    {
                        return;
                        
                    }

                    Console.WriteLine("{0} please enter a number");
                }
            } while (!isValid);*/


        }
    }
}
