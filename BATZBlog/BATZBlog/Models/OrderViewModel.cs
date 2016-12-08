using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BATZBlog.Models
{
    public class OrderViewModel
    {
        public Order order { get; set; }
        public Product product { get; set; }
    }
}