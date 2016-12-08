using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BATZBlog.Models;
using BATZBlog.BLL;

namespace BATZBlog.Controllers
{
    public class OrderController : ApiController
    {
        OperationsManager ops = new OperationsManager();

        //This will get a list of orders with the correct product based on id
        public List<OrderDataViewModel> Get()
        {
            List<OrderDataViewModel> orderDataViewModels = new List<OrderDataViewModel>();

            var products = ops.GetAllProducts();
            var orders = ops.GetAllOrders();

            foreach (var o in orders)
            {
                var product = products.FirstOrDefault(p => p.ProductId == o.ProductId);

                var orderDataVM = new OrderDataViewModel
                {
                    CustomerFirstName = o.CustomerFirstName,
                    CustomerLastName = o.CustomerLastName,
                    CustomerState = o.CustomerState,
                    OrderDate = o.OrderDate,
                    Quantity = o.Quantity,
                    ProductName = product.ProductName,
                    Price = (int)product.Price,
                    OrderStatus = o.OrderStatus,
                    OrderId = o.OrderId
                    
                };

                orderDataViewModels.Add(orderDataVM);
            }

            orderDataViewModels = orderDataViewModels.OrderByDescending(o => o.OrderDate).ToList();

            return orderDataViewModels;

        }

        public HttpResponseMessage Post(int id)
        {
            var orderToUpdate = ops.GetOrderById(id);

            if((int)orderToUpdate.OrderStatus == 2)
            {
                orderToUpdate.OrderStatus = OrderStatus.NotShipped;
            }
            else
            {
                orderToUpdate.OrderStatus = orderToUpdate.OrderStatus + 1;
            }

            ops.EditOrderStatus(orderToUpdate);

            return new HttpResponseMessage(HttpStatusCode.Created);
        }
    }
}
