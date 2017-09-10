using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicStore.API
{
    //[RoutePrefix("api/album")]
    public class AlbumController : ApiController
    {
        private Repository<Album> album = new Repository<Album>();

        [HttpGet]
        //[Route("getall")]
        public List<Album> GetAllAlbum()
        {
            var data = album.GetAll();
            return data;
        }

        [HttpGet]
        //[Route("get/{id}")]
        public Album GetAlbumById(int id)
        {
            var data = album.GetAll().Where(p => p.AlbumID == id).FirstOrDefault();
            return data;
        }

        [HttpDelete]
        public string DeleteById(int id)
        {
            try
            {
                album.DeleteById(id);
                var exc = album.SaveChange();
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

        //[HttpDelete]
        //public HttpResponseMessage DeleteById(int id)
        //{
        //    try
        //    {
        //        album.DeleteById(id);
        //        var i = album.SaveChange();
        //        if (i > 0)
        //            return Request.CreateResponse(HttpStatusCode.OK);
        //        else
        //            return Request.CreateResponse(HttpStatusCode.BadRequest);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
        //    }
        //}

        [HttpPut]
        public string UpdateById(Album album)
        {
            try
            {
                this.album.Update(album);
                var i = this.album.SaveChange();
                if (i > 0)
                    return "Update successfully.";
                else
                    return "Update failed.";
            }
            catch (Exception ex)
            {
                return "Update : " + ex.Message;
            }
        }
    }
}
