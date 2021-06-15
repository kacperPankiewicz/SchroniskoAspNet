using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schronisko.Controllers
{
    public class RequestConfController : Controller
    {
        // GET: RequestConf
        private SchroniskoBazaEntities _db = new SchroniskoBazaEntities();
      
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
                var requests = _db.historia_adopcji.Where(x => x.Pracownik_id == 3);
                return View(requests);
            }
        }
        public ActionResult AcceptRequest(int id)
        {
            var userId = ((uzytkownik)Session["user"]).id;
            var pracId = _db.pracownik.SingleOrDefault(x => x.Uzytkownik_Info_id == userId).id;
            var rowToEdit = _db.historia_adopcji.Find(id);
            rowToEdit.Pracownik_id = pracId;
            _db.zwierze.Find(rowToEdit.Zwierze_id).status = "1";
            if (TryUpdateModel(rowToEdit))
            {
                _db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public ActionResult DeclineRequest(int id)
        {
            var rowToDelete = _db.historia_adopcji.Find(id);

            _db.historia_adopcji.Remove(rowToDelete);
            _db.SaveChanges();


            return RedirectToAction("Index");
        }



    }
}
