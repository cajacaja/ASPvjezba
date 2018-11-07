using Microsoft.AspNetCore.Mvc;
using RS1_Ispit_asp.net_core.EF;
using RS1_Ispit_asp.net_core.EntityModels;
using RS1_Ispit_asp.net_core.ViewModels;
using System.Linq;

namespace RS1_Ispit_asp.net_core.Controllers
{
    public class AjaxTestController : Controller
    {

        private MojContext _context;

        public AjaxTestController(MojContext context) => _context = context;

        public IActionResult Index(int id)
        {
            AjaxTestVM ucenici = new AjaxTestVM {

                Ucenici=_context.MaturskiIspitStavka.Where(x=>x.MaturskiIspitiD==id).Select(x=>new AjaxTestVM.Row {

                    MaturskiIspitStavkaId=x.MaturskiIspitStavkaId,
                    Ucenik=x.OdjeljenjeStavka.Ucenik.ImePrezime,
                    OpciUspjeh=(float)_context.DodjeljenPredmet.Where(s=>s.OdjeljenjeStavkaId==x.OdjeljenjeStavkaId).Average(s=>s.ZakljucnoKrajGodine),
                    PristupioIspitu=x.PristupioIspitu,
                    Oslobodjen=x.Oslobodjen,
                    Rezultat=x.Rezultat

                }).ToList()
            };

            return PartialView(ucenici);
        }

        public IActionResult Uredi(int id) {

            MaturskiIspitStavka nesto = _context.MaturskiIspitStavka.FirstOrDefault(x => x.MaturskiIspitStavkaId == id);

            UrediVm temp = new UrediVm
            {
                MaturskiIpsitStavkaId = nesto.MaturskiIspitStavkaId
            };

            return PartialView(temp);
        }

        public IActionResult Snimi(UrediVm obj)
        {
            MaturskiIspitStavka nesto = _context.MaturskiIspitStavka.FirstOrDefault(x => x.MaturskiIspitStavkaId == obj.MaturskiIpsitStavkaId);
            nesto.Rezultat = obj.Rezultat;
            nesto.PristupioIspitu = true;

            int temp = nesto.MaturskiIspitiD;

            _context.MaturskiIspitStavka.Update(nesto);
            _context.SaveChanges();

            return RedirectToAction("Index","AjaxTest",new {id=temp });
        }

            public IActionResult AjaxTestAction()
        {
            return PartialView("_AjaxTestView");
        }
    }
}