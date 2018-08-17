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
    public class DepartmanController : Controller
    {
        private OtokarContext db = new OtokarContext();

        // GET: Departman
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

            var departman = from c in db.Departman
                           select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                departman = departman.Where(c => c.DepartmanAdi.Contains(searchString));
            }

            departman = departman.OrderBy(c => c.DepartmanNo);

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(departman.ToPagedList(pageNumber, pageSize));
        }

        // GET: Departman/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departman departman = db.Departman.Find(id);
            if (departman == null)
            {
                return HttpNotFound();
            }
            return View(departman);
        }

        // GET: Departman/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departman/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmanNo,DepartmanAdi")] Departman departman)
        {
            if (ModelState.IsValid)
            {
                db.Departman.Add(departman);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(departman);
        }

        // GET: Departman/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departman departman = db.Departman.Find(id);
            if (departman == null)
            {
                return HttpNotFound();
            }
            return View(departman);
        }

        // POST: Departman/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmanNo,DepartmanAdi")] Departman departman)
        {
            if (ModelState.IsValid)
            {
                db.Entry(departman).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(departman);
        }

        // GET: Departman/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Departman departman = db.Departman.Find(id);
            if (departman == null)
            {
                return HttpNotFound();
            }
            return View(departman);
        }

        // POST: Departman/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Departman departman = db.Departman.Find(id);
            db.Departman.Remove(departman);
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
