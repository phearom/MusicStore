using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class AlbumAuthor
    {
        public int ID { get; set; }
        public int AlbumId { get; set; }
        public int AuthorId { get; set; }
        public DateTime CreateDate { get; set; }
        public Album Album { get; set; }
        public Author Author { get; set; }
    }
}