using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BATZBlog.Models
{
    public class BlogByTagViewModel
    {
        public List<BlogPost> blogs { get; set; }
        public string tagName { get; set; }
        public int count { get; set; }
    }
}