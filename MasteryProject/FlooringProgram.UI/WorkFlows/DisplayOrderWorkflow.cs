using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProject.Models;
using FlooringProject.BLL;
using System.Threading;

namespace FlooringProgram.UI
{
    public class DisplayOrderWorkflow : AddOrderWorkflow
    {
        public override void Execute()
        {
          //  List<Order> orders = new List<Order>();

            //get date from user- inherited from add order
            DateTime date = GetOrderDate();

            DisplayOrdersForDate(date);
        }

        //Display the list of orders for the user entered date
        public void DisplayOrdersForDate(DateTime date)
        {
            OrderOperations ops = new OrderOperations();
            OrderReponse response = new OrderReponse();
            DisplayManager display = new DisplayManager();
            Menu menu = new Menu();

            //Get order from data by date
            response = ops.GetOrdersByDate(date);

            //if orders exist for date will display orders, else give error message and return to main menu 
            if (response.Success == true)
            {
                Console.Clear();
                display.DisplayListofOrders(response.OrderList);
            }
            else
            {
                Console.WriteLine(response.Message);
                Console.WriteLine("Press enter to return to main menu");
                Console.ReadLine();
                menu.Display();
            }

            Console.WriteLine("Press enter to return to main menu");
            Console.ReadLine();

        }
    }
}