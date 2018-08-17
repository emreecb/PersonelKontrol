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
    public class StoktakiEnvanterSayisiController : Controller
    {
        private OtokarContext db = new OtokarContext();

        // GET: StoktakiEnvanterSayisi
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

            var stoktakiEnvanters = from c in db.StoktakiEnvanterSayisi
                           select c;

            if (!string.IsNullOrEmpty(searchString))
            {
                stoktakiEnvanters = stoktakiEnvanters.Where(c => c.EnvanterAdi.Contains(searchString));
            }

            stoktakiEnvanters = stoktakiEnvanters.OrderBy(c => c.ID);

            int pageSize = 8;
            int pageNumber = (page ?? 1);


            int klavyeSayac = 0;
            int mouseSayac = 0;
            int kasaSayac = 0;
            int laptopSayac = 0;
            int monitorSayac = 0;
            int yaziciSayac = 0;
            string cs = ConfigurationManager.ConnectionStrings["OtokarContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand("Select * from PersoneleKayitliEnvanter", con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    PersoneleKayitliEnvanter d1 = new PersoneleKayitliEnvanter();
                    if (rdr["Envanter1"].ToString() == "Klavye")
                    {
                        klavyeSayac++;
                    }
                    if (rdr["Envanter2"].ToString() == "Klavye")
                    {
                        klavyeSayac++;
                    }
                    if (rdr["Envanter3"].ToString() == "Klavye")
                    {
                        klavyeSayac++;
                    }
                    if (rdr["Envanter4"].ToString() == "Klavye")
                    {
                        klavyeSayac++;
                    }
                    if (rdr["Envanter5"].ToString() == "Klavye")
                    {
                        klavyeSayac++;
                    }
                    if (rdr["Envanter6"].ToString() == "Klavye")
                    {
                        klavyeSayac++;
                    }
                    if (rdr["Envanter7"].ToString() == "Klavye")
                    {
                        klavyeSayac++;
                    }
                    if (rdr["Envanter1"].ToString() == "Mouse")
                    {
                        mouseSayac++;
                    }
                    if (rdr["Envanter2"].ToString() == "Mouse")
                    {
                        mouseSayac++;
                    }
                    if (rdr["Envanter3"].ToString() == "Mouse")
                    {
                        mouseSayac++;
                    }
                    if (rdr["Envanter4"].ToString() == "Mouse")
                    {
                        mouseSayac++;
                    }
                    if (rdr["Envanter5"].ToString() == "Mouse")
                    {
                        mouseSayac++;
                    }
                    if (rdr["Envanter6"].ToString() == "Mouse")
                    {
                        mouseSayac++;
                    }
                    if (rdr["Envanter7"].ToString() == "Mouse")
                    {
                        mouseSayac++;
                    }
                    if (rdr["Envanter1"].ToString() == "Kasa")
                    {
                        kasaSayac++;
                    }
                    if (rdr["Envanter2"].ToString() == "Kasa")
                    {
                        kasaSayac++;
                    }
                    if (rdr["Envanter3"].ToString() == "Kasa")
                    {
                        kasaSayac++;
                    }
                    if (rdr["Envanter4"].ToString() == "Kasa")
                    {
                        kasaSayac++;
                    }
                    if (rdr["Envanter5"].ToString() == "Kasa")
                    {
                        kasaSayac++;
                    }
                    if (rdr["Envanter6"].ToString() == "Kasa")
                    {
                        kasaSayac++;
                    }
                    if (rdr["Envanter7"].ToString() == "Kasa")
                    {
                        kasaSayac++;
                    }
                    if (rdr["Envanter1"].ToString() == "Laptop")
                    {
                        laptopSayac++;
                    }
                    if (rdr["Envanter2"].ToString() == "Laptop")
                    {
                        laptopSayac++;
                    }
                    if (rdr["Envanter3"].ToString() == "Laptop")
                    {
                        laptopSayac++;
                    }
                    if (rdr["Envanter4"].ToString() == "Laptop")
                    {
                        laptopSayac++;
                    }
                    if (rdr["Envanter5"].ToString() == "Laptop")
                    {
                        laptopSayac++;
                    }
                    if (rdr["Envanter6"].ToString() == "Laptop")
                    {
                        laptopSayac++;
                    }
                    if (rdr["Envanter7"].ToString() == "Laptop")
                    {
                        laptopSayac++;
                    }
                    if (rdr["Envanter1"].ToString() == "Monitör")
                    {
                        monitorSayac++;
                    }
                    if (rdr["Envanter2"].ToString() == "Monitör")
                    {
                        monitorSayac++;
                    }
                    if (rdr["Envanter3"].ToString() == "Monitör")
                    {
                        monitorSayac++;
                    }
                    if (rdr["Envanter4"].ToString() == "Monitör")
                    {
                        monitorSayac++;
                    }
                    if (rdr["Envanter5"].ToString() == "Monitör")
                    {
                        monitorSayac++;
                    }
                    if (rdr["Envanter6"].ToString() == "Monitör")
                    {
                        monitorSayac++;
                    }
                    if (rdr["Envanter7"].ToString() == "Monitör")
                    {
                        monitorSayac++;
                    }
                    if (rdr["Envanter1"].ToString() == "Yazıcı")
                    {
                        yaziciSayac++;
                    }
                    if (rdr["Envanter2"].ToString() == "Yazıcı")
                    {
                        yaziciSayac++;
                    }
                    if (rdr["Envanter3"].ToString() == "Yazıcı")
                    {
                        yaziciSayac++;
                    }
                    if (rdr["Envanter4"].ToString() == "Yazıcı")
                    {
                        yaziciSayac++;
                    }
                    if (rdr["Envanter5"].ToString() == "Yazıcı")
                    {
                        yaziciSayac++;
                    }
                    if (rdr["Envanter6"].ToString() == "Yazıcı")
                    {
                        yaziciSayac++;
                    }
                    if (rdr["Envanter7"].ToString() == "Yazıcı")
                    {
                        yaziciSayac++;
                    }
                }
                con.Close();
            }


            ViewBag.view1 = klavyeSayac;
            ViewBag.view2 = mouseSayac;
            ViewBag.view3 = kasaSayac;
            ViewBag.view4 = laptopSayac;
            ViewBag.view5 = monitorSayac;
            ViewBag.view6 = yaziciSayac;


            return View(stoktakiEnvanters.ToPagedList(pageNumber, pageSize));
        }

        // GET: StoktakiEnvanterSayisi/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoktakiEnvanterSayisi stoktakiEnvanterSayisi = db.StoktakiEnvanterSayisi.Find(id);
            if (stoktakiEnvanterSayisi == null)
            {
                return HttpNotFound();
            }
            return View(stoktakiEnvanterSayisi);
        }

        // GET: StoktakiEnvanterSayisi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoktakiEnvanterSayisi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EnvanterAdi,EnvanterSayisi")] StoktakiEnvanterSayisi stoktakiEnvanterSayisi)
        {
            if (ModelState.IsValid)
            {
                db.StoktakiEnvanterSayisi.Add(stoktakiEnvanterSayisi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(stoktakiEnvanterSayisi);
        }

        // GET: StoktakiEnvanterSayisi/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoktakiEnvanterSayisi stoktakiEnvanterSayisi = db.StoktakiEnvanterSayisi.Find(id);
            if (stoktakiEnvanterSayisi == null)
            {
                return HttpNotFound();
            }
            return View(stoktakiEnvanterSayisi);
        }

        // POST: StoktakiEnvanterSayisi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EnvanterAdi,EnvanterSayisi")] StoktakiEnvanterSayisi stoktakiEnvanterSayisi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stoktakiEnvanterSayisi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(stoktakiEnvanterSayisi);
        }

        // GET: StoktakiEnvanterSayisi/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StoktakiEnvanterSayisi stoktakiEnvanterSayisi = db.StoktakiEnvanterSayisi.Find(id);
            if (stoktakiEnvanterSayisi == null)
            {
                return HttpNotFound();
            }
            return View(stoktakiEnvanterSayisi);
        }

        // POST: StoktakiEnvanterSayisi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StoktakiEnvanterSayisi stoktakiEnvanterSayisi = db.StoktakiEnvanterSayisi.Find(id);
            db.StoktakiEnvanterSayisi.Remove(stoktakiEnvanterSayisi);
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
