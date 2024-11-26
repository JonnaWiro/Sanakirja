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
            SanakirjaDBEntities db = new SanakirjaDBEntities();
            return View();
        }
    }
}