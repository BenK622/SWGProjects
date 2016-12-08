using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProject.Data
{
    public class OrderFactory
    {
        public static IOrderRepository CreateOrderRepository()
        {
            IOrderRepository repo;

            string mode = ConfigurationManager.AppSettings["mode"].ToString();

            switch (mode.ToUpper())
            {
                case "TEST":
                    repo = new InMemOrderRepository();
                    break;
                case "PROD":
                    repo = new FileOrderRepository();
                    break;
                default:
                    throw new Exception("I don't know that mode!");
            }

            return repo;
        }
    }
}
