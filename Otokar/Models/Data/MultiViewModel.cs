using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Otokar.Models.Data
{
    public class MultiViewModel
    {
        public Meslek Meslek { get; set; }
        public Gorev Gorev { get; set; }
        public Personel Personel { get; set; }
        public Departman Departman { get; set; }

    }
}