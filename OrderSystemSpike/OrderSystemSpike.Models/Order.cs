using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystemSpike.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int MerchID { get; set; }
        public int Quantity { get; set; }
        public int CustomerID { get; set; }
    }
}
