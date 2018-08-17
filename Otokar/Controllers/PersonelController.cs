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
    public class PersonelController : Controller
    {
        private OtokarContext db = new OtokarContext();

        // GET: Personel
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

            if(!string.IsNullOrEmpty(searchString))
            {
                personel = personel.Where(c => c.PersonelAdi.Contains(searchString));
            }

            personel = personel.OrderBy(c => c.PersonelSicilNo);

            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(personel.ToPagedList(pageNumber, pageSize));
        }
        

        // GET: Personel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personel.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // GET: Personel/Create
        public ActionResult Create()
        {
            List<Departman> departman = new List<Departman>();

            string cs = ConfigurationManager.ConnectionStrings["OtokarContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from Departman", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Departman d1 = new Departman();
                    d1.DepartmanAdi = rdr["DepartmanAdi"].ToString();
                    departman.Add(d1);
                }

            }

            SelectList list = new SelectList(departman, "DepartmanAdi", "DepartmanAdi");
            ViewBag.DropdownListFor = list;

            List<Meslek> meslek = new List<Meslek>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from Meslek", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Meslek m1 = new Meslek();
                    m1.MeslekAdi = rdr["MeslekAdi"].ToString();
                    meslek.Add(m1);
                }

            }

            SelectList list2 = new SelectList(meslek, "MeslekAdi", "MeslekAdi");
            ViewBag.DropdownListFor2 = list2;

            List<Gorev> gorev = new List<Gorev>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from Gorev", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Gorev g1 = new Gorev();
                    g1.GorevAdi = rdr["GorevAdi"].ToString();
                    gorev.Add(g1);
                }

            }

            SelectList list3 = new SelectList(gorev, "GorevAdi", "GorevAdi");
            ViewBag.DropdownListFor3 = list3;

            return View();
        }

        // POST: Personel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonelSicilNo,PersonelAdi,PersonelSoyAdi,PersonelDogumTarihi,PersonelDogumYeri,PersonelCinsiyet,PersonelTcNo,PersonelMedeniDurum,PersonelIseBaslamaTarihi,PersonelMeslek,PersonelCalistigiDepartman,PersonelGorevi")] Personel personel)
        {
            if (ModelState.IsValid)
            {
                db.Personel.Add(personel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(personel);
        }

        // GET: Personel/Edit/5
        public ActionResult Edit(int? id)
        {

            List<Departman> departman = new List<Departman>();

            string cs = ConfigurationManager.ConnectionStrings["OtokarContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from Departman", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Departman d1 = new Departman();
                    d1.DepartmanAdi = rdr["DepartmanAdi"].ToString();
                    departman.Add(d1);
                }

            }

            SelectList list = new SelectList(departman, "DepartmanAdi", "DepartmanAdi");
            ViewBag.DropdownListFor = list;

            List<Meslek> meslek = new List<Meslek>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from Meslek", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Meslek m1 = new Meslek();
                    m1.MeslekAdi = rdr["MeslekAdi"].ToString();
                    meslek.Add(m1);
                }

            }

            SelectList list2 = new SelectList(meslek, "MeslekAdi", "MeslekAdi");
            ViewBag.DropdownListFor2 = list2;

            List<Gorev> gorev = new List<Gorev>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from Gorev", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Gorev g1 = new Gorev();
                    g1.GorevAdi = rdr["GorevAdi"].ToString();
                    gorev.Add(g1);
                }

            }

            SelectList list3 = new SelectList(gorev, "GorevAdi", "GorevAdi");
            ViewBag.DropdownListFor3 = list3;




            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personel.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // POST: Personel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonelSicilNo,PersonelAdi,PersonelSoyAdi,PersonelDogumTarihi,PersonelDogumYeri,PersonelCinsiyet,PersonelTcNo,PersonelMedeniDurum,PersonelIseBaslamaTarihi,PersonelMeslek,PersonelCalistigiDepartman,PersonelGorevi")] Personel personel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(personel);
        }

        // GET: Personel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personel.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // POST: Personel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personel personel = db.Personel.Find(id);
            db.Personel.Remove(personel);
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
