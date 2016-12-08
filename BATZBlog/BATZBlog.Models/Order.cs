using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BATZBlog.Models.attributes;

namespace BATZBlog.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Enter a Date")]
        public DateTime OrderDate { get; set; }
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Enter a quantity")]
        [MinValue(1)]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Enter a First Name")]
        public string CustomerFirstName { get; set; }
        [Required(ErrorMessage = "Enter a Last Name")]
        public string CustomerLastName { get; set; }
        [Required(ErrorMessage = "Enter a City")]
        public string CustomerCity { get; set; }
        [Required(ErrorMessage = "Enter a State")]
        public string CustomerState { get; set; }
        
        public OrderStatus OrderStatus { get; set; }

    }
}
