using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProject.Models;
using System.Collections;

namespace FlooringProgram.UI
{
    public class DisplayManager
    {
        public void DisplayOrder(Order order)
        {
            if (order.CustomerName.Contains('☺')) 
            {
               order.CustomerName = order.CustomerName.Replace('☺', ',');
            }

            Console.WriteLine("******************");
            Console.WriteLine("    Order    ");
            Console.WriteLine("******************");
            Console.WriteLine($"Order Date: {order.Date.ToShortDateString()}");
            Console.WriteLine($"Order Number: {order.OrderNumber}");
            Console.WriteLine($"Customer Name: {order.CustomerName}");
            Console.WriteLine($"State: {order.State.StateName}");
            Console.WriteLine($"Product: {order.Product.ProductType}");
            Console.WriteLine($"Area: {order.Area}");
            Console.WriteLine($"Matierial Cost {order.MaterialCost}");
            Console.WriteLine($"Labor Cost: {order.LaborCost}");
            Console.WriteLine($"Total State Tax {order.TotalTax}");
            Console.WriteLine("===================================");
            Console.WriteLine($"Total Order Cost {order.Total}");
            Console.WriteLine();
        }

        public void DisplayListofOrders(List<Order> orders)
        {
            Console.WriteLine("List of orders for specific date");

            foreach (var order in orders)
            {
                DisplayOrder(order);
            }


        }

        public void DisplayProductList(List<Product> products)
        {
            Console.WriteLine("Current List of Products");
            
            foreach(var product in products)
            {
                Console.WriteLine($"{product.ProductType}");
            }
        }


    }
}
