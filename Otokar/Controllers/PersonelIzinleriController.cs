using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Otokar.Models.Data;
using PagedList;

namespace Otokar.Controllers
{
    public class PersonelIzinleriController : Controller
    {
        private OtokarContext db = new OtokarContext();

        // GET: PersonelIzinleri
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

            var personel = from c in db.Personel
                           select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                personel = personel.Where(c => c.PersonelAdi.Contains(searchString));
            }

            personel = personel.OrderBy(c => c.PersonelSicilNo);

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(personel.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Index2(string currentFilter, string searchString, int? page)
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

            var personel = from c in db.PersonelIzinleri
                           select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                personel = personel.Where(c => c.PersonelAdi.Contains(searchString));
            }

            personel = personel.OrderBy(c => c.ID);

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(personel.ToPagedList(pageNumber, pageSize));
        }

        // GET: PersonelIzinleri/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelIzinleri personelIzinleri = db.PersonelIzinleri.Find(id);
            if (personelIzinleri == null)
            {
                return HttpNotFound();
            }
            return View(personelIzinleri);
        }

        // GET: PersonelIzinleri/Create
        public ActionResult Create(int? id)
        {
            List<Personel> personel = new List<Personel>();

            string cs = ConfigurationManager.ConnectionStrings["OtokarContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from Personel", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Personel p1 = new Personel();
                    if (id.ToString() == rdr["PersonelSicilNo"].ToString())
                    {
                        p1.PersonelAdi = rdr["PersonelAdi"].ToString();
                        personel.Add(p1);
                    }
                }
            }

            SelectList list1 = new SelectList(personel, "PersonelAdi", "PersonelAdi");
            ViewBag.DropdownListFor1 = list1;

            List<Personel> personel2 = new List<Personel>();

            string cs1 = ConfigurationManager.ConnectionStrings["OtokarContext"].ConnectionString;
            using (SqlConnection con1 = new SqlConnection(cs1))
            {
                SqlCommand cmd1 = new SqlCommand("Select * from Personel", con1);
                con1.Open();
                SqlDataReader rdr1 = cmd1.ExecuteReader();
                while (rdr1.Read())
                {
                    Personel p2 = new Personel();
                    if (id.ToString() == rdr1["PersonelSicilNo"].ToString())
                    {
                        p2.PersonelSoyAdi = rdr1["PersonelSoyAdi"].ToString();
                        personel2.Add(p2);
                    }
                }
            }

            SelectList list2 = new SelectList(personel2, "PersonelSoyAdi", "PersonelSoyAdi");
            ViewBag.DropdownListFor2 = list2;



            return View();
        }

        // POST: PersonelIzinleri/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PersonelAdi,PersonelSoyAdi,IzinBaslangicTarihi,IzinBitisTarihi")] PersonelIzinleri personelIzinleri)
        {
            if (ModelState.IsValid)
            {
                db.PersonelIzinleri.Add(personelIzinleri);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personelIzinleri);
        }

        // GET: PersonelIzinleri/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelIzinleri personelIzinleri = db.PersonelIzinleri.Find(id);
            if (personelIzinleri == null)
            {
                return HttpNotFound();
            }
            return View(personelIzinleri);
        }

        // POST: PersonelIzinleri/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PersonelAdi,PersonelSoyAdi,IzinBaslangicTarihi,IzinBitisTarihi")] PersonelIzinleri personelIzinleri)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personelIzinleri).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personelIzinleri);
        }

        // GET: PersonelIzinleri/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonelIzinleri personelIzinleri = db.PersonelIzinleri.Find(id);
            if (personelIzinleri == null)
            {
                return HttpNotFound();
            }
            return View(personelIzinleri);
        }

        // POST: PersonelIzinleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonelIzinleri personelIzinleri = db.PersonelIzinleri.Find(id);
            db.PersonelIzinleri.Remove(personelIzinleri);
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
