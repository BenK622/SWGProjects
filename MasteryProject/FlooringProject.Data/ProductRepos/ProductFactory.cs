using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace FlooringProject.Data
{
    public class ProductFactory
    {
        public static IProductRepository CreateProductRepository()
        {
            IProductRepository repo;

            string mode = ConfigurationManager.AppSettings["mode"].ToString();

            switch (mode.ToUpper())
            {
                case "TEST":
                    repo = new InMemProductRepository();
                    break;
                case "PROD":
                    repo = new FileProductRepository();
                    break;
                default:
                    throw new Exception("I don't know that mode!");
            }

            return repo;
        }
    }
}
