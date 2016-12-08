using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProject.Models;
using FlooringProject.Data;
using FlooringProject.Models.Responses;


namespace FlooringProject.BLL
{
    public class OrderOperations
    {
        /// <summary>
        /// Get a state based on user input
        /// </summary>
        /// <param name="input">user selected state abbr or name</param>
        /// <returns>reponse with success or not and the state if successful</returns>
        public StateResponse GetStatebyNameorAbbr(string input)
        {
            var response = new StateResponse();
            var repo = StateFactory.CreateStateRepository();

            //Try to get the state by its name or abbrivation based on user input
            var source = repo.GetStatebyNameorAbbr(input.ToUpper());

            if(source != null)
            {
                response.State = source;
                response.Success = true;
            }
            else
            {
                response.Message = "That entry is either invalid or not a supported State";
                response.Success = false;
            }
            return response;

        } 
        

        /// <summary>
        /// Get a product type based on a user input
        /// </summary>
        /// <param name="input">user selected type</param>
        /// <returns>response that indicates success and if successful the desired product</returns>
        public ProductResponse GetProductbyType(string input)
        {
            var response = new ProductResponse();
            var repo = ProductFactory.CreateProductRepository();

            var source = repo.GetProductByName(input.ToUpper());

            if(source != null)
            {
                response.product = source;
                response.Success = true;
            }
            else
            {
                response.Message = "I can't find a product with that name";
                response.Success = false;
            }

            return response;
        }

        public List<Product> GetProducts()
        {
            var repo = ProductFactory.CreateProductRepository();

            var productList = repo.GetProductList();

            return productList;
            
        }
        

        /// <summary>
        /// Saves an order into the repository 
        /// </summary>
        /// <param name="order">order to save</param>
        /// <returns>where the save was ok</returns>
        public OrderReponse SaveNewOrder(Order order)
        {
            var response = new OrderReponse();
            var repo = OrderFactory.CreateOrderRepository();
            order.OrderNumber = GetOrderNumber(order);

            var source = repo.SaveOrderToFile(order);

            if (source == true)
            {
                response.Success = true;
                response.order = order;
            }
            else
            {
                response.Success = false;
            }

            return response;
        }
       

        /// <summary>
        /// Will save an edited order- if the date wasn't changed it will save without assigning new order number
        /// otherwise will assign order number 1 if a new file, or one past the last order number in the date its getting moved to
        /// </summary>
        /// <param name="editedOrder">the order object with edits</param>
        /// <param name="originalOrder">the original order to edit with the date we need to check</param>
        /// <returns></returns>
        public OrderReponse SaveEditedOrder(Order editedOrder, Order originalOrder)
        {
            var repo = OrderFactory.CreateOrderRepository();
            var response = new OrderReponse();

            if (editedOrder.Date == originalOrder.Date)
            {
                repo.SaveOrderToFile(editedOrder);
                response.Success = true;
                response.order = editedOrder;
            }
            else
            {
               response = SaveNewOrder(editedOrder);
            }

            return response;

        }
        

        /// <summary>
        /// Removes specific order from repo
        /// </summary>
        /// <param name="order">takes order</param>
        /// <returns>response on whether successful</returns>
        public OrderReponse RemoveOrder(Order order)
        {
            var response = new OrderReponse();
            var repo = OrderFactory.CreateOrderRepository();

            var source = repo.RemoveOrderfromFile(order);

            if(source == true)
            {
                response.Success = true;
                response.order = order;
            }
            else
            {
                response.Success = false;
            }


            return response;
             
        }
        

        /// <summary>
        /// Returns a list of orders based on a date 
        /// </summary>
        /// <param name="date">date that user wants orders for</param>
        /// <returns>list of orders </returns>
        public OrderReponse GetOrdersByDate(DateTime date)
        {
            var response = new OrderReponse();
            var repo = OrderFactory.CreateOrderRepository();

            var source = repo.GetOrdersbyDate(date);

            if(source.Count != 0)
            {
                response.OrderList = source;
                response.Success = true;
            }
            else
            {
                response.Message = "No orders found on that date.";
                response.Success = false;
            }

            return response;
        }
         

        /// <summary>
        /// Get list of orders based on date and number(should only have one element, use .first to get it
        /// </summary>
        /// <param name="date">valid date</param>
        /// <param name="orderNumber">int ordernumber</param>
        /// <returns>list of orders</returns>
        public OrderReponse GetOrdersByDateandNumber(DateTime date, string orderNumber)
        {
            var response = new OrderReponse();
            var repo = OrderFactory.CreateOrderRepository();

            var source = repo.GetOrderFromDatabyDateandNumber(date, orderNumber);

            if (source.Count != 0)
            {
                response.OrderList = source;
                response.Success = true;
            }
            else
            {
                response.Message = "No orders found on that date.";
                response.Success = false;
            }

            return response;

        }
        

        /// <summary>
        /// Does the calculations of the order including: labor cost, material cost, tax and total
        /// </summary>
        /// <param name="order">Order info</param>
        /// <returns>updated order with calculations done</returns>
        public Order CalculateOrder(Order order)
        {
            order.LaborCost = Math.Round(order.Product.LaborCostPerSquareFoot * order.Area, 2);
            order.MaterialCost = Math.Round(order.Product.CostPerSquareFoot * order.Area, 2);
            order.TotalTax = Math.Round((order.LaborCost + order.MaterialCost) * (order.State.TaxRate / 100),2);
            order.Total = Math.Round(order.LaborCost + order.MaterialCost + order.TotalTax, 2);

            return order;
        }
        

        /// <summary>
        /// Gets an order number for adding to existing list or create a new file
        /// </summary>
        /// <param name="order">order that needs a number</param>
        /// <returns>string on the correct order number</returns>
        private string GetOrderNumber(Order order)
        {
            string orderNumber;
            DateTime date = order.Date;

            var response = GetOrdersByDate(date);


            if(response.OrderList == null)
            {
                orderNumber = "1";
            }
            else
            {
                var lastorder = response.OrderList.Last();
                int number = int.Parse(lastorder.OrderNumber);
                orderNumber = (number + 1).ToString();
            }

            return orderNumber;
        }
        
        /// <summary>
        /// saves an invalid input error to a file with the current time
        /// </summary>
        /// <param name="errorMessage"> error message generated</param>
        public void SavetoErrorLog(string errorMessage)
        {
            ErrorModel error = new ErrorModel();

            error.date = DateTime.Now;
            error.Message = errorMessage;

            ErrorLogRepo repo = new ErrorLogRepo();

            repo.WriteErrortoFile(error);

        }

        
    }
}
