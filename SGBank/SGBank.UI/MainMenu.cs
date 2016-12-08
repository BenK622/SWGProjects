using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.UI
{
    public class MainMenu
    {

        public void Display()
        {
            string input = "";

            do
            {
                Console.Clear();
                Console.WriteLine("WELCOME TO SGBANK!");
                Console.WriteLine("-------------------");
                Console.WriteLine("1. Lookup Account");
                Console.WriteLine("2. Open Account");
                Console.WriteLine();
                Console.WriteLine("(Q) to Quit");
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("Enter Choice: ");

                input = Console.ReadLine();

                if (input.ToUpper() != "Q")
                {
                    ProcessChoice(input);
                }
            } while (input.ToUpper() != "Q");
        }

        private void ProcessChoice(string choice)
        {
            switch (choice)
            {
                case "1":
                    var workflow = new AppWorkFlow();
                    break;
                case "2":
                    break;
                default:
                    Console.WriteLine("Not a valid choice ");
                    Console.WriteLine("Press enter to continue....");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
