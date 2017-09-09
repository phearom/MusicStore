using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicStore.Models;
using PagedList;

namespace MusicStore.Controllers
{
    public class AlbumsController : Controller
    {
        private MusicStoreDataContext db = new MusicStoreDataContext();

        // GET: Albums
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSort = string.IsNullOrEmpty(sortOrder) ? "Name_desc" : "";
            ViewBag.ReleaseDateSort = sortOrder == "ReleaseDate" ? "ReleaseDate_desc" : "ReleaseDate";
            ViewBag.RatingSort = sortOrder == "Rating" ? "Rating_desc" : "Rating";
            ViewBag.IsEnableSort = sortOrder == "IsEnable" ? "IsEnable_desc" : "IsEnable";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var data = db.Album.ToList();
            if (!string.IsNullOrEmpty(searchString))
            {
                data = data.Where(c => c.Name.ToLower().Contains(searchString.ToLower())).ToList();
            }
            switch (sortOrder)
            {
                case "Name_desc":
                    data = data.OrderByDescending(s => s.Name).ToList();
                    break;
                case "ReleaseDate":
                    data = data.OrderBy(s => s.ReleaseDate).ToList();
                    break;
                case "ReleaseDate_desc":
                    data = data.OrderByDescending(s => s.ReleaseDate).ToList();
                    break;
                case "Rating":
                    data = data.OrderBy(r => r.Rating).ToList();
                    break;
                case "Rating_desc":
                    data = data.OrderByDescending(r => r.Rating).ToList();
                    break;
                case "IsEnable":
                    data = data.OrderBy(e => e.IsEnable).ToList();
                    break;
                case "IsEnable_desc":
                    data = data.OrderByDescending(e => e.IsEnable).ToList();
                    break;
                default: 
                    data = data.OrderBy(s => s.Rating).ToList();
                    break;
            }

            ViewBag.q = searchString;

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(data.ToPagedList(pageNumber, pageSize));
        }

        // GET: Albums/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Album.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // GET: Albums/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Albums/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlbumID,Name,ReleaseDate,Rating,IsEnable")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Album.Add(album);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(album);
        }

        // GET: Albums/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Album.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlbumID,Name,ReleaseDate,Rating,IsEnable")] Album album)
        {
            if (ModelState.IsValid)
            {
                db.Entry(album).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(album);
        }

        // GET: Albums/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Album album = db.Album.Find(id);
            if (album == null)
            {
                return HttpNotFound();
            }
            return View(album);
        }

        // POST: Albums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Album album = db.Album.Find(id);
            db.Album.Remove(album);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
