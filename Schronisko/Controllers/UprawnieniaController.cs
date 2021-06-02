using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schronisko.Controllers
{
    public class UprawnieniaController : Controller
    {
        private SchroniskoBazaEntities _db = new SchroniskoBazaEntities();
        // GET: uprawnienia
        public ActionResult Index()
        {
            return View(_db.uprawnienia.ToList());
        }

        // GET: Uprawnienia/Details/5
        public ActionResult Details(int id)
        {
            var uprawnieniaToDisplay = _db.uprawnienia.Find(id);
            return View(uprawnieniaToDisplay);
        }

        // GET: Uprawnienia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Uprawnienia/Create
        [HttpPost]
        public ActionResult Create(uprawnienia newUprawnienia)
        {
            try
            {
                // TODO: Add insert logic here
                _db.uprawnienia.Add(newUprawnienia);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(newUprawnienia);
            }
        }

        // GET: Uprawnienia/Edit/5
        public ActionResult Edit(int id)
        {
            var uprawnieniaToEdit = _db.uprawnienia.Find(id);
            return View(uprawnieniaToEdit);
        }

        // POST: Uprawnienia/Edit/5
        [HttpPost]
        public ActionResult Edit(uprawnienia uprawnieniaToEdit)
        {
            var originalUprawnienia = _db.uprawnienia.Find(uprawnieniaToEdit.id);
            try
            {
                // TODO: Add update logic here
                if (TryUpdateModel(originalUprawnienia, new String[] { "nazwa", "opis"}))
                {
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(originalUprawnienia);
            }
        }

        // GET: Uprawnienia/Delete/5
        public ActionResult Delete(int id)
        {
            var uprawnieniaToDelete = _db.uprawnienia.Find(id);
            return View(uprawnieniaToDelete);
        }

        // POST: Uprawnienia/Delete/5
        [HttpPost]
        public ActionResult Delete(uprawnienia uprawnieniaToDelete)
        {
            try
            {
                var delUprawnienia = _db.uprawnienia.Find(uprawnieniaToDelete.id);
                if (!ModelState.IsValid)
                    return View(delUprawnienia);
                _db.uprawnienia.Remove(delUprawnienia);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(uprawnieniaToDelete);
            }
        }
    }
}