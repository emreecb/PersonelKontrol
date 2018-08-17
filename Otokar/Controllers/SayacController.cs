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
    public class SayacController : Controller
    {
        // GET: Sayac
        public ActionResult Index()
        {
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


            ViewBag.klavyeSay = klavyeSayac;
            ViewBag.mouseSay = mouseSayac;


            return View();
        }
    }
}