using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class MaturskiIpsitIndexVM
    {
        public List<Row> Ispiti { get; set; }

        public class Row
        {
            public int MaturskiIspitID { get; set; }

            public string DatumPolaganja { get; set; }

            public string Skola { get; set; }

            public string Predmet { get; set; }

            public string Ispitivac { get; set; }

            public float ProsjecniBodovi { get; set; }
        }
    }
}
