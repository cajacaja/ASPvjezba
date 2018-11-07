using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RS1_Ispit_asp.net_core.ViewModels
{
    public class MaturskiIspitDodajVM
    {


        public string Skola { get; set; }

        public int OdjeljenjeID { get; set; }
        public List<SelectListItem> Odjeljenja { get; set; }

        
        public string Ispitivac { get; set; }

       
        public string Skolaskgodina { get; set; }
        [Remote("DatumProvjera","MaturskiIspit")]          
        public DateTime DatumIspita { get; set; }

        public int PredmetID { get; set; }
        public List<SelectListItem> Predmeti { get; set; }
        
    }
}
