using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Schronisko.Controllers
{
    public class HomeController : Controller
    {
        SchroniskoBazaEntities _db = new SchroniskoBazaEntities();
        public ActionResult Index()
        {
          if(Session["user"] != null)
            {
                
                ViewBag.user = ((uzytkownik)Session["user"]).imie;

            }
            ViewBag.zwierzeta = _db.zwierze.Where(x => x.status.Contains("0")).Take(9).ToArray();
            ViewBag.koty = _db.zwierze.Where(x => x.gatunek.Contains("kot") && x.status.Contains("0")).ToArray();
            ViewBag.psy = _db.zwierze.Where(x => x.gatunek.Contains("pies") && x.status.Contains("0")).ToArray();
            ViewBag.piesCounter = _db.zwierze.Where(x => x.gatunek.Contains("pies") && x.status.Contains("0")).Count();
            ViewBag.kotCounter = _db.zwierze.Where(x => x.gatunek.Contains("kot") && x.status.Contains("0")).Count();
            ViewBag.adopcjaCounter = _db.zwierze.Where(x => x.status.Contains("1")).Count();
            return View();
        }
        [HttpPost]
        public ActionResult Index(konto_info credentials)
        {
             
            konto_info userCred = _db.konto_info.SingleOrDefault(x => x.login == credentials.login && x.haslo == credentials.haslo);
            

            if(userCred != null)
            {
                uzytkownik userInfo = _db.uzytkownik.SingleOrDefault(x => x.Konto_Info_id == userCred.id);
                
                Session["user"] = userInfo;
                Session["user_cred"] = userCred;

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Bad credentails";
                return View();
            }
            
    }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Logout()
        {
            Session["user"] = null;
            Session["user_cred"] = null;
            return RedirectToAction(nameof(Index));

        }
    }
}