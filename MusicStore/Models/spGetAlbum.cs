using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class spGetAlbum
    {
        public int AlbumID { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}