using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProject.Models;
using System.IO;

namespace FlooringProject.Data
{
    public class FileOrderRepository : IOrderRepository
    {
        
        
        public List<Order> GetOrderFromDatabyDateandNumber(DateTime date, string orderNumber)
        {
            List<Order> orders = new List<Order>();

            orders = GetOrdersbyDate(date);

            //could this not be a list? Had issues with trying to get it into an order object
            return orders.Where(o => o.OrderNumber == orderNumber).ToList();

        }

        //Helper method to convert dates into file format
        private string ConvertDatetoFileName(DateTime date)
        {

            string dateString = date.ToString("MMddyyyy");

            string fileName = $@"DataFiles/Orders_{dateString}.txt";

            return fileName;
        }
        

        public List<Order> GetOrdersbyDate(DateTime date)
        {
            List<Order> orders = new List<Order>();

            string fileName = ConvertDatetoFileName(date);

            if (!File.Exists(fileName))
            {
                return orders;
            }
            else
            {
                orders = ReadOrdersForDate(fileName);

                return orders;
            }
        }
        
        private List<Order> ReadOrdersForDate(string fileName)
        {
            List<Order> orders = new List<Order>();
            FileStateRepository stateRepo = new FileStateRepository();
            FileProductRepository productRepo = new FileProductRepository();

            using (StreamReader sr = File.OpenText(fileName))
            {
                string inputLine = "";

                while ((inputLine = sr.ReadLine()) != null)
                {
                    string[] inputParts = inputLine.Split(',');
                    Order order = new Order()
                    {
                        OrderNumber = inputParts[0],
                        CustomerName = inputParts[1],
                        State = stateRepo.GetStatebyNameorAbbr(inputParts[2]),
                        Product = productRepo.GetProductByName(inputParts[3]),
                        Date = DateTime.Parse(inputParts[4]),
                        LaborCost = decimal.Parse(inputParts[5]),
                        MaterialCost = decimal.Parse(inputParts[6]),
                        TotalTax = decimal.Parse(inputParts[7]),
                        Total = decimal.Parse(inputParts[8]),
                        Area = decimal.Parse(inputParts[9])

                    };

                    orders.Add(order);
                }

            }//End of using statement, file closed

            return orders;

        }

        
        public bool RemoveOrderfromFile(Order order)
        {
            bool isSuccess = false;

            List<Order> orders = new List<Order>();

            orders = GetOrdersbyDate(order.Date);

            if(orders.Count == 1)
            {
                File.Delete(ConvertDatetoFileName(order.Date));
            }
            else
            {
                orders.Remove(orders.FirstOrDefault(o => o.OrderNumber == order.OrderNumber));

                
                WriteToFile(orders, ConvertDatetoFileName(order.Date));
            }

            isSuccess = true;
            return isSuccess;

        }
        
        public bool SaveOrderToFile(Order order)
        {
            bool isSuccess = false;

            List<Order> orders = new List<Order>();

            if (order.CustomerName.Contains(","))
            {
                order.CustomerName = order.CustomerName.Replace(',', '☺');
            }

            orders = GetOrdersbyDate(order.Date);

            if (orders.Count == 0)
            {
                CreateNewFileWithOrder(order);
            }
            else
            {
                orders.Add(order);

                WriteToFile(orders, ConvertDatetoFileName(order.Date));
            }

            isSuccess = true;
            return isSuccess;
        }

        private void CreateNewFileWithOrder(Order order)
        {
            string fileName = ConvertDatetoFileName(order.Date);
            var file = File.Create(fileName);
            file.Close();
            
            WriteToFile(order, fileName);

        }

        //Write file for a new file
        private void WriteToFile(Order order, string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine($"{order.OrderNumber},{order.CustomerName},{order.State.StateAbbr},{order.Product.ProductType},{order.Date},{order.LaborCost},{order.MaterialCost},{order.TotalTax},{order.Total},{order.Area}");

            }
        }

        //overload for writing to an existing file
        private void WriteToFile(List<Order> orders, string fileName)
        {
            var orderSorted = orders.OrderBy(o => int.Parse(o.OrderNumber));

            using (StreamWriter sw = new StreamWriter(fileName, false))
            {
                foreach(var order in orderSorted)
                {
                    sw.WriteLine($"{order.OrderNumber},{order.CustomerName},{order.State.StateAbbr},{order.Product.ProductType},{order.Date.ToShortDateString()},{order.LaborCost},{order.MaterialCost},{order.TotalTax},{order.Total},{order.Area}");
                }
            }
        }
    }
}



