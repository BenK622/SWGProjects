using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BATZBlog.Models;

namespace BATZBlog.Models
{
    public class HomePageViewModel
    {
        public List<BlogPost> blogs { get; set; }
        public MediaLink homeImage { get; set; }
        public Dictionary<Tag, int> TagCounts { get; set; }
    }
}