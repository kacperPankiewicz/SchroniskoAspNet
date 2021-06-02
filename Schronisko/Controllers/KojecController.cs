using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schronisko.Controllers
{
    public class KojecController : Controller
    {
        private SchroniskoBazaEntities _db = new SchroniskoBazaEntities();
        // GET: Kojec
        public ActionResult Index()
        {
            return View(_db.kojec.ToList());
        }

        // GET: kojec/Details/5
        public ActionResult Details(int id)
        {
            var kojecToDisplay = _db.kojec.Find(id);
            return View(kojecToDisplay);
        }

        // GET: kojec/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: kojec/Create
        [HttpPost]
        public ActionResult Create(kojec newKojec)
        {
            try
            {
                // TODO: Add insert logic here
                _db.kojec.Add(newKojec);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(newKojec);
            }
        }

        // GET: kojec/Edit/5
        public ActionResult Edit(int id)
        {
            var kojecToEdit = _db.kojec.Find(id);
            return View(kojecToEdit);
        }

        // POST: kojec/Edit/5
        [HttpPost]
        public ActionResult Edit(kojec kojecToEdit)
        {
            var originalKojec = _db.kojec.Find(kojecToEdit.id);
            try
            {
                // TODO: Add update logic here
                if (TryUpdateModel(originalKojec, new String[] { "dystrykt", "klatka" }))
                {
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(originalKojec);
            }
        }

        // GET: kojec/Delete/5
        public ActionResult Delete(int id)
        {
            var kojecToDelete = _db.kojec.Find(id);
            return View(kojecToDelete);
        }

        // POST: kojec/Delete/5
        [HttpPost]
        public ActionResult Delete(kojec kojecToDelete)
        {
            try
            {
                var delKojec = _db.kojec.Find(kojecToDelete.id);
                if (!ModelState.IsValid)
                    return View(delKojec);
                _db.kojec.Remove(delKojec);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(kojecToDelete);
            }
        }
    }
}
