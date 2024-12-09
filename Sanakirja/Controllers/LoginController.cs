using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sanakirja.Models;

namespace Sanakirja.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(Login LoginModel)
        {
            SanakirjaDBEntities db = new SanakirjaDBEntities();

            var LoggedUser = db.Login.SingleOrDefault(x => x.Kayttajatunnus == LoginModel.Kayttajatunnus && x.Salasana == LoginModel.Salasana);
            if (LoggedUser != null)
            {
                Session["Kayttajatunnus"] = LoggedUser.Kayttajatunnus;
                return RedirectToAction("Index", "Sanasto");
            }
            else
            {
                LoginModel.LoginErrorMessage = "Tuntematon käyttäjätunnus tai salasana.";
                return View("Index", LoginModel);
            }
        }
        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("LoggedOut"); 
        }
        public ActionResult LoggedOut()
        {
            ViewBag.LoggedOutMessage = "Olet kirjautunut ulos järjestelmästä.";
            return View("Index");
        }
    }
}
