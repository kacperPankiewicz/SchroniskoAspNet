using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schronisko.Controllers
{
    public class WyszukiwarkaController : Controller
    {
       
        private SchroniskoBazaEntities _db = new SchroniskoBazaEntities();
        List<SelectListItem> kastracja = new List<SelectListItem>(new[]
      {
            new SelectListItem() { Value="", Text=""},
            new SelectListItem() { Value="nie", Text="nie"},
            new SelectListItem() { Value="tak", Text="tak"},
        });
        List<SelectListItem> plec = new List<SelectListItem>(new[]
       {    new SelectListItem() { Value="", Text=""},
            new SelectListItem() { Value="Ona", Text="Ona"},
            new SelectListItem() { Value="On", Text="On"},
        });
        List<SelectListItem> gatunek = new List<SelectListItem>(new[]
      {     new SelectListItem() { Value="", Text=""},
            new SelectListItem() { Value="pies", Text="pies"},
            new SelectListItem() { Value="kot", Text="kot"},
        });
        List<SelectListItem> wielkosc = new List<SelectListItem>(new[]
      {     new SelectListItem() { Value="", Text=""},
            new SelectListItem() { Value="maly", Text="mały"},
            new SelectListItem() { Value="duzy", Text="duży"},
            new SelectListItem() { Value="sredni", Text="średni"}
        });

        public ActionResult Index()
        {
            ViewBag.wielkoscList = wielkosc;
            ViewBag.gatunekList = gatunek;
            ViewBag.plecList = plec;
            ViewBag.kastracjaList = kastracja;
            var zwierz = from m in _db.zwierze
                         select m;
            var nazwaSelected = Request.Form["nameString"] != null ? Request.Form["nameString"].ToString() : "";
            var wielkoscSelected = Request.Form["wielkoscList"] != null ? Request.Form["wielkoscList"] : "";
            var gatunekSelected = Request.Form["gatunekList"] != null ? Request.Form["gatunekList"].ToString() : "";
            var plecSelected = Request.Form["plecList"] != null ? Request.Form["plecList"].ToString() : "";
            var kastracjaSelected = Request.Form["kastracjaList"] != null ? Request.Form["kastracjaList"].ToString() : "";

            if (!String.IsNullOrEmpty(nazwaSelected))
            {
                zwierz = zwierz.Where(s => s.nazwa.Contains(nazwaSelected));
            }
            
            if (!String.IsNullOrEmpty(wielkoscSelected))
            {
                zwierz = _db.zwierze.Where(s => s.wielkosc.Contains(wielkoscSelected));
            }
            if (!String.IsNullOrEmpty(gatunekSelected))
            {
                zwierz = _db.zwierze.Where(s => s.gatunek.Contains(gatunekSelected));
            }
            if (!String.IsNullOrEmpty(plecSelected))
            {
                zwierz = _db.zwierze.Where(s => s.plec.Contains(plecSelected));
            }
            if (!String.IsNullOrEmpty(kastracjaSelected))
            {
                zwierz = _db.zwierze.Where(s => s.kastracja.Contains(kastracjaSelected));
            }

            return View(zwierz);
        }













    }
}
