using Schronisko.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schronisko.Controllers
{
    public class KontoInfoController : Controller
    {
        private SchroniskoBazaEntities _db = new SchroniskoBazaEntities();
        // GET: konto_info
        public ActionResult Index()
        {
            return View(_db.konto_info.ToList());
        }

        // GET: konto_info/Details/5
        public ActionResult Details(int id)
        {
            var konto_infoToDisplay = _db.konto_info.Find(id);
            return View(konto_infoToDisplay);
        }

        // GET: konto_info/Create
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

        // POST: konto_info/Create
        [HttpPost]
        public ActionResult Create(Uzytkownik_kontoInfoVM newKonto)
        {
            konto_info kontInf = new konto_info();
            kontInf.login = newKonto.login;
            kontInf.haslo = newKonto.haslo;
            kontInf.Uprawnienia_id = newKonto.Uprawnienia_id;
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

        // GET: konto_info/Edit/5
        public ActionResult Edit(int id)
        {
            List<SelectListItem> query = (from item in _db.uprawnienia
                                          select new SelectListItem()
                                          {
                                              Text = item.nazwa,
                                              Value = item.id.ToString()
                                          }).ToList();
            ViewBag.Uprawnienia_id = query;

            var konto_infoToEdit = _db.konto_info.Find(id);
            return View(konto_infoToEdit);
        }

        // POST: konto_info/Edit/5
        [HttpPost]
        public ActionResult Edit(konto_info konto_infoToEdit)
        {
            var originalKonto = _db.konto_info.Find(konto_infoToEdit.id);
            try
            {
                // TODO: Add update logic here
                if (TryUpdateModel(originalKonto, new String[] { "nazwa", "opis" }))
                {
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(originalKonto);
            }
        }

        // GET: konto_info/Delete/5
        public ActionResult Delete(int id)
        {
            var konto_infoToDelete = _db.konto_info.Find(id);
            return View(konto_infoToDelete);
        }

        // POST: konto_info/Delete/5
        [HttpPost]
        public ActionResult Delete(konto_info konto_infoToDelete)
        {
            try
            {
                
                var delKonto = _db.konto_info.Find(konto_infoToDelete.id);
                if (!ModelState.IsValid)
                    return View(delKonto);
                _db.konto_info.Remove(delKonto);
                
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(konto_infoToDelete);
            }
        }
    }
}
