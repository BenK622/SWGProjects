using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProject.Models;

namespace FlooringProject.Data
{
    public class InMemProductRepository : IProductRepository
    {
        private static List<Product> _product;

        public InMemProductRepository()
        {
            _product = new List<Product>()
            {
                new Product()
                {
                    ProductType = "HARDWOOD",
                    CostPerSquareFoot = 20m,
                    LaborCostPerSquareFoot = 10m
                },
                new Product()
                {
                    ProductType = "LAMINATE",
                    CostPerSquareFoot = 10m,
                    LaborCostPerSquareFoot = 5m
                }

            };
        }


        public Product GetProductByName(string name)
        {
            return _product.FirstOrDefault(a => a.ProductType == name);
        }

        public List<Product> GetProductList()
        {
            return _product;
           
        }
    }
}