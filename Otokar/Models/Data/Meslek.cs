using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Otokar.Models.Data
{
    public class Meslek
    {
        [Key]
        public int ID { get; set; }
        public string MeslekAdi { get; set; }
    }
}