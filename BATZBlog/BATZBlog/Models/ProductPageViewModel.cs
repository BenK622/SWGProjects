using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BATZBlog.Models
{
    public class ProductPageViewModel
    {
        public List<Product> products { get; set; }
        public List<ProductCategory> productCategories { get; set; }
    }
}