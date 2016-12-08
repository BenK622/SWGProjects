using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BATZBlog.Models
{
    public class TagCloudViewModel
    {
        public List<Tag> Tags { get; set; }
        public Dictionary<Tag, int> TagCounts { get; set; }
    }
}