﻿using System;
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
    public class CoursController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Cours
        public ActionResult Index()
        {
            var cours = db.Cours.Include(c => c.Enseignant);
            return View(cours.ToList());
        }

        // GET: Cours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = db.Cours.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

        // GET: Cours/Create
        public ActionResult Create()
        {
            ViewBag.EnseignantId = new SelectList(db.Enseignants, "ID", "nom");
            return View();
        }

        // POST: Cours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,intitule,date_creation,description,EnseignantId")] Cours cours)
        {
            if (ModelState.IsValid)
            {
                db.Cours.Add(cours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EnseignantId = new SelectList(db.Enseignants, "ID", "nom", cours.EnseignantId);
            return View(cours);
        }

        // GET: Cours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = db.Cours.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            ViewBag.EnseignantId = new SelectList(db.Enseignants, "ID", "nom", cours.EnseignantId);
            return View(cours);
        }

        // POST: Cours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,intitule,date_creation,description,EnseignantId")] Cours cours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EnseignantId = new SelectList(db.Enseignants, "ID", "nom", cours.EnseignantId);
            return View(cours);
        }

        // GET: Cours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cours cours = db.Cours.Find(id);
            if (cours == null)
            {
                return HttpNotFound();
            }
            return View(cours);
        }

        // POST: Cours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cours cours = db.Cours.Find(id);
            db.Cours.Remove(cours);
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
