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
    public class PersoneleKayitliEnvanterController : Controller
    {
        private OtokarContext db = new OtokarContext();

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

        // GET: PersoneleKayitliEnvanter
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

            var personel = from c in db.PersoneleKayitliEnvanter
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

        // GET: PersoneleKayitliEnvanter/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersoneleKayitliEnvanter personeleKayitliEnvanter = db.PersoneleKayitliEnvanter.Find(id);
            if (personeleKayitliEnvanter == null)
            {
                return HttpNotFound();
            }
            return View(personeleKayitliEnvanter);
        }

        // GET: PersoneleKayitliEnvant*er/Create
        public ActionResult Create(int? id)
        {
            List<StoktakiEnvanterSayisi> stoktakiEnvanter  = new List<StoktakiEnvanterSayisi>();

            string cs = ConfigurationManager.ConnectionStrings["OtokarContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from StoktakiEnvanterSayisi", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    StoktakiEnvanterSayisi d1 = new StoktakiEnvanterSayisi();
                    d1.EnvanterAdi = rdr["EnvanterAdi"].ToString();                    
                    stoktakiEnvanter.Add(d1);
                }

                con.Close();

            }

            SelectList list = new SelectList(stoktakiEnvanter, "EnvanterAdi", "EnvanterAdi");
            ViewBag.DropdownListFor = list;
            

            List<Personel> personel = new List<Personel>();

            string cs1 = ConfigurationManager.ConnectionStrings["OtokarContext"].ConnectionString;
            using (SqlConnection con1 = new SqlConnection(cs1))
            {
                SqlCommand cmd1 = new SqlCommand("Select * from Personel", con1);
                con1.Open();
                SqlDataReader rdr1 = cmd1.ExecuteReader();
                while (rdr1.Read())
                {
                    Personel p1 = new Personel();
                    if (id.ToString() == rdr1["PersonelSicilNo"].ToString())
                    {
                        p1.PersonelAdi = rdr1["PersonelAdi"].ToString();
                        personel.Add(p1);
                    }                    
                }

                con1.Close();

            }

            SelectList list1 = new SelectList(personel, "PersonelAdi", "PersonelAdi");
            ViewBag.DropdownListFor1 = list1;

            List<Personel> personel2 = new List<Personel>();

            string cs2 = ConfigurationManager.ConnectionStrings["OtokarContext"].ConnectionString;
            using (SqlConnection con2 = new SqlConnection(cs2))
            {
                SqlCommand cmd2 = new SqlCommand("Select * from Personel", con2);
                con2.Open();
                SqlDataReader rdr2 = cmd2.ExecuteReader();
                while (rdr2.Read())
                {
                    Personel p2 = new Personel();
                    if (id.ToString() == rdr2["PersonelSicilNo"].ToString())
                    {
                        p2.PersonelSoyAdi = rdr2["PersonelSoyAdi"].ToString();
                        personel2.Add(p2);
                    }
                }

                con2.Close();

            }

            SelectList list2 = new SelectList(personel2, "PersonelSoyAdi", "PersonelSoyAdi");
            ViewBag.DropdownListFor2 = list2;

            return View();
        }

        // POST: PersoneleKayitliEnvanter/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PersonelAdi,PersonelSoyAdi,Envanter1,Envanter2,Envanter3,Envanter4,Envanter5,Envanter6,Envanter7")] PersoneleKayitliEnvanter personeleKayitliEnvanter)
        {
            if (ModelState.IsValid)
            {
                db.PersoneleKayitliEnvanter.Add(personeleKayitliEnvanter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personeleKayitliEnvanter);
        }

        // GET: PersoneleKayitliEnvanter/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersoneleKayitliEnvanter personeleKayitliEnvanter = db.PersoneleKayitliEnvanter.Find(id);
            if (personeleKayitliEnvanter == null)
            {
                return HttpNotFound();
            }
            return View(personeleKayitliEnvanter);
        }

        // POST: PersoneleKayitliEnvanter/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PersonelAdi,PersonelSoyAdi,Envanter1,Envanter2,Envanter3,Envanter4,Envanter5,Envanter6,Envanter7")] PersoneleKayitliEnvanter personeleKayitliEnvanter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personeleKayitliEnvanter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personeleKayitliEnvanter);
        }

        // GET: PersoneleKayitliEnvanter/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersoneleKayitliEnvanter personeleKayitliEnvanter = db.PersoneleKayitliEnvanter.Find(id);
            if (personeleKayitliEnvanter == null)
            {
                return HttpNotFound();
            }
            return View(personeleKayitliEnvanter);
        }

        // POST: PersoneleKayitliEnvanter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersoneleKayitliEnvanter personeleKayitliEnvanter = db.PersoneleKayitliEnvanter.Find(id);
            db.PersoneleKayitliEnvanter.Remove(personeleKayitliEnvanter);
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
