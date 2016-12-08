using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BATZBlog.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        public string AlbumName { get; set; }
        public List<AlbumTrack> Tracks { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string AlbumCoverImage { get; set; }
    }
}
