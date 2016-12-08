using BATZBlog.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BATZBlog.Controllers
{
    public class SalesByMonthYearController : ApiController
    {
        public Dictionary<string, int> Get()
        {
            OperationsManager ops = new OperationsManager();

            var SalesByMonthYear = ops.GetOrderDashboard().SalesByMonthYear;

            return SalesByMonthYear;
        }
    }
}
