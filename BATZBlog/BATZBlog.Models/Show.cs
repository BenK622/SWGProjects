using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BATZBlog.Models
{
    public class Show
    {
        public int ShowId { get; set; }
        [Required(ErrorMessage = "Enter a Venue Name")]
        public string VenueName { get; set; }
        [Required(ErrorMessage = "Enter a City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Enter a State")]
        public string State { get; set; }
        [Required(ErrorMessage = "Enter a Date")]
        public DateTime ShowDate { get; set; }
    }
}
