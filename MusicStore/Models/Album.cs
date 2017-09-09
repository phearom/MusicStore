using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Rating { get; set; }
        public int IsEnable { get; set; }
        public List<AlbumAuthor> AlbumAuthor { get; set; }
    }
}