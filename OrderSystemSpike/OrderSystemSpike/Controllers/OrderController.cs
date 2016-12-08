using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderSystemSpike.BLL;
using OrderSystemSpike.Models;

namespace OrderSystemSpike.Controllers
{
    public class OrderController : Controller
    {
        OperationManager ops = new OperationManager();
        // GET: Order
        public ActionResult Index()
        {
            var orders = ops.GetAllOrders();

            return View(orders);
        }

        [HttpGet]
        public ActionResult SelectCustomer()
        {
            CustomerVM customerVM = new CustomerVM();

            customerVM.SetCustomers(ops.GetAllCustomers());

            return View(customerVM);
        }
    }
}