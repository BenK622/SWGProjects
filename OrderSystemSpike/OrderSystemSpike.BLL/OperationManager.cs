using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderSystemSpike.Models;
using OrderSystemSpike.Data;

namespace OrderSystemSpike.BLL
{
    public class OperationManager
    {
        

        public List<Order> GetAllOrders()
        {
            return db.GetAllOrders();
        }

        public List<Customer> GetAllCustomers()
        {
            return db.GetAllCustomers();
        }
    }
}
