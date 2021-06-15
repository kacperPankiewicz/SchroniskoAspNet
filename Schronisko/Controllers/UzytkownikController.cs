using Schronisko.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schronisko.Controllers
{
    public class UzytkownikController : Controller
    {
        private SchroniskoBazaEntities _db = new SchroniskoBazaEntities();
        // GET: uzytkownik
        public ActionResult Index()
        {

            var val = Session["user_cred"] == null ? 0 : ((konto_info)Session["user_cred"]).Uprawnienia_id;
            if (val != 1)
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            else
                return View(_db.uzytkownik.ToList());
        }

        // GET: uzytkownik/Details/5
        public ActionResult Details(int id)
        {
            var uzytkownikToDisplay = _db.uzytkownik.Find(id);
            return View(uzytkownikToDisplay);
        }

        // GET: uzytkownik/Create
        public ActionResult Create()
        {
            List<SelectListItem> query = (from item in _db.uprawnienia
                                          select new SelectListItem()
                                          {
                                              Text = item.nazwa,
                                              Value = item.id.ToString()
                                          }).ToList();
            ViewBag.Uprawnienia_id = query;

            return View();
        }

        // POST: uzytkownik/Create
        [HttpPost]
        public ActionResult Create(Uzytkownik_kontoInfoVM newKonto)
        {
            konto_info kontInf = new konto_info();
            kontInf.login = newKonto.login;
            kontInf.haslo = newKonto.haslo;
            kontInf.Uprawnienia_id = 2 ;
            _db.konto_info.Add(kontInf);


            uzytkownik uz = new uzytkownik();
            uz.imie = newKonto.imie;
            uz.nazwisko = newKonto.nazwisko;
            uz.pesel = newKonto.pesel;
            uz.miasto = newKonto.miasto;
            uz.kod_pocztowy = newKonto.kod_pocztowy;
            uz.ulica = newKonto.ulica;
            uz.nr_mieszkania = newKonto.nr_mieszkania;
            _db.uzytkownik.Add(uz);
            _db.SaveChanges();


            return RedirectToAction("Index");


        }

        // GET: uzytkownik/Edit/5
        public ActionResult Edit(int id)
        {
            List<SelectListItem> query = (from item in _db.uprawnienia
                                          select new SelectListItem()
                                          {
                                              Text = item.nazwa,
                                              Value = item.id.ToString()
                                          }).ToList();
            ViewBag.Uprawnienia_id = query;

            var uzytkownikToEdit = _db.uzytkownik.Find(id);
            return View(uzytkownikToEdit);
        }

        // POST: uzytkownik/Edit/5
        [HttpPost]
        public ActionResult Edit(uzytkownik uzytkownikToEdit)
        {
            var originalUzytkownik = _db.uzytkownik.Find(uzytkownikToEdit.id);
            try
            {
                // TODO: Add update logic here
                if (TryUpdateModel(originalUzytkownik, new String[] { "nazwa", "opis" }))
                {
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(originalUzytkownik);
            }
        }

        // GET: uzytkownik/Delete/5
        public ActionResult Delete(int id)
        {
            var uzytkownikToDelete = _db.uzytkownik.Find(id);
            return View(uzytkownikToDelete);
        }

        // POST: uzytkownik/Delete/5
        [HttpPost]
        public ActionResult Delete(uzytkownik uzytkownikToDelete)
        {
            try
            {
                var delUzytkownik = _db.uzytkownik.Find(uzytkownikToDelete.id);
         
                if (!ModelState.IsValid)
                    return View(delUzytkownik);
                _db.uzytkownik.Remove(delUzytkownik);
              
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(uzytkownikToDelete);
            }
        }
    }
}
