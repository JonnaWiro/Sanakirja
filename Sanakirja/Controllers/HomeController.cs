using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sanakirja.Models;

namespace Sanakirja.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SanakirjaDBEntities db = new SanakirjaDBEntities();
            List<Sanasto> model = db.Sanasto.ToList();
            db.Dispose();
            return View(model);
        }

        //käsitellä hakukyselyä ja palauttaa tulokset
        public ActionResult Search(string searchTerm)
        {
            SanakirjaDBEntities db = new SanakirjaDBEntities();
            List<Sanasto> results = new List<Sanasto>();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Hae jopa 10 tulosta hakutermin perusteella
                results = db.Sanasto
                            .Where(s => s.SuomiTermi.StartsWith(searchTerm) || s.EnglantiTermi.StartsWith(searchTerm))
                            .Take(10)
                            .ToList();
            }
            else
            {
                results = db.Sanasto.ToList();
            }
            ViewBag.SearchTerm = searchTerm;
            db.Dispose();
            return View("Index",results);
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
    }
}