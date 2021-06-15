using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schronisko.Controllers
{
    public class StanowiskoController : Controller
    {
        private SchroniskoBazaEntities _db = new SchroniskoBazaEntities();
        // GET: Stanowisko
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
                return View(_db.stanowisko.ToList());
        }

        // GET: Stanowisko/Details/5
        public ActionResult Details(int id)
        {
            var stanowiskoToDisplay = _db.stanowisko.Find(id);
            return View(stanowiskoToDisplay);
        }

        // GET: Stanowisko/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stanowisko/Create
        [HttpPost]
        public ActionResult Create(stanowisko newStanowisko)
        {
            try
            {
                // TODO: Add insert logic here
                _db.stanowisko.Add(newStanowisko);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(newStanowisko);
            }
        }

        // GET: Stanowisko/Edit/5
        public ActionResult Edit(int id)
        {
            var stanowiskoToEdit = _db.stanowisko.Find(id);
            return View(stanowiskoToEdit);
        }

        // POST: Stanowisko/Edit/5
        [HttpPost]
        public ActionResult Edit(stanowisko stanowiskoToEdit)
        {
            var originalStanowisko = _db.stanowisko.Find(stanowiskoToEdit.id);
            try
            {
                // TODO: Add update logic here
                if (TryUpdateModel(originalStanowisko, new String[] { "nazwa", "opis", "placa" }))
                {
                    _db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View(originalStanowisko);
            }
        }

        // GET: Stanowisko/Delete/5
        public ActionResult Delete(int id)
        {
            var stanowiskoToDelete = _db.stanowisko.Find(id);
            return View(stanowiskoToDelete);
        }

        // POST: Stanowisko/Delete/5
        [HttpPost]
        public ActionResult Delete(stanowisko stanowiskoToDelete)
        {
            try
            {
                var delStanowisko = _db.stanowisko.Find(stanowiskoToDelete.id);
                if (!ModelState.IsValid)
                    return View(delStanowisko);
                _db.stanowisko.Remove(delStanowisko);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(stanowiskoToDelete);
            }
        }
    }
}
