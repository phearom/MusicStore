using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;

namespace MusicStore.API
{
    public class AlbumAuthorController : ApiController
    {

        private Repository<AlbumAuthor> context = new Repository<AlbumAuthor>();

        [HttpGet]
        public List<AlbumAuthor> GetAll()
        {
            var j= context.DbSet.Include(a => a.Album).Include(a => a.Author).ToList();
            return j;
        } 
    }
}
