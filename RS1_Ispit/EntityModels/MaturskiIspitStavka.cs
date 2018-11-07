using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class MaturskiIspitStavka
    {
        public int MaturskiIspitStavkaId { get; set; }

        public float Rezultat { get; set; }

        public bool PristupioIspitu { get; set; }

        public bool Oslobodjen { get; set; }

        public int MaturskiIspitiD { get; set; }
        public MaturskiIspit MaturskiIspit { get; set; }

        public int OdjeljenjeStavkaId { get; set; }
        public OdjeljenjeStavka OdjeljenjeStavka { get; set; }
    }
}
