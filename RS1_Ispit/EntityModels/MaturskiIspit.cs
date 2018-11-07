using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.EntityModels
{
    public class MaturskiIspit
    {
        public int MaturskiIspitId { get; set; }

        public DateTime DatumIspita { get; set; }
        public string Skola { get; set; }

        public int PredmetID { get; set; }
        public Predmet Predmet { get; set; }

        public int NastavnikID { get; set; }
        public Nastavnik  Nastavnik { get; set; }

        public int OdjeljenjeId { get; set; }
        public Odjeljenje Odjeljenje { get; set; }
    }
}
