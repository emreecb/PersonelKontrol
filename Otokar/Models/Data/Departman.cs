using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Otokar.Models.Data
{
    public class Departman
    {
        [Key]
        public int DepartmanNo { get; set; }
        public string DepartmanAdi { get; set; }
    }
}