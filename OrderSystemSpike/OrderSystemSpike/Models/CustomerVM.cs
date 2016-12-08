using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderSystemSpike.Models
{
    public class CustomerVM
    {
        public List<SelectListItem> Customers { get; set; }
        public int SelectedCustomerID { get; set; }


        public CustomerVM()
        {
            Customers = new List<SelectListItem>();
        }

        public void SetCustomers(IEnumerable<Customer> customers)
        {
            foreach(var cust in customers)
            {
                Customers.Add(new SelectListItem()
                {
                    Value = cust.CustomerID.ToString(),
                    Text = cust.FirstName + " " + cust.LastName

                });
            }
        }

    }
}