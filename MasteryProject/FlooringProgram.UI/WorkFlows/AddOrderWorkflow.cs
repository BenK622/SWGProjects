using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProject.Models;
using FlooringProject.BLL;
using FlooringProject.Models.Responses;
using System.Threading;

namespace FlooringProgram.UI
{
    public class AddOrderWorkflow 
    {
        OrderOperations ops = new OrderOperations();
        DisplayManager display = new DisplayManager();

        public virtual void Execute()
        {
            Order order = new Order();

            Console.Clear();

            order = GetOrderInfoFromUser(order);

            order = ops.CalculateOrder(order);

            SaveOrderChoice(order);


            Menu menu = new Menu();
            menu.Display();

            // ProcessOrder(order);
        }

        //prompts whether user wants to save their new order
        public virtual void SaveOrderChoice(Order order)
        {
            string input;

            do
            {
                Console.Clear();

                display.DisplayOrder(order);
                
                Console.WriteLine("Do you want to save this order? Y/N ");
                input = Console.ReadLine();
                input = input.ToUpper();

                switch (input)
                {
                    case "Y":
                        Console.WriteLine("Saving order....");
                        Thread.Sleep(1000);
                        SaveOrderToRepo(order);
                        break;
                    case "N":
                        Console.WriteLine("Abadoning order...returning to main menu");
                        Thread.Sleep(1500);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input");
                        Thread.Sleep(750);
                        break;
                }

            } while (input != "Y" && input != "N");

        }

        //saves the order to the order repo
        public void SaveOrderToRepo(Order order)
        {
            var response = new OrderReponse();
            Console.Clear();

            response = ops.SaveNewOrder(order);

            Console.WriteLine("Successfully Saved the following order: ");
            display.DisplayOrder(order);
            Console.WriteLine("Returning to main menu....");
            Thread.Sleep(4000);
            
            
        }

        //manager for the necessary order inputs 
        private Order GetOrderInfoFromUser(Order order)
        {
            order.Date = GetOrderDate();
            order.CustomerName = GetCustomerName();
            order.State = GetOrderState();     
            order.Area = GetArea();
            order.Product = GetOrderProduct();
            

            return order;
        }

        // Below are the 5 pieces of information to be entered by user

            //prompt user for aea
        public decimal GetArea()
        {
            bool isValid = false;
            string input;
            decimal output;
            do
            {
                Console.Write("What is the area of the floor for the order? ");
                input = Console.ReadLine();

                if (!(decimal.TryParse(input, out output)) || string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("Please enter a valid area for the order");
                    string errorMessage = "Invalid_area_input";
                    ops.SavetoErrorLog(errorMessage);
                    isValid = false;
                }
                else if(output < 1 )
                {
                    Console.WriteLine("Area can't be negative! nice try...");
                    string errorMessage = "Tried_to_put_in_negative_area";
                    ops.SavetoErrorLog(errorMessage);
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }
                
            } while (isValid == false);

            return output;  
        }

        //Get a valid product from the user 
        public Product GetOrderProduct()
        {
            var ops = new OrderOperations();
            var response = new ProductResponse();
            string input;
            Product product = new Product();

            var productList = ops.GetProducts();

            //Loop until we get a supported product from user
            do
            {
                Console.Clear();
                display.DisplayProductList(productList);
                Console.Write("Please select a product for the order:  ");
                input = Console.ReadLine();


                //see if the product exists
                response = ops.GetProductbyType(input);
                if(response.Success == true)
                {
                    product = response.product;
                }
                else
                {
                    Console.WriteLine(response.Message);
                    string errorMessage = "Invalid_product_input";
                    ops.SavetoErrorLog(errorMessage);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }

            } while (response.Success != true);

            return product;

        }

        //Get a valid state from the user-
        public State GetOrderState()
        {
            var ops = new OrderOperations();
            var response = new StateResponse();
            response.Success = false;
            string input;
            State state = new State();

            //Loop until we get a supported state from the user
            do  
            {
                Console.Write("What state is the order for? ");
                input = Console.ReadLine().ToUpper();

              //  See if state exists by checking full list of supported states
                response = ops.GetStatebyNameorAbbr(input);

                if (response.Success == true)
                {
                    state = response.State;
                }
                else
                {
                    Console.WriteLine(response.Message);
                    string errorMessage = "Invalid_state_input";
                    ops.SavetoErrorLog(errorMessage);
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                }

            } while (response.Success != true);

            //if state exists get info for that state 

            return state; 

        }

        //Get order date from user
        public DateTime GetOrderDate()
        {

            bool valid = false;
            DateTime date = new DateTime();
            string input;
            do
            {
                Console.Write("Please enter the date of the order(mm/dd/yyyy): ");
                input = Console.ReadLine();
                if(DateTime.TryParse(input, out date))
                {
                    valid = true; 
                }
                else
                {
                    Console.WriteLine("Please enter a valid date in (mm/dd/yyyy format");
                    string errorMessage = "Invalid_date_input";
                    ops.SavetoErrorLog(errorMessage);
                    valid = false;
                }
                
            } while (valid == false);

            return date;

        } 

        //has error logger
        public string GetCustomerName()
        {
            string name = "";
            bool isValid = false;
            do
            {
                Console.Write("Please enter the cutomer name: ");
                name = Console.ReadLine();

                if (!NullorWhiteSpaceCheck(name))
                {
                    Console.WriteLine("Customer name can't be empty");
                    string errorMessage = "Invalid_name_input";
                    ops.SavetoErrorLog(errorMessage);
                    isValid = false;
                }
                else
                {
                    isValid = true;
                }

            } while (isValid == false);

            return name;
        }

        //helper for checking blank inputs
        public bool NullorWhiteSpaceCheck(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
