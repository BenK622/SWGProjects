using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderSystemSpike.Models;
using System.Data.SqlClient;

namespace OrderSystemSpike.Data
{
    public class DBRepo
    {
        private static string _connectionString = ConfigurationManager.ConnectionStrings["BlogOrderSystem"].ConnectionString;

        public void AddOrder()
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public void GetOrderByID()
        {
            throw new NotImplementedException();
        }

        public void GetAllMerch()
        {
            throw new NotImplementedException();
        }

        public void AddCustomer()
        {
            throw new NotImplementedException();

        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();
            using (var cn = new SqlConnection(_connectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = @"SELECT * FROM Customers";

                cmd.Connection = cn;

                cn.Open();

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Customer customer = new Customer();

                        customer = ConvertToCustomer(dr);

                        customers.Add(customer);
                    }
                }
            }

            return customers;
        }

        private Customer ConvertToCustomer(SqlDataReader dr)
        {
            return new Customer()
            {
                CustomerID = (int)dr["CustomerID"],
                FirstName = dr["FirstName"].ToString(),
                LastName = dr["LastName"].ToString(),
                City = dr["City"].ToString(),
                State = dr["State"].ToString(),
                Email = dr["Email"].ToString()


            };
        }

        public Customer GetCustomerByID(string customerID)
        {
            throw new NotImplementedException();
        }
    }
}
