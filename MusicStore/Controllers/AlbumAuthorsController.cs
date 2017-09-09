using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class AlbumAuthorsController : Controller
    {
        private MusicStoreDataContext db = new MusicStoreDataContext();

        // GET: AlbumAuthors
        public ActionResult Index()
        {
            var albumAuthor = db.AlbumAuthor.Include(a => a.Album).Include(a => a.Author);
            return View(albumAuthor.ToList());
        }

        // GET: AlbumAuthors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumAuthor albumAuthor = db.AlbumAuthor.Find(id);
            if (albumAuthor == null)
            {
                return HttpNotFound();
            }
            return View(albumAuthor);
        }

        // GET: AlbumAuthors/Create
        public ActionResult Create()
        {
            ViewBag.AlbumId = new SelectList(db.Album, "AlbumID", "Name");
            ViewBag.AuthorId = new SelectList(db.Author, "AuthorID", "Name");
            return View();
        }

        // POST: AlbumAuthors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,AlbumId,AuthorId,CreateDate")] AlbumAuthor albumAuthor)
        {
            if (ModelState.IsValid)
            {
                db.AlbumAuthor.Add(albumAuthor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AlbumId = new SelectList(db.Album, "AlbumID", "Name", albumAuthor.AlbumId);
            ViewBag.AuthorId = new SelectList(db.Author, "AuthorID", "Name", albumAuthor.AuthorId);
            return View(albumAuthor);
        }

        // GET: AlbumAuthors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumAuthor albumAuthor = db.AlbumAuthor.Find(id);
            if (albumAuthor == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlbumId = new SelectList(db.Album, "AlbumID", "Name", albumAuthor.AlbumId);
            ViewBag.AuthorId = new SelectList(db.Author, "AuthorID", "Name", albumAuthor.AuthorId);
            return View(albumAuthor);
        }

        // POST: AlbumAuthors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,AlbumId,AuthorId,CreateDate")] AlbumAuthor albumAuthor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(albumAuthor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AlbumId = new SelectList(db.Album, "AlbumID", "Name", albumAuthor.AlbumId);
            ViewBag.AuthorId = new SelectList(db.Author, "AuthorID", "Name", albumAuthor.AuthorId);
            return View(albumAuthor);
        }

        // GET: AlbumAuthors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AlbumAuthor albumAuthor = db.AlbumAuthor.Include(a => a.Album).Include(a => a.Author).FirstOrDefault();//.Find(id);
            if (albumAuthor == null)
            {
                return HttpNotFound();
            }
            return View(albumAuthor);
        }

        // POST: AlbumAuthors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AlbumAuthor albumAuthor = db.AlbumAuthor.Find(id);
            db.AlbumAuthor.Remove(albumAuthor);
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
