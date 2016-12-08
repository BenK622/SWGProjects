using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATZBlog.Models
{
    public class OrderDashboard
    {
        //questions to answer: Total Sales, Sales by Category, Sales by Month/Year, List of Sales by item

        public int TotalSales { get; set; }
        public Dictionary<ProductCategory, int> SalesByCategory { get; set; }
        public Dictionary<string, int> SalesByMonthYear { get; set; }
        public Dictionary<string, int> SalesByItem { get; set; }

    }
}
