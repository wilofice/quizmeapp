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
    public class ScoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Scores
        public ActionResult Index()
        {
            var scores = db.Scores.Include(s => s.Apprenant).Include(s => s.Evaluation);
            return View(scores.ToList());
        }

        // GET: Scores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = db.Scores.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
        }

        // GET: Scores/Create
        public ActionResult Create()
        {
            ViewBag.ApprenantId = new SelectList(db.Apprenants, "ID", "nom");
            ViewBag.EvaluationId = new SelectList(db.Evaluations, "Id", "date_creation");
            return View();
        }

        // POST: Scores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,score,EvaluationId,ApprenantId")] Score score)
        {
            if (ModelState.IsValid)
            {
                db.Scores.Add(score);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApprenantId = new SelectList(db.Apprenants, "ID", "nom", score.ApprenantId);
            ViewBag.EvaluationId = new SelectList(db.Evaluations, "Id", "date_creation", score.EvaluationId);
            return View(score);
        }

        // GET: Scores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = db.Scores.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApprenantId = new SelectList(db.Apprenants, "ID", "nom", score.ApprenantId);
            ViewBag.EvaluationId = new SelectList(db.Evaluations, "Id", "date_creation", score.EvaluationId);
            return View(score);
        }

        // POST: Scores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,score,EvaluationId,ApprenantId")] Score score)
        {
            if (ModelState.IsValid)
            {
                db.Entry(score).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApprenantId = new SelectList(db.Apprenants, "ID", "nom", score.ApprenantId);
            ViewBag.EvaluationId = new SelectList(db.Evaluations, "Id", "date_creation", score.EvaluationId);
            return View(score);
        }

        // GET: Scores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Score score = db.Scores.Find(id);
            if (score == null)
            {
                return HttpNotFound();
            }
            return View(score);
        }

        // POST: Scores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Score score = db.Scores.Find(id);
            db.Scores.Remove(score);
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
