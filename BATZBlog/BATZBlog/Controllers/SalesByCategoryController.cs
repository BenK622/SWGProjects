using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BATZBlog.BLL;
using BATZBlog.Models;

namespace BATZBlog.Controllers
{
    public class SalesByCategoryController : ApiController
    {
        public Dictionary<ProductCategory, int> Get()
        {
            OperationsManager ops = new OperationsManager();

            var SalesByCategory = ops.GetOrderDashboard().SalesByCategory;

            return SalesByCategory;
        }
    }
}
