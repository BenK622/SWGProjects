using FlooringProgram.UI.WorkFlows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProgram.UI
{
    public class Menu
    {
        public void Display()
        {
            string input = "";
            do
            {
                Console.Clear();
                Console.WriteLine("****************************");
                Console.WriteLine("Flooring Program");
                Console.WriteLine("****************************");
                Console.WriteLine("1. Display Order");
                Console.WriteLine("2. Add an Order");
                Console.WriteLine("3. Edit an Order");
                Console.WriteLine("4. Remove an Order");

                Console.WriteLine("5. (Q) to Quit");
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Enter Choice: ");

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
                    var displayOrderWf = new DisplayOrderWorkflow();
                    displayOrderWf.Execute();
                    break;
                case "2":
                    var addOrder = new AddOrderWorkflow();
                    addOrder.Execute();
                    break;
                case "3":
                    var editOrder = new EditOrderWorkflow();
                    editOrder.Execute();
                    break;
                case "4":
                    var removeOrder = new RemoveOrderWorkFlow();
                    removeOrder.Execute();
                    break;
                default:
                    Console.WriteLine($"{choice} is not valid!");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }  
    }
}
