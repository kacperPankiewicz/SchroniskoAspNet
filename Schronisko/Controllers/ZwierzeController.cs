using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schronisko.Controllers
{
    public class ZwierzeController : Controller
    {
        // GET: Zwierze
        private SchroniskoBazaEntities _db = new SchroniskoBazaEntities();
        List<SelectListItem> kastracja = new List<SelectListItem>(new[]
        {
            new SelectListItem() { Value="0", Text="Nie"},
            new SelectListItem() { Value="1", Text="Tak"},
        });
        List<SelectListItem> plec = new List<SelectListItem>(new[]
       {
            new SelectListItem() { Value="Ona", Text="Ona"},
            new SelectListItem() { Value="On", Text="On"},
        });
        List<SelectListItem> gatunek = new List<SelectListItem>(new[]
      {
            new SelectListItem() { Value="pies", Text="pies"},
            new SelectListItem() { Value="kot", Text="kot"},
        });
        List<SelectListItem> wielkosc = new List<SelectListItem>(new[]
      {
            new SelectListItem() { Value="maly", Text="mały"},
            new SelectListItem() { Value="duzy", Text="duży"},
            new SelectListItem() { Value="sredni", Text="średni"}
        });

        public ActionResult Index()
        {
            
            return View(_db.zwierze.ToList());
        }

        // GET: Zwierze/Details/5
        public ActionResult Details(int id)
        {
            var zwierzeToDisplay = _db.zwierze.Find(id);
            ViewBag.nazwa = zwierzeToDisplay.nazwa;
            return View(zwierzeToDisplay);
        }

        // GET: Zwierze/Create
        public ActionResult Create()
        {
            ViewBag.kastracja_list = kastracja;
            ViewBag.plec_list = plec;
            ViewBag.gatunek_list = gatunek;
            ViewBag.wielkosc_list = wielkosc;
            List<SelectListItem> query = (from item in _db.kojec
                                          select new SelectListItem()
                                          {
                                              Text = item.dystrykt + " " + item.klatka,
                                              Value = item.id.ToString()
                                          }).ToList();


            List<SelectListItem> query2 = (from item in _db.rasa
                                          select new SelectListItem()
                                          {
                                              Text = item.nazwa,
                                              Value = item.id.ToString()
                                          }).ToList();
            ViewBag.Kojec_id = query;
            ViewBag.rasa_id = query2;

            return View();
        }

        // POST: Zwierze/Create
        [HttpPost]
        public ActionResult Create(zwierze newZwierze)
        {

            try
            {
                // TODO: Add insert logic here
                _db.zwierze.Add(newZwierze);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(newZwierze);
            }
        }

        // GET: Zwierze/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.kastracja_list = kastracja;
            ViewBag.plec_list = plec;
            ViewBag.gatunek_list = gatunek;
            ViewBag.wielkosc_list = wielkosc;
            List<SelectListItem> query = (from item in _db.kojec
                                          select new SelectListItem()
                                          {
                                              Text = item.dystrykt + " " + item.klatka,
                                              Value = item.id.ToString()
                                          }).ToList();
            

            List<SelectListItem> query2 = (from item in _db.rasa
                                           select new SelectListItem()
                                           {
                                               Text = item.nazwa,
                                               Value = item.id.ToString()
                                           }).ToList();
            ViewBag.Kojec_id = query;
            ViewBag.rasa_id = query2;
            var zwierzeToEdit = _db.zwierze.Find(id);
            return View(zwierzeToEdit);
        }

        // POST: Zwierze/Edit/5
        [HttpPost]
        public ActionResult Edit(zwierze zwierzeToEdit)
        {
            var originalZwierze = _db.zwierze.Find(zwierzeToEdit.id);
            try
            {
                // TODO: Add update logic here
                if (TryUpdateModel(originalZwierze, new String[] { "nazwa", "data_ur", "kastracja","Kojec_id","rasa_id","zdjecie","status","plec","gatunek","wielkosc" }))
                {
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(originalZwierze);
            }
        }

        // GET: Zwierze/Delete/5
        public ActionResult Delete(int id)
        {
            var zwierzeToDelete = _db.zwierze.Find(id);
            return View(zwierzeToDelete);
        }

        // POST: Zwierze/Delete/5
        [HttpPost]
        public ActionResult Delete(zwierze zwierzeToDelete)
        {
            try
            {
                var delZwierze = _db.zwierze.Find(zwierzeToDelete.id);
               
                _db.zwierze.Remove(delZwierze);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(zwierzeToDelete);
            }
        }
    }
}
