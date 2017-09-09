using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicStore.API
{
    public class AuthorController : ApiController
    {
        private Repository<Author> author = new Repository<Author>();

        [HttpGet]
        public List<Author> GetAllAuthor()
        {
            var data = author.GetAll();
            return data;

        }

        [HttpGet]
        public Author GetAlbumById(int id)
        {
            var data = author.GetAll().Where(a => a.AuthorID == id).FirstOrDefault();
            return data;
        }
    }
}
