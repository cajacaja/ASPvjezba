using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RS1_Ispit_asp.net_core.EF;
using RS1_Ispit_asp.net_core.EntityModels;
using RS1_Ispit_asp.net_core.Helper;
using RS1_Ispit_asp.net_core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class MaturskiIspitController : Controller
    {

        private MojContext _context;

        public MaturskiIspitController(MojContext context) => _context = context;
        // GET: MaturskiIspit
        public ActionResult Index()
        {

            NastavnikLoginVM logiraniNastavnik = HttpContext.GetLogiraniKorisnik();
            SkolskaGodina aktuelnaSkolskaGodina = HttpContext.GetAktuelnaSkolskaGodina();

            if (logiraniNastavnik == null)
                return RedirectToAction("Index", "Login");

            

            MaturskiIpsitIndexVM prikaz = new MaturskiIpsitIndexVM
            {

                Ispiti = _context.MaturskiIspit.Select(x => new MaturskiIpsitIndexVM.Row {

                    MaturskiIspitID = x.MaturskiIspitId,
                    DatumPolaganja = x.DatumIspita.ToShortDateString(),
                    Skola = x.Skola,
                    Predmet = x.Predmet.Naziv,
                    Ispitivac = x.Nastavnik.Ime + " " + x.Nastavnik.Prezime,
                    ProsjecniBodovi =_context.MaturskiIspitStavka.Where(s => s.MaturskiIspitiD == x.MaturskiIspitId).Average(s => s.Rezultat)


                }).ToList()
            };

            return View(prikaz);
        }

        public ActionResult Dodaj()
        {

            


            return View(Podaci());
        }

        public ActionResult Snimi(MaturskiIspitDodajVM obj)
        {
            if (!ModelState.IsValid)
            {

                return View("Dodaj", Podaci());
            }

            NastavnikLoginVM logiraniNastavnik = HttpContext.GetLogiraniKorisnik();

            MaturskiIspit maturskiIspit = new MaturskiIspit
            {

                DatumIspita = obj.DatumIspita,
                Skola = obj.Skola,
                NastavnikID = logiraniNastavnik.NastavnikId,
                OdjeljenjeId = obj.OdjeljenjeID,
                PredmetID = obj.PredmetID
            };

            _context.MaturskiIspit.Add(maturskiIspit);
           

            List<OdjeljenjeStavka> stavke = _context.OdjeljenjeStavka.Where(x => x.OdjeljenjeId == obj.OdjeljenjeID).ToList();

            foreach (var item in stavke)
            {
                double broj = _context.DodjeljenPredmet.Where(x => x.OdjeljenjeStavkaId == item.Id).Average(x => x.ZakljucnoKrajGodine);
                int brojM = _context.MaturskiIspitStavka.Where(x => x.OdjeljenjeStavkaId == item.Id && x.Rezultat > 55).Count();

                if ((broj > 1 &&brojM==0) ){

                    MaturskiIspitStavka novaStavka = new MaturskiIspitStavka {

                        MaturskiIspitiD=maturskiIspit.MaturskiIspitId,//_context.MaturskiIspit.First(x=>x.PredmetID==obj.PredmetID&&x.OdjeljenjeId==obj.OdjeljenjeID&&x.DatumIspita==obj.DatumIspita).MaturskiIspitId,
                        OdjeljenjeStavkaId=item.Id,
                        Rezultat=0f,
                        PristupioIspitu=false,
                        Oslobodjen=false
                    };
                    if (broj == 5)
                        novaStavka.Oslobodjen = true;
                    _context.MaturskiIspitStavka.Add(novaStavka);

                }
            }

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Detalji(int id) {

            SkolskaGodina aktuelnaSkolskaGodina = HttpContext.GetAktuelnaSkolskaGodina();
            DetaljiVM detalji = _context.MaturskiIspit.Where(x => x.MaturskiIspitId == id).Select(x => new DetaljiVM {

                MaturskiIspitId=x.MaturskiIspitId,
                SkolskaGodina= aktuelnaSkolskaGodina.Naziv,
                Skola =x.Skola,
                Odjeljenje=x.Odjeljenje.Oznaka,
                Ispitivac=x.Nastavnik.Ime+" "+x.Nastavnik.Prezime,
                DatumIspita=x.DatumIspita.ToShortDateString(),
                Predmet=x.Predmet.Naziv            }).FirstOrDefault();



            return View(detalji);
        }


        public ActionResult DatumProvjera(DateTime DatumIspita) {

            if (_context.MaturskiIspit.Any(x => x.DatumIspita == DatumIspita))
                return Json($"Datum je zauzet!");

            return Json(true);
        }

        public MaturskiIspitDodajVM Podaci()
        {

            NastavnikLoginVM logiraniNastavnik = HttpContext.GetLogiraniKorisnik();
            SkolskaGodina aktuelnaSkolskaGodina = HttpContext.GetAktuelnaSkolskaGodina();

            MaturskiIspitDodajVM ispit = new MaturskiIspitDodajVM
            {

                Skola = logiraniNastavnik.SkolaNaziv,
                Odjeljenja = _context.Odjeljenje.Where(x => x.SkolaID == logiraniNastavnik.SkolaID && x.Razred == 4).Select(x => new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = x.Oznaka

                }).ToList(),

                Ispitivac = logiraniNastavnik.ImePrezime,
                Skolaskgodina = aktuelnaSkolskaGodina.Naziv,

                Predmeti = _context.PredajePredmet.Where(x => x.NastavnikID == logiraniNastavnik.NastavnikId).Select(x => new SelectListItem
                {
                    Value = x.Predmet.Id.ToString(),
                    Text = x.Predmet.Naziv

                }).ToList()
            };

            return ispit;
        }
    }
}