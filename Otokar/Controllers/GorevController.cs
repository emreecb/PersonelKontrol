using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Otokar.Models.Data;
using PagedList;

namespace Otokar.Controllers
{
    public class GorevController : Controller
    {
        private OtokarContext db = new OtokarContext();

        // GET: Gorev
        public ActionResult Index(string currentFilter, string searchString, int? page)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var gorev = from c in db.Gorev
                            select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                gorev = gorev.Where(c => c.GorevAdi.Contains(searchString));
            }

            gorev = gorev.OrderBy(c => c.ID);

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(gorev.ToPagedList(pageNumber, pageSize));
        }

        // GET: Gorev/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gorev gorev = db.Gorev.Find(id);
            if (gorev == null)
            {
                return HttpNotFound();
            }
            return View(gorev);
        }

        // GET: Gorev/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gorev/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,GorevAdi")] Gorev gorev)
        {
            if (ModelState.IsValid)
            {
                db.Gorev.Add(gorev);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gorev);
        }

        // GET: Gorev/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gorev gorev = db.Gorev.Find(id);
            if (gorev == null)
            {
                return HttpNotFound();
            }
            return View(gorev);
        }

        // POST: Gorev/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,GorevAdi")] Gorev gorev)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gorev).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gorev);
        }

        // GET: Gorev/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gorev gorev = db.Gorev.Find(id);
            if (gorev == null)
            {
                return HttpNotFound();
            }
            return View(gorev);
        }

        // POST: Gorev/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gorev gorev = db.Gorev.Find(id);
            db.Gorev.Remove(gorev);
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
