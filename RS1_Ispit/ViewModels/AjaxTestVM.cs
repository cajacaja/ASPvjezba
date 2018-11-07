using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class AjaxTestVM
    {
        public List<Row> Ucenici { get; set; }

        public class Row {

            public int MaturskiIspitStavkaId { get; set; }

            public string Ucenik { get; set; }

            public float OpciUspjeh { get; set; }

            public bool PristupioIspitu { get; set; }

            public bool Oslobodjen  { get; set; }

            public float Rezultat { get; set; }
        }
    }
}
