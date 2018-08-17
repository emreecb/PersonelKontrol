using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Otokar.Models.Data
{
    public class PersonelIzinleri
    {
        [Key]
        public int ID { get; set; }
        public string PersonelAdi { get; set; }
        public string PersonelSoyAdi { get; set; }
        public Nullable<System.DateTime> IzinBaslangicTarihi { get; set; }
        public Nullable<System.DateTime> IzinBitisTarihi { get; set; }
    }
}