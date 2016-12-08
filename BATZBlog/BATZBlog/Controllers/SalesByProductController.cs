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
    public class SalesByProductController : ApiController
    {
        public Dictionary<string, int> Get()
        {
            OperationsManager ops = new OperationsManager();

            var SalesByProduct = ops.GetOrderDashboard().SalesByItem;

            return SalesByProduct;
        }
    }
}
