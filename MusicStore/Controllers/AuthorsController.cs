using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using MusicStore.Models;
using System.Linq;

namespace MusicStore.Controllers
{
    public class AuthorsController : Controller
    {
        private MusicStoreDataContext db = new MusicStoreDataContext();
        private Repository<Author> author = new Repository<Author>();
        private Repository<Gender> gender = new Repository<Gender>();

        // GET: Authors
        public ActionResult Index()
        {
            //Call Store procedure
            //var rx = db.Database.SqlQuery<spGetAlbum>("spGetAlbum @id", new SqlParameter("@Id", 3)).ToList();
            //var x = db.Database.SqlQuery<string>("spGetAlbumNameByID @id", new SqlParameter("@id", 3)).SingleOrDefault();
            //return View(db.Author.ToList());
            return View(author.DbSet.Include(g => g.Gender));
        }

        // GET: Authors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Author author = db.Author.Find(id);
            var author = this.author.DbSet.Include(g=>g.Gender).Where(g=>g.AuthorID==id).FirstOrDefault();
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // GET: Authors/Create
        public ActionResult Create()
        {
            ViewBag.GenderID = new SelectList(gender.DbSet, "GenderID", "Value");
            return View();
        }

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                //db.Author.Add(author);
                //db.SaveChanges();
                //return RedirectToAction("Index");
                this.author.Add(author);
                this.author.SaveChange();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Author author = db.Author.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenderID = new SelectList(db.Gender, "GenderID", "Value", author.GenderID);
            return View(author);
        }

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(author).State = EntityState.Modified;
                //db.SaveChanges();

                this.author.Update(author);
                this.author.SaveChange();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Author author = db.Author.Find(id);
            if (author == null)
            {
                return HttpNotFound();
            }
            return View(author);
        }

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Author author = db.Author.Find(id);
            db.Author.Remove(author);
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
