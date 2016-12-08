using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BATZBlog.Models.attributes;

namespace BATZBlog.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Enter a Product Name")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Enter a Description")]
        public string ProductDescription { get; set; }
        [Required(ErrorMessage = "Enter a Price")]
        [MinPrice(0.01)]
       
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c0}")]
       // [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal Price { get; set; }
       

        [Required(ErrorMessage = "Choose a Category")]
        [Range(0, 3, ErrorMessage = "Choose a Category")]
        public ProductCategory ProductCategory { get; set; }
        //[Required(ErrorMessage = "Upload a JPG file")]
        //[RegularExpression(@"^.*\.(jpg|JPG)$", ErrorMessage = "File must be a JPG")]
        public string ProductImagePath { get; set; }

    }
}
