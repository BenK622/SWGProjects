using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlooringProject.BLL;
using FlooringProject.Models;
using FlooringProject.Data;
using FlooringProject.Models.Responses;


namespace FlooringProject.Tests
{
    [TestFixture]
    class OperationsTests
    {

        OrderOperations ops = new OrderOperations();

        [Test] //tests successfully getting a state
        public void GetStatebyNameorAbbrTest()
        {
            string input = "oh";

            var actual = ops.GetStatebyNameorAbbr(input);

            Assert.IsTrue(actual.Success);
            
        }

        [Test] //tests that successfully gets a product
        public void GetProductbyTypeTest()
        {
            string input = "hardWood";

            var actual = ops.GetProductbyType(input);

            Assert.IsTrue(actual.Success);
        }

        [Test] //tests that the materials, labor and tax will caculate correctly
        public void CalculateOrderTest()
        {
            //Mock order for calculation
            Order order = new Order()
            {
                Area = 10,
                Product = new Product()
                {
                    CostPerSquareFoot = 5.15m,
                    LaborCostPerSquareFoot = 4.75m,

                },
                State = new State()
                {
                    TaxRate = 6.5m
                }

            };

            var actual = ops.CalculateOrder(order);

            Assert.AreEqual(105.44m, actual.Total);
            
        }
        

        [Test]//tests response that a order can be added, also makes sure 1 gets assigned as a order number on new date
        public void SaveNewOrderTest()
        {
            var order = new Order()
            {
                CustomerName = "Junebug",
                Area = 100m,
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
                Date = DateTime.Parse("10/15/2016"),
                MaterialCost = 2000m,
                LaborCost = 1000m,
                TotalTax = 240m,
                Total = 3240

            };

            var actual = ops.SaveNewOrder(order);

            Assert.AreEqual(true, actual.Success);

            //checks that order number assigned as well
            Assert.AreEqual("1", actual.order.OrderNumber);

        }
        
        [Test] //will test that order can be edited on same date and keep ordernumber but change name
        public void SaveEditedOrderSameDateTest()
        {
            var originalOrder = new Order()
            {
                CustomerName = "Junebug",
                OrderNumber = "2",
                Date = DateTime.Parse("10/01/2016"),
            };

            var editedOrder = new Order()
            {
                CustomerName = "TestName",
                OrderNumber = "2",
                Date = DateTime.Parse("10/01/2016"),

            };

            var actual = ops.SaveEditedOrder(editedOrder, originalOrder);

            Assert.AreEqual("TestName", actual.order.CustomerName);

            Assert.AreEqual("2", actual.order.OrderNumber);
        }

        [Test] //Will check that when save to a new date the order number will get set to 1
        public void SaveEditOrderNewDate()
        {
            var originalOrder = new Order()
            {
                CustomerName = "Junebug",
                OrderNumber = "2",
                Date = DateTime.Parse("10/01/2016"),
            };

            var editedOrder = new Order()
            {
                CustomerName = "Junebug",
                OrderNumber = "2",
                Date = DateTime.Parse("10/02/2016"),

            };

            var actual = ops.SaveEditedOrder(editedOrder, originalOrder);

            Assert.AreEqual("1", actual.order.OrderNumber);
        }

        [Test] //remove order, check for success and that no more orders exist on date
        public void RemoveOrderTest()
        {


            DateTime date = DateTime.Parse("10/27/2016");
            string orderNumber = "3";

            var order = ops.GetOrdersByDateandNumber(date, orderNumber);
            var actual = ops.RemoveOrder(order.OrderList.First());
            var list = ops.GetOrdersByDate(date);

            Assert.AreEqual(true, actual.Success);
            Assert.AreEqual(null, list.OrderList);

        }

        [Test] //get list of orders for a date, test for the right count
        public void GetOrdersByDateTest()
        {
            DateTime date = DateTime.Parse("06/22/2016");

            var actual = ops.GetOrdersByDate(date);

            Assert.AreEqual(1, actual.OrderList.Count);
        } 

        [Test] //get a specific order based on a date and order, test for the right ordername
        public void GetOrdersByDateandNumber()
        {
            DateTime date = DateTime.Parse("06/22/2016");
            string orderNumber = "1";

            var actual = ops.GetOrdersByDateandNumber(date, orderNumber);

            Assert.AreEqual("TestName", actual.OrderList.First().CustomerName);
        }


    }
}
