using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schronisko.Controllers
{
    public class Historia_adopcjiController : Controller
    {
        // GET: Historia_adopcji
        private SchroniskoBazaEntities _db = new SchroniskoBazaEntities();
        public ActionResult Index()
        {
            return View(_db.historia_adopcji.ToList());
        }

        // GET: Historia_adopcji/Details/5
        public ActionResult Details(int id)
        {
            var historia_adopcjiToDisplay = _db.historia_adopcji.Find(id);
            return View(historia_adopcjiToDisplay);
    }

        // GET: Historia_adopcji/Create
        
        public ActionResult Create()
        {
            
               

                List<SelectListItem> query = (from item in _db.zwierze
                                               select new SelectListItem()
                                               {
                                                   Text = item.nazwa,
                                                   Value = item.id.ToString()
                                               }).ToList();
            List<SelectListItem> query2 = (from item in _db.uzytkownik
                                          select new SelectListItem()
                                          {
                                              Text = item.imie +" "+item.nazwisko,
                                              Value = item.id.ToString()
                                          }).ToList();
            List<SelectListItem> query3 = (from item in _db.pracownik
                                           select new SelectListItem()
                                           {
                                               Text = item.imie + " " + item.nazwisko,
                                               Value = item.id.ToString()
                                           }).ToList();
            ViewBag.Zwierze_id = query;
            ViewBag.Uzytkownik_id = query2;
            ViewBag.Pracownik_id = query3;

            return View();
        }
        // POST: kojec/Create
        [HttpPost]
        public ActionResult Create(historia_adopcji newHistoria)
    {
        try
        {
            // TODO: Add insert logic here
            _db.historia_adopcji.Add(newHistoria);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        catch
        {
            return View(newHistoria);
        }
    }

    // GET: Historia_adopcji/Edit/5
    public ActionResult Edit(int id)
    {
            List<SelectListItem> query = (from item in _db.zwierze
                                          select new SelectListItem()
                                          {
                                              Text = item.nazwa,
                                              Value = item.id.ToString()
                                          }).ToList();
            List<SelectListItem> query2 = (from item in _db.uzytkownik
                                           select new SelectListItem()
                                           {
                                               Text = item.imie + " " + item.nazwisko,
                                               Value = item.id.ToString()
                                           }).ToList();
            List<SelectListItem> query3 = (from item in _db.pracownik
                                           select new SelectListItem()
                                           {
                                               Text = item.imie + " " + item.nazwisko,
                                               Value = item.id.ToString()
                                           }).ToList();
            ViewBag.Zwierze_id = query;
            ViewBag.Uzytkownik_id = query2;
            ViewBag.Pracownik_id = query3;

            var historiaToEdit = _db.historia_adopcji.Find(id);
        return View(historiaToEdit);
    }

    // POST: Historia_adopcji/Edit/5
    [HttpPost]
    public ActionResult Edit(historia_adopcji historiaToEdit)
    {
        var originalHistoria = _db.historia_adopcji.Find(historiaToEdit.id);
        try
        {
            // TODO: Add update logic here
            if (TryUpdateModel(originalHistoria, new String[] { "dystrykt", "klatka" }))
            {
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        catch
        {
            return View(originalHistoria);
        }
    }

    // GET: Historia_adopcji/Delete/5
    public ActionResult Delete(int id)
    {
        var historiaToDelete = _db.historia_adopcji.Find(id);
        return View(historiaToDelete);
    }

    // POST: Historia_adopcji/Delete/5
    [HttpPost]
    public ActionResult Delete(historia_adopcji historiaToDelete)
    {
        try
        {
            var delHistoria = _db.historia_adopcji.Find(historiaToDelete.id);
            if (!ModelState.IsValid)
                return View(delHistoria);
            _db.historia_adopcji.Remove(delHistoria);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
        catch
        {
            return View(historiaToDelete);
        }
    }
}
}