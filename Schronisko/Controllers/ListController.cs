using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schronisko.Controllers
{
    public class ListController : Controller
    {
        private SchroniskoBazaEntities _db = new SchroniskoBazaEntities();
        // GET: List
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
            {
                var userId = ((uzytkownik)Session["user"]).id;

                var pendingRecords = _db.historia_adopcji.Where(x => x.Pracownik_id == 3).Where(x => x.Uzytkownik_id == userId);
                var pendingId = (from v in pendingRecords select v.Zwierze_id);
                var animals = (from a in _db.zwierze where pendingId.Contains(a.id) select a).ToArray();
                ViewBag.PendingAnimals = animals;

                var acceptedRecords = _db.historia_adopcji.Where(x => x.Pracownik_id != 3).Where(x => x.Uzytkownik_id == userId);
                var acceptedId = (from v in acceptedRecords select v.Zwierze_id);
                var animals2 = (from a in _db.zwierze where acceptedId.Contains(a.id) select a).ToArray();
                ViewBag.AcceptedAnimals = animals2;

                return View();
            }
                
        }





    }
}
