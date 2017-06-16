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
    public class ObjectifsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Objectifs
        public ActionResult Index()
        {
            var objectifs = db.Objectifs.Include(o => o.Cours);
            return View(objectifs.ToList());
        }

        // GET: Objectifs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objectif objectif = db.Objectifs.Find(id);
            if (objectif == null)
            {
                return HttpNotFound();
            }
            return View(objectif);
        }

        // GET: Objectifs/Create
        public ActionResult Create()
        {
            ViewBag.CoursId = new SelectList(db.Cours, "Id", "intitule");
            return View();
        }

        // POST: Objectifs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,intitule,CoursId")] Objectif objectif)
        {
            if (ModelState.IsValid)
            {
                db.Objectifs.Add(objectif);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CoursId = new SelectList(db.Cours, "Id", "intitule", objectif.CoursId);
            return View(objectif);
        }

        // GET: Objectifs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objectif objectif = db.Objectifs.Find(id);
            if (objectif == null)
            {
                return HttpNotFound();
            }
            ViewBag.CoursId = new SelectList(db.Cours, "Id", "intitule", objectif.CoursId);
            return View(objectif);
        }

        // POST: Objectifs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,intitule,CoursId")] Objectif objectif)
        {
            if (ModelState.IsValid)
            {
                db.Entry(objectif).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CoursId = new SelectList(db.Cours, "Id", "intitule", objectif.CoursId);
            return View(objectif);
        }

        // GET: Objectifs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Objectif objectif = db.Objectifs.Find(id);
            if (objectif == null)
            {
                return HttpNotFound();
            }
            return View(objectif);
        }

        // POST: Objectifs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Objectif objectif = db.Objectifs.Find(id);
            db.Objectifs.Remove(objectif);
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
