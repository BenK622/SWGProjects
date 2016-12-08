using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringProject.Models
{
    public class OrderReponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public Order order { get; set; }
        public List<Order> OrderList { get; set; }
    }
}
