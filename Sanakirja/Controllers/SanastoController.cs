using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sanakirja.Models;

namespace Sanakirja.Controllers
{
    public class SanastoController : Controller
    {
        // GET: Sanasto
        public ActionResult Index()
        {
            SanakirjaDBEntities db = new SanakirjaDBEntities();
            List<Sanasto> model = db.Sanasto.ToList();
            db.Dispose();
            return View(model);
        }
    }
}