using Schronisko.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schronisko.Controllers
{
    public class PracownikController : Controller
    {
        private SchroniskoBazaEntities _db = new SchroniskoBazaEntities();
        // GET: pracownik
        public ActionResult Index()
        {
            return View(_db.pracownik.ToList());
        }

        // GET: pracownik/Details/5
        public ActionResult Details(int id)
        {
            var pracownikToDisplay = _db.pracownik.Find(id);
            return View(pracownikToDisplay);
        }

        // GET: pracownik/Create
        public ActionResult Create()
        {
            List<SelectListItem> query = (from item in _db.uprawnienia
                                          select new SelectListItem()
                                          {
                                              Text = item.nazwa,
                                              Value = item.id.ToString()
                                          }).ToList();
            ViewBag.Uprawnienia_id = query;
            List<SelectListItem> query2 = (from item in _db.stanowisko
                                           select new SelectListItem()
                                           {
                                               Text = item.nazwa,
                                               Value = item.id.ToString()
                                           }).ToList();
            ViewBag.stanowisko_id = query2;

            return View();
        }

        // POST: pracownik/Create
        [HttpPost]
        public ActionResult Create(Pracownik_kontoInfoVM newKonto)
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

            pracownik pr = new pracownik();
            pr.imie = newKonto.imie;
            pr.nazwisko = newKonto.nazwisko;
            pr.pesel = newKonto.pesel;
            pr.miasto = newKonto.miasto;
            pr.kod_pocztowy = newKonto.kod_pocztowy;
            pr.ulica = newKonto.ulica;
            pr.nr_mieszkania = newKonto.nr_mieszkania;
            pr.stanowisko_id = newKonto.stanowisko_id;
            _db.pracownik.Add(pr);
            _db.SaveChanges();


            return RedirectToAction("Index");


        }

        // GET: pracownik/Edit/5
        public ActionResult Edit(int id)
        {
            List<SelectListItem> query = (from item in _db.uprawnienia
                                          select new SelectListItem()
                                          {
                                              Text = item.nazwa,
                                              Value = item.id.ToString()
                                          }).ToList();
            ViewBag.Uprawnienia_id = query;
            List<SelectListItem> query2 = (from item in _db.stanowisko
                                           select new SelectListItem()
                                           {
                                               Text = item.nazwa,
                                               Value = item.id.ToString()
                                           }).ToList();
            ViewBag.stanowisko_id = query;

            var pracownikToEdit = _db.pracownik.Find(id);
            return View(pracownikToEdit);
        }

        // POST: pracownik/Edit/5
        [HttpPost]
        public ActionResult Edit(pracownik pracownikToEdit)
        {
            var originalPracownik = _db.pracownik.Find(pracownikToEdit.id);
            try
            {
                // TODO: Add update logic here
                if (TryUpdateModel(originalPracownik, new String[] { "imie", "nazwisko", "pesel", "miasto", "kod_pocztowy", "ulica", "nr_mieszkania", "stanowisko_id", "Uzytkownik_Info_id" }))
                {
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(originalPracownik);
            }
        }

        // GET: pracownik/Delete/5
        public ActionResult Delete(int id)
        {
            var pracownikToDelete = _db.pracownik.Find(id);
            return View(pracownikToDelete);
        }

        // POST: pracownik/Delete/5
        [HttpPost]
        public ActionResult Delete(pracownik pracownikToDelete)
        {
            try
            {
                var delPracownik = _db.pracownik.Find(pracownikToDelete.id);
                if (!ModelState.IsValid)
                    return View(delPracownik);
                _db.pracownik.Remove(delPracownik);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(pracownikToDelete);
            }
        }
    }
}
