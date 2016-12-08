using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringProject.Models;
using System.IO;


namespace FlooringProject.Data
{
    public class FileProductRepository : IProductRepository
    {
        private const string FILENAME = @"C:\_repos\ben-kraus-individual-work\MasteryProject\FlooringProgram.UI\DataFiles\ProductData.txt";

        public Product GetProductByName(string name)
        {
            Product product = new Product();

            var productList = GetProductList();

            product = productList.FirstOrDefault(p => p.ProductType == name);

            return product;
        }

        public List<Product> GetProductList()
        {
            List<Product> products = new List<Product>();

            using (StreamReader sr = File.OpenText(FILENAME))
            {
                string inputLine = "";

                while ((inputLine = sr.ReadLine()) != null)
                {
                    string[] inputParts = inputLine.Split(',');
                    Product product = new Product()
                    {
                        ProductType = inputParts[0],
                        CostPerSquareFoot = decimal.Parse(inputParts[1]),
                        LaborCostPerSquareFoot = decimal.Parse(inputParts[2])
   
                    };

                    products.Add(product);
                }

            }

            return products;
        }
    }
}
