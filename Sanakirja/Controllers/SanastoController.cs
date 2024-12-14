using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Sanakirja.Models;

namespace Sanakirja.Controllers
{
    public class SanastoController : Controller
    {
        SanakirjaDBEntities db = new SanakirjaDBEntities();
        // GET: Sanasto
        public ActionResult Index()
        {
            List<Sanasto> model = db.Sanasto.ToList();
            return View(model);
        }

        // GET: Sanasto/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sanasto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sanasto model)
        {
            if (ModelState.IsValid)
            {
                db.Sanasto.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Sanasto/Edit/5
        public ActionResult Update(int? id)
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

        // POST: Sanasto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Sanasto model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: Sanasto/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Sanasto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sanasto model = db.Sanasto.Find(id);
            db.Sanasto.Remove(model);
            db.SaveChanges();
            return RedirectToAction("Index");
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