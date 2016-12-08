using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProject.Models;

namespace FlooringProject.Data
{
    public class InMemOrderRepository : IOrderRepository
    {
        private static List<Order> _orders;

        public InMemOrderRepository()
        {
            if (_orders == null)
            {
                _orders = new List<Order>
                {
                     new Order()
                    {
                        CustomerName = "Junebug",
                        Area = 100m,
                        OrderNumber = "1",
                        State = new State()
                        {
                            StateAbbr = "OH",
                            StateName = "OHIO",
                            TaxRate = 8.00m
                        },
                        Product = new Product()
                        {
                            ProductType = "Hardwood",
                            CostPerSquareFoot = 20m,
                            LaborCostPerSquareFoot = 10m
                        },
                        Date = DateTime.Parse("11/11/2016"),
                        MaterialCost = 2000m,
                        LaborCost = 1000m,
                        TotalTax = 240m,
                        Total = 3240

                    },
                    new Order()
                    {
                        CustomerName = "Ben",
                        Area = 100m,
                        OrderNumber = "2",
                        State = new State()
                        {
                            StateAbbr = "OH",
                            StateName = "OHIO",
                            TaxRate = 8.00m
                        },
                        Product = new Product()
                        {
                            ProductType = "Hardwood",
                            CostPerSquareFoot = 20m,
                            LaborCostPerSquareFoot = 10m
                        },
                        Date = DateTime.Parse("11/11/2016"),
                        MaterialCost = 2000m,
                        LaborCost = 1000m,
                        TotalTax = 240m,
                        Total = 3240

                    },
                    new Order // I realized by this point I dont need to fill all the fields...
                    {
                        CustomerName = "TestName",
                        OrderNumber = "3",
                        Date = DateTime.Parse("10/27/2016")
                    },
                    new Order // I realized by this point I dont need to fill all the fields...
                    {
                        CustomerName = "TestName",
                        OrderNumber = "1",
                        Date = DateTime.Parse("06/22/2016")
                    }


                };


            }


        }

        public List<Order> GetOrdersbyDate(DateTime date)
        {
            return _orders.Where(a => a.Date.CompareTo(date) == 0).ToList();
        }

        public List<Order> GetOrderFromDatabyDateandNumber(DateTime date, string orderNumber)
        {
            return _orders.Where(a => a.Date == date && a.OrderNumber == orderNumber).ToList();

        }

        public bool SaveOrderToFile(Order order)
        {
            bool isSuccess = false;
            _orders.Add(order);

            isSuccess = true;
            return isSuccess;
        }

        public List<Order> GetAllOrders()
        {
            return _orders;
        }

        public bool RemoveOrderfromFile(Order order)
        {
            bool isSucess = false;
            _orders.Remove(order);

            isSucess = true;
            return isSucess;
        }
    }
}
