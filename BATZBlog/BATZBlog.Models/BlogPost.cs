using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BATZBlog.Models
{
    public class BlogPost
    {
        public int BlogId { get; set; }
        [Required(ErrorMessage = "Enter a Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Enter a Date")]
        public DateTime PostDate { get; set; }
        [AllowHtml]
        [Required(ErrorMessage = "Enter something in the Body")]
        [MinLength(5, ErrorMessage = "Enter more than 5 characters")]
        public string PostBody { get; set; }
        public string AuthorFirstName { get; set; }
        public string AuthorLastName { get; set; }
        [Required(ErrorMessage = "Choose a Category")]
        [Range(1,4,ErrorMessage = "Choose a Category")]
        public Category Category { get; set; }
        public List<Tag> Tags { get; set; }
        public StatusOfApproval StatusOfApproval { get; set; }
        public string TagHolder { get; set; }
    }
}