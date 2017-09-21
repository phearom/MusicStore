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

        [HttpPost]
        public string AddAuthor(Author author)
        {
            try
            {
                this.author.Add(author);
                var i = this.author.SaveChange();
                if (i > 0) { return "Saved successfully;"; }
                else { return "Saved fail"; }
            }
            catch (Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }

        [HttpPut]
        public string UpdateAuthor(Author author)
        {
            try
            {
                this.author.Update(author);
                var i = this.author.SaveChange();
                if (i > 0) { return "Updated successfully."; }
                else { return "Updated fail."; }
            }
            catch (Exception ex)
            {
                return "Error :" + ex.Message;
            }
        }

        [HttpDelete]
        public string DeleteById(int id)
        {
            try
            {
                this.author.DeleteById(id);
                var exc = this.author.SaveChange();
                if (exc > 0)
                    return "Delete successfully.";
                else
                    return "Delete failed.";
            }
            catch (Exception ex)
            {
                return "Delete : " + ex.Message;
            }
        }
    }
}
