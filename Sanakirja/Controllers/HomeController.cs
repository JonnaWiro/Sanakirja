using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Sanakirja.Models;
using PagedList;
using System.Drawing.Printing;
using System.Web.UI;

namespace Sanakirja.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? page, int? pagesize)
        {
            SanakirjaDBEntities db = new SanakirjaDBEntities();
            List<Sanasto> model = db.Sanasto.ToList();
            db.Dispose();
            int pageSize = (pagesize ?? 10);
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }

        //käsitellä hakukyselyä ja palauttaa tulokset
        public ActionResult Search(string searchTerm, string currentFilter1, int? page, int? pagesize)
        {
           
            //Hakufiltterin laitto muistiin
            if (searchTerm != null)
            {
                page = 1;
            }
            else
            {
                searchTerm = currentFilter1;
            }

            ViewBag.currentFilter1 = searchTerm;

            //Tietokantayhteys ja listan luonti
            SanakirjaDBEntities db = new SanakirjaDBEntities();
            List<Sanasto> results = new List<Sanasto>();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                // Hae hakutermin perusteella
                results = db.Sanasto
                            .Where(s => s.SuomiTermi.StartsWith(searchTerm) || s.EnglantiTermi.StartsWith(searchTerm))
                            .ToList();
            }
            else
            {
                results = db.Sanasto.ToList();
            }
         //  ViewBag.SearchTerm = searchTerm;
  
            db.Dispose();
            int pageSize = (pagesize ?? 10);
            int pageNumber = (page ?? 1);
            return View("Index", results.ToPagedList(pageNumber, pageSize));
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