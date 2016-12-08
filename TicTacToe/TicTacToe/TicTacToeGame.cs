using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class TicTacToeGame
    {
        string player1;
        string player2;
        string playerChoice;
        int turnCount = 1;
        bool validGuess = false;
        string[] board = new string[] { "", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        bool gameOver = false;

        public void PlayGame()
        {
            GetPlayerNames();
            while (gameOver != true)
            {
                GetPlayerChoice();
                CheckWinOrTie();
            }
            Console.ReadLine();
        }

        public void CheckWinOrTie()
        {
            //Check All combos for 3 Xs(3 horizontal, 3 vert, 2 diag
            if (board[1] == "X" && board[2] == "X" && board[3] == "X" ||
                board[4] == "X" && board[5] == "X" && board[6] == "X" ||
                board[7] == "X" && board[8] == "X" && board[9] == "X" ||
                board[1] == "X" && board[4] == "X" && board[7] == "X" ||
                board[2] == "X" && board[5] == "X" && board[8] == "X" ||
                board[3] == "X" && board[6] == "X" && board[9] == "X" ||
                board[1] == "X" && board[5] == "X" && board[9] == "X" ||
                board[3] == "X" && board[5] == "X" && board[7] == "X")
            {
                Console.WriteLine("{0} wins !", player1);
                DisplayBoard();
                gameOver = true;
            }
            else if (board[1] == "O" && board[2] == "O" && board[3] == "O" ||
                     board[4] == "O" && board[5] == "O" && board[6] == "O" ||
                     board[7] == "O" && board[8] == "O" && board[9] == "O" ||
                     board[1] == "O" && board[4] == "O" && board[7] == "O" ||
                     board[2] == "O" && board[5] == "O" && board[8] == "O" ||
                     board[3] == "O" && board[6] == "O" && board[9] == "O" ||
                     board[1] == "O" && board[5] == "O" && board[9] == "O" ||
                     board[3] == "O" && board[5] == "O" && board[7] == "O")
            {
                Console.WriteLine("{0} wins !!", player2);
                DisplayBoard();
                gameOver = true;
            }
            else if (board[1] != "1" && board[2] != "2" && board[3] != "3" && board[4] != board[5] &&
                board[6] != "6" && board[7] != "7" && board[8] != "8" && board[9] != "9")
            {
                Console.WriteLine("Its a tie!!");
                DisplayBoard();
                gameOver = true;
            }
            else
            {
                gameOver = false;
            }

        }

        public void GetPlayerChoice()
        {
            do
            {
                if (turnCount % 2 != 0)
                {
                    Console.Clear();
                    DisplayBoard();
                    Console.Write("{0} its your turn- use the numbers to pick a square on the board:  ", player1);
                    playerChoice = Console.ReadLine();
                    int convertChoice = 0;
                    //Check if the input can be parsed
                    if (!int.TryParse(playerChoice, out convertChoice))
                    {
                        Console.WriteLine("Hey thats not a number!");
                        Console.ReadLine();
                        Console.Clear();
                        validGuess = false;
                    }
                    else
                    {
                        validGuess = checkChoice(convertChoice);
                    }
                    
                }//End of Player 1 if loop
                else
                {
                    Console.Clear();
                    DisplayBoard();
                    Console.Write("{0} its your turn- use the numbers to pick a square on the board:  ", player2);
                    playerChoice = Console.ReadLine();
                    int convertChoice = 0;
                    //Check if the input can be parsed
                    if (!int.TryParse(playerChoice, out convertChoice))
                    {
                        Console.WriteLine("Hey thats not a number!");
                        Console.ReadLine();
                        Console.Clear();
                        validGuess = false;
                    }
                    else
                    {
                        validGuess = checkChoice(convertChoice);
                    }

                } //End of Player two loop

            } while (validGuess == false);//End of valid choice While loop

        }

        public void DisplayBoard()
        {
            Console.WriteLine("   |   |");
            Console.WriteLine(" {0} | {1} | {2}", board[1], board[2], board[3]);
            Console.WriteLine("---------");
            Console.WriteLine(" {0} | {1} | {2}", board[4], board[5], board[6]);
            Console.WriteLine("---------");
            Console.WriteLine(" {0} | {1} | {2}", board[7], board[8], board[9]);
            Console.WriteLine("   |   |");

        }

        public void GetPlayerNames()
        {
            Console.Write("Player 1 what is your name?  ");
            player1 = Console.ReadLine();

            Console.Write("Player 2 what is your name?  ");
            player2 = Console.ReadLine();


        }

        public bool checkChoice(int convertChoice)
        {

            //Check if valid 1-9 integer choice choice
            if ((convertChoice >= 1 && convertChoice <= 9))
            {
                //Check if space is free
                if (board[convertChoice] != "X" && board[convertChoice] != "O")
                {
                    //Put X for player1 and O for Player two
                    if (turnCount % 2 != 0)
                    {
                        board[convertChoice] = "X";
                        Console.Clear();
                        turnCount++;
                        return true;
                    }
                    else
                    {
                        board[convertChoice] = "O";
                        Console.Clear();
                        turnCount++;
                        return true;
                    }
                }
                else
                {
                    Console.WriteLine("That square is already taken! Press enter to continue");
                    Console.ReadLine();
                    return false;

                }
            }
            else
            {
                Console.WriteLine("Thats not a valid square");
                Console.ReadLine();
                return false;
            }
        }
    }
}
