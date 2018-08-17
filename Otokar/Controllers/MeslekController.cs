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
    public class MeslekController : Controller
    {
        private OtokarContext db = new OtokarContext();

        // GET: Meslek
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

            var meslek = from c in db.Meslek
                        select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                meslek = meslek.Where(c => c.MeslekAdi.Contains(searchString));
            }

            meslek = meslek.OrderBy(c => c.ID);

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(meslek.ToPagedList(pageNumber, pageSize));
        }

        // GET: Meslek/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meslek meslek = db.Meslek.Find(id);
            if (meslek == null)
            {
                return HttpNotFound();
            }
            return View(meslek);
        }

        // GET: Meslek/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Meslek/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,MeslekAdi")] Meslek meslek)
        {
            if (ModelState.IsValid)
            {
                db.Meslek.Add(meslek);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(meslek);
        }

        // GET: Meslek/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meslek meslek = db.Meslek.Find(id);
            if (meslek == null)
            {
                return HttpNotFound();
            }
            return View(meslek);
        }

        // POST: Meslek/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,MeslekAdi")] Meslek meslek)
        {
            if (ModelState.IsValid)
            {
                db.Entry(meslek).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(meslek);
        }

        // GET: Meslek/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Meslek meslek = db.Meslek.Find(id);
            if (meslek == null)
            {
                return HttpNotFound();
            }
            return View(meslek);
        }

        // POST: Meslek/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Meslek meslek = db.Meslek.Find(id);
            db.Meslek.Remove(meslek);
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
