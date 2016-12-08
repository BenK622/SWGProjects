using FlooringProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProject.BLL;
using System.Threading;

namespace FlooringProgram.UI.WorkFlows
{
    public class RemoveOrderWorkFlow : AddOrderWorkflow 
    {
        OrderOperations ops = new OrderOperations();
        DisplayManager display = new DisplayManager();

        public override void Execute()
        {
            Console.Clear();
            Order order = new Order();
            
            order = GetOrderbyDateandNumber(order);

            display.DisplayOrder(order);

            ProccessRemove(order);

        }

        private void ProccessRemove(Order order)
        {
            string input;

            do
            {

                Console.WriteLine("Do you want to remove this order? Y/N ");
                input = Console.ReadLine();
                input = input.ToUpper();

                switch (input)
                {
                    case "Y":
                        Console.WriteLine("Removing order....");
                        Thread.Sleep(2000);
                        RemoveOrderfromRepo(order);
                        break;
                    case "N":
                        Console.WriteLine("Keeping Order...");
                        Thread.Sleep(2000);
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input");
                        string errorMessage = "invalid_commit_choice";
                        ops.SavetoErrorLog(errorMessage);
                        break;
                }

            } while (input != "Y" && input != "N");

            Menu menu = new Menu();
            menu.Display();
        }

        private void RemoveOrderfromRepo(Order order)
        {
            var response = new OrderReponse();

            Console.Clear();

            response = ops.RemoveOrder(order);

            Console.WriteLine("Successfully removed the following order: ");
            display.DisplayOrder(order);
            Console.WriteLine();
            Console.WriteLine("Press enter to return to main menu");
            Console.ReadLine();
        }

        public Order GetOrderbyDateandNumber(Order order)
        {
            string orderNumber;
            OrderReponse response = new OrderReponse();
            
            Menu menu = new Menu();

            DateTime date = GetOrderDate();

            var orders = ops.GetOrdersByDate(date);

            if(orders.OrderList != null)
            {
                Console.Clear();
                Console.WriteLine("Orders for date selected - use order number to select");
                Console.WriteLine("------------------------------------------------");
                display.DisplayListofOrders(orders.OrderList);
                Console.WriteLine();
            }

            orderNumber = GetOrderNumberFromUser();

            response = ops.GetOrdersByDateandNumber(date, orderNumber);

            if (response.Success == true)
            {
                order = response.OrderList.First();
            }
            else
            {
                Console.WriteLine(response.Message);
                string errorMessage = "invalid_order_or_date";
                ops.SavetoErrorLog(errorMessage);
                System.Threading.Thread.Sleep(1500);
                menu.Display();

            }

            return order;

        }

        public string GetOrderNumberFromUser()
        {
            bool isValid = false;
            string orderNumber;
            //validation to make sure not empty or whitespace
            do
            {
                Console.Write("Please enter the order number: ");
                orderNumber = Console.ReadLine();

                isValid = NullorWhiteSpaceCheck(orderNumber);


            } while (isValid == false);

            return orderNumber;

        }


    }
}
