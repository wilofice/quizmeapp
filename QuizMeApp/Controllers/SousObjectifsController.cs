using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuizMeApp.Models;

namespace QuizMeApp.Controllers
{
    public class SousObjectifsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SousObjectifs
        public ActionResult Index()
        {
            var sousObjectifs = db.SousObjectifs.Include(s => s.Objectif);
            return View(sousObjectifs.ToList());
        }

        // GET: SousObjectifs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SousObjectif sousObjectif = db.SousObjectifs.Find(id);
            if (sousObjectif == null)
            {
                return HttpNotFound();
            }
            return View(sousObjectif);
        }

        // GET: SousObjectifs/Create
        public ActionResult Create()
        {
            ViewBag.ObjectifId = new SelectList(db.Objectifs, "Id", "intitule");
            return View();
        }

        // POST: SousObjectifs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,intitule,ObjectifId")] SousObjectif sousObjectif)
        {
            if (ModelState.IsValid)
            {
                db.SousObjectifs.Add(sousObjectif);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ObjectifId = new SelectList(db.Objectifs, "Id", "intitule", sousObjectif.ObjectifId);
            return View(sousObjectif);
        }

        // GET: SousObjectifs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SousObjectif sousObjectif = db.SousObjectifs.Find(id);
            if (sousObjectif == null)
            {
                return HttpNotFound();
            }
            ViewBag.ObjectifId = new SelectList(db.Objectifs, "Id", "intitule", sousObjectif.ObjectifId);
            return View(sousObjectif);
        }

        // POST: SousObjectifs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,intitule,ObjectifId")] SousObjectif sousObjectif)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sousObjectif).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ObjectifId = new SelectList(db.Objectifs, "Id", "intitule", sousObjectif.ObjectifId);
            return View(sousObjectif);
        }

        // GET: SousObjectifs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SousObjectif sousObjectif = db.SousObjectifs.Find(id);
            if (sousObjectif == null)
            {
                return HttpNotFound();
            }
            return View(sousObjectif);
        }

        // POST: SousObjectifs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SousObjectif sousObjectif = db.SousObjectifs.Find(id);
            db.SousObjectifs.Remove(sousObjectif);
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
