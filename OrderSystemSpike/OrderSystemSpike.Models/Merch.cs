using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystemSpike.Models
{
    public class Merch
    {
        public int MerchID { get; set; }
        public string MerchName { get; set; }
        public string MerchDescription { get; set; }
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
    }
}
