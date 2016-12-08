using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BATZBlog.Models
{
    public class StaticPages
    {
        public int PageId { get; set; }
        [Required(ErrorMessage = "Enter a Title")]
        public string Title { get; set; }
        [AllowHtml]
        [Required(ErrorMessage = "Enter something in the Body")]
        [MinLength(5, ErrorMessage = "Enter more than 5 characters")]
        public string PageBody { get; set; }
    }
}