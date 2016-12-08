using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATZBlog.Models
{
    public class MediaLink
    {
        public int LinkId { get; set; }
        public MediaType MediaType { get; set; }
        public string LinkURL { get; set; }
        public int BlogId;
    }
}