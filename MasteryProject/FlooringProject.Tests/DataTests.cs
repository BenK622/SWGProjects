using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlooringProject.Models;
using FlooringProject.BLL;
using FlooringProject.Data;
using FlooringProject.Models.Responses;

namespace FlooringProject.Tests
{
    [TestFixture]
    class DataTests
    {
        OrderOperations ops = new OrderOperations();

        [Test]
        public void AddNewOrderTest()
        {
           var order =  new Order()
            {
                CustomerName = "Junebug",
                Area = 100m,
                OrderNumber = "1",
                State = new State()
                {
                    StateAbbr = "OH",
                    StateName = "OHIO",
                    TaxRate = .08m
                },
                Product = new Product()
                {
                    ProductType = "Hardwood",
                    CostPerSquareFoot = 20m,
                    LaborCostPerSquareFoot = 10m
                },
                Date = DateTime.Parse("11/15/2016"),
                MaterialCost = 2000m,
                LaborCost = 1000m,
                TotalTax = 240m,
                Total = 3240

            };

            ops.SaveNewOrder(order);

            InMemOrderRepository repo = new InMemOrderRepository();

            var orders = repo.GetOrdersbyDate(order.Date);

            Assert.AreEqual(1, orders.Count);

        }

        [Test]
        public void RemoveOrderTest()
        {
            InMemOrderRepository repo = new InMemOrderRepository();
            DateTime date = DateTime.Parse("11/11/2016");
            string orderNumber = "1";

            var response = ops.GetOrdersByDateandNumber(date, orderNumber);

            ops.RemoveOrder(response.OrderList.First());

            var orders = repo.GetOrdersbyDate(date);

            Assert.AreEqual(1, orders.Count);
        }

        [Test]
        public void GetOrdersbyDateTest()
        {
            InMemOrderRepository repo = new InMemOrderRepository();
            DateTime date = DateTime.Parse("11/11/2016");

            var list = repo.GetOrdersbyDate(date);

            Assert.AreEqual(2, list.Count);
        }

        [Test]
        public void GetOrderFromDatabyDateandNumber()
        {
            InMemOrderRepository repo = new InMemOrderRepository();
            DateTime date = DateTime.Parse("11/11/2016");
            string orderNumber = "2";

            var list = repo.GetOrderFromDatabyDateandNumber(date, orderNumber);

            var order = list.First();

            Assert.AreEqual("Ben", order.CustomerName);

        }

    }
}
