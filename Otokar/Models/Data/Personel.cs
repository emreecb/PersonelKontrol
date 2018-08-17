using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Otokar.Models.Data
{
    public class Personel
    {
        [Key]
        public int PersonelSicilNo { get; set; }
        public string PersonelAdi { get; set; }
        public string PersonelSoyAdi { get; set; }
        public string PersonelDogumTarihi { get; set; }
        public string PersonelDogumYeri { get; set; }
        public string PersonelCinsiyet { get; set; }
        public string PersonelTcNo { get; set; }
        public string PersonelMedeniDurum { get; set; }        
        public string PersonelIseBaslamaTarihi { get; set; }
        public string PersonelMeslek { get; set; }
        public string PersonelCalistigiDepartman { get; set; }
        public string PersonelGorevi { get; set; }

    }
}