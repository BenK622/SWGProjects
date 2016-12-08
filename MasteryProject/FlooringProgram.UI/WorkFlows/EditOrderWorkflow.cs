using FlooringProgram.UI.WorkFlows;
using FlooringProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using FlooringProject.BLL;
using FlooringProject.Models.Responses;

namespace FlooringProgram.UI
{
    public class EditOrderWorkflow : RemoveOrderWorkFlow
    {
        //display and operations manager for use in the class
        DisplayManager display = new DisplayManager();
        OrderOperations ops = new OrderOperations();

        //Need to lookup account by date and order number 
        public override void Execute()
        {
            Console.Clear();
            Order order = new Order();

            //inherited from remove order class
            order = GetOrderbyDateandNumber(order);

            Order orderToEdit = CreateOrderCopy(order);

            orderToEdit = EditOrder(orderToEdit);

            SaveOrDiscardChoice(order, orderToEdit);

        }

        //Create a copy of the order to make temp changes to
        private Order CreateOrderCopy(Order order)
        {
            Order orderCopy = new Order();

            orderCopy.Area = order.Area;
            orderCopy.CustomerName = order.CustomerName;
            orderCopy.Date = order.Date;
            orderCopy.OrderNumber = order.OrderNumber;
            orderCopy.Product = order.Product;
            orderCopy.State = order.State;
            orderCopy.LaborCost = order.LaborCost;
            orderCopy.MaterialCost = order.MaterialCost;
            orderCopy.Total = order.Total;
            orderCopy.TotalTax = order.TotalTax;


            return orderCopy;
        }

        //display the order to edit and have user make edits with the edit menu
        private Order EditOrder(Order orderToEdit)
        {
            Console.Clear();

            display.DisplayOrder(orderToEdit);

            EditMenu(orderToEdit);

            return orderToEdit;
        }

        public void EditMenu(Order orderToEdit)
        {
            string input = "";
            do
            {
                Console.Clear();
                display.DisplayOrder(orderToEdit);

                Console.WriteLine("************");
                Console.WriteLine("Select a field of the order to edit");
                Console.WriteLine("1. Customer Name");
                Console.WriteLine("2. Customer State");
                Console.WriteLine("3. Date");
                Console.WriteLine("4. Area");
                Console.WriteLine("5. Product");
                Console.WriteLine();
                Console.WriteLine("6. Press (D)one to finish editing");
                Console.Write("Enter Choice: ");

                input = Console.ReadLine();

                if (input.ToUpper() != "D")
                {
                    ProcessChoice(input, orderToEdit);
                }
            } while (input.ToUpper() != "D");
        }

        //will prompt for changes on the field user wants to edit
        private void ProcessChoice(string input, Order orderToEdit)
        {
            switch (input)
            {
                case "1":
                    orderToEdit.CustomerName = EditCustomerName(orderToEdit);
                  
                    break;
                case "2":
                    orderToEdit.State = EditOrderState(orderToEdit);
                    orderToEdit = ops.CalculateOrder(orderToEdit);
                   
                    break;
                case "3":
                    orderToEdit.Date = EditOrderDate(orderToEdit);
                    
                    break;
                case "4":
                    orderToEdit.Area = EditArea(orderToEdit);
                    orderToEdit = ops.CalculateOrder(orderToEdit);
                    break;
                case "5":
                    orderToEdit.Product = EditOrderProduct(orderToEdit);                  
                    orderToEdit = ops.CalculateOrder(orderToEdit);
                    break;
                default:
                    Console.WriteLine($"{input} is not valid!");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadLine();
                    break;
            }

        }

        private Product EditOrderProduct(Order orderToEdit)
        {
            var response = new ProductResponse();
            string input;
            Product product = new Product();

            //Loop until we get a supported product from user
            do
            {
                Console.Write("What product would you like to order?  ");
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    product = orderToEdit.Product;
                    return product;
                }

                //see if the product exists
                response = ops.GetProductbyType(input);
                if (response.Success == true)
                {
                    product = response.product;
                }
                else
                {
                    Console.WriteLine(response.Message);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }

            } while (response.Success != true);

            return product;
        }

        private decimal EditArea(Order orderToEdit)
        {
            bool isValid = false;
            string input;
            decimal output;
            do
            {
                Console.Write("What is the area of the floor for the order? ");
                input = Console.ReadLine();

                //Whitespace checker for indecisive users 
                if (string.IsNullOrWhiteSpace(input))
                {
                    output = orderToEdit.Area;

                    return output;

                }

                if (!(decimal.TryParse(input, out output)))
                {
                    Console.WriteLine("Please enter a valid area for the order");
                    isValid = false;
                }
                else if(output < 1)
                {
                    Console.WriteLine("No negatives or zero please...");
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }

            } while (isValid == false);

            return output;
        }

        private DateTime EditOrderDate(Order orderToEdit)
        {
            bool valid = false;
            DateTime date = new DateTime(1999, 01, 01);
            string input;
            do
            {
                Console.Write("Please enter the date of the order(mm/dd/yyyy): ");
                input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    date = orderToEdit.Date;
                    return date;
                }

                if (DateTime.TryParse(input, out date))
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Please enter a valid date in (mm/dd/yyyy format");
                    valid = false;
                }

            } while (valid == false);

            return date;
        }

        private string EditCustomerName(Order ordertoEdit)
        {
            string name;

            Console.WriteLine("Please Enter new customer name: ");

            name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                name = ordertoEdit.CustomerName;
            }

            return name;

        }

        //Will either save or discard choice based on user input
        public void SaveOrDiscardChoice(Order order, Order editedOrder)
        {
            string input;

            do
            {
                Console.WriteLine("Do you want to save this order? Y/N ");
                input = Console.ReadLine();
                input = input.ToUpper();

                switch (input)
                {
                    case "Y":
                        Console.WriteLine("Saving edited order....");
                        Thread.Sleep(2000);
                        ops.RemoveOrder(order);
                        var response = ops.SaveEditedOrder(editedOrder, order);
                        Console.Clear();
                        display.DisplayOrder(response.order);
                        Console.WriteLine("Returning to Main Menu...");
                        Thread.Sleep(2000);
                        break;
                    case "N":
                        Console.WriteLine("Abadoning order...");
                        Console.WriteLine("Returning to Main Menu");
                        Thread.Sleep(2000);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input");
                        break;
                }

            } while (input != "Y" && input != "N");

        }

        //Returns order thats being edited if blank or new state if supported
        public State EditOrderState(Order ordertoEdit)
        {
            var ops = new OrderOperations();
            var response = new StateResponse();
            response.Success = false;
            string input;
            State state = new State();

            //Loop until we get a supported state from the user  or return original state if blank string
            do
            {
                Console.Write("What state is the order for? ");
                input = Console.ReadLine().ToUpper();

                if (string.IsNullOrWhiteSpace(input))
                {
                    state = ordertoEdit.State;
                    return state;
                }

                //  See if state exists by checking full list of supported states
                response = ops.GetStatebyNameorAbbr(input);

                if (response.Success == true)
                {
                    state = response.State;
                }
                else
                {
                    Console.WriteLine(response.Message);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }

            } while (response.Success != true);

            //if state exists get info for that state 

            return state;

        }
    }
}
