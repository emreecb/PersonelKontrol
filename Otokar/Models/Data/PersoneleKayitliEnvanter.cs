using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Otokar.Models.Data
{
    public class PersoneleKayitliEnvanter
    {
        [Key]
        public int ID { get; set; }
        public string PersonelAdi { get; set; }
        public string PersonelSoyAdi { get; set; }
        public string Envanter1 { get; set; }
        public string Envanter2 { get; set; }
        public string Envanter3 { get; set; }
        public string Envanter4 { get; set; }
        public string Envanter5 { get; set; }
        public string Envanter6 { get; set; }
        public string Envanter7 { get; set; }


    }
}