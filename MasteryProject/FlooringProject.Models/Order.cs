using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProject.Models
{
    public class Order
    {
        public State state;

        public string OrderNumber { get; set; }
        public string CustomerName { get; set; }
        public State State { get; set; }
        public decimal Area { get; set; }
        public Product Product { get; set; }
        public DateTime Date { get; set; }
        public decimal LaborCost { get; set; }
        public decimal MaterialCost { get; set; }
        public decimal TotalTax { get; set; }
        public decimal Total { get; set; }


    }
}
