using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicStore.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string GenderID { get; set; }
        public List<AlbumAuthor> AlbumAuthor { get; set; }
        public Gender Gender { get; set; }
    }
}