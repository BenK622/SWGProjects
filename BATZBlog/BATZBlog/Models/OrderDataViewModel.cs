using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BATZBlog.Models
{
    public class OrderDataViewModel
    {
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerState { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public OrderStatus OrderStatus { get; set; }

        public int OrderId { get; set; }
    }
}