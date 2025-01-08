using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Sanakirja.Models;
using PagedList;
using System.Drawing.Printing;
using System.Web.UI;

namespace Sanakirja.Controllers
{
    public class SanastoController : Controller
    {
        SanakirjaDBEntities db = new SanakirjaDBEntities();

        // GET: Sanasto
        public ActionResult Index(string searchTerm, string currentFilter1, int? page, int? pagesize)
        {
            if (Session["Kayttajatunnus"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
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

                db.Dispose();
                int pageSize = (pagesize ?? 10);
                int pageNumber = (page ?? 1);
                return View(results.ToPagedList(pageNumber, pageSize));
            }
        }

        public ActionResult Search(string searchTerm, string currentFilter1, int? page, int? pagesize)
        {
            if (Session["Kayttajatunnus"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (!string.IsNullOrEmpty(searchTerm))
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
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }

        // GET: Sanasto/Create
        public ActionResult Create()
        {
            if (Session["Kayttajatunnus"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }

        // POST: Sanasto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sanasto model)
        {
            if (Session["Kayttajatunnus"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Sanasto.Add(model);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(model);
            }
        }

        // GET: Sanasto/Edit/5
        public ActionResult Update(int? id)
        {
            if (Session["Kayttajatunnus"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Sanasto model = db.Sanasto.Find(id);
                if (model == null)
                {
                    return HttpNotFound();
                }
                return View(model);
            }
        }

        // POST: Sanasto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Sanasto model)
        {
            if (Session["Kayttajatunnus"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(model);
            }
        }

        // GET: Sanasto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["Kayttajatunnus"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                Sanasto model = db.Sanasto.Find(id);
                if (model == null)
                {
                    return HttpNotFound();
                }
                return View(model);
            }
        }

        // POST: Sanasto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["Kayttajatunnus"] == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                Sanasto model = db.Sanasto.Find(id);
                db.Sanasto.Remove(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}