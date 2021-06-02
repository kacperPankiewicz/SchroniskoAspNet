using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schronisko.Controllers
{
    public class RasaController : Controller
    {
        private SchroniskoBazaEntities _db = new SchroniskoBazaEntities();
        // GET: rasa
        public ActionResult Index()
        {
            ViewBag.user=Session["username"];
            return View(_db.rasa.ToList());
        }

        // GET: rasa/Details/5
        public ActionResult Details(int id)
        {
            var rasaToDisplay = _db.rasa.Find(id);
            return View(rasaToDisplay);
        }

        // GET: rasa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: rasa/Create
        [HttpPost]
        public ActionResult Create(rasa newRasa)
        {
            try
            {
                // TODO: Add insert logic here
                _db.rasa.Add(newRasa);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(newRasa);
            }
        }

        // GET: rasa/Edit/5
        public ActionResult Edit(int id)
        {
            var rasaToEdit = _db.rasa.Find(id);
            return View(rasaToEdit);
        }

        // POST: rasa/Edit/5
        [HttpPost]
        public ActionResult Edit(rasa rasaToEdit)
        {
            var originalRasa = _db.rasa.Find(rasaToEdit.id);
            try
            {
                // TODO: Add update logic here
                if (TryUpdateModel(originalRasa, new String[] { "nazwa", "opis"}))
                {
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(originalRasa);
            }
        }

        // GET: rasa/Delete/5
        public ActionResult Delete(int id)
        {
            var rasaToDelete = _db.rasa.Find(id);
            return View(rasaToDelete);
        }

        // POST: rasa/Delete/5
        [HttpPost]
        public ActionResult Delete(rasa rasaToDelete)
        {
            try
            {
                var delRasa = _db.rasa.Find(rasaToDelete.id);
                if (!ModelState.IsValid)
                    return View(delRasa);
                _db.rasa.Remove(delRasa);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(rasaToDelete);
            }
        }
    }
}
