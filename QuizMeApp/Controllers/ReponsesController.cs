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
    public class ReponsesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Reponses
        public ActionResult Index()
        {
            var reponses = db.Reponses.Include(r => r.Apprenant).Include(r => r.Question);
            return View(reponses.ToList());
        }

        // GET: Reponses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reponse reponse = db.Reponses.Find(id);
            if (reponse == null)
            {
                return HttpNotFound();
            }
            return View(reponse);
        }

        // GET: Reponses/Create
        public ActionResult Create()
        {
            ViewBag.ApprenantId = new SelectList(db.Apprenants, "ID", "nom");
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "enonce");
            return View();
        }

        // POST: Reponses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,choix,dateReponse,QuestionId,ApprenantId")] Reponse reponse)
        {
            if (ModelState.IsValid)
            {
                db.Reponses.Add(reponse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApprenantId = new SelectList(db.Apprenants, "ID", "nom", reponse.ApprenantId);
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "enonce", reponse.QuestionId);
            return View(reponse);
        }

        // GET: Reponses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reponse reponse = db.Reponses.Find(id);
            if (reponse == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApprenantId = new SelectList(db.Apprenants, "ID", "nom", reponse.ApprenantId);
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "enonce", reponse.QuestionId);
            return View(reponse);
        }

        // POST: Reponses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,choix,dateReponse,QuestionId,ApprenantId")] Reponse reponse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reponse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApprenantId = new SelectList(db.Apprenants, "ID", "nom", reponse.ApprenantId);
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "enonce", reponse.QuestionId);
            return View(reponse);
        }

        // GET: Reponses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Reponse reponse = db.Reponses.Find(id);
            if (reponse == null)
            {
                return HttpNotFound();
            }
            return View(reponse);
        }

        // POST: Reponses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Reponse reponse = db.Reponses.Find(id);
            db.Reponses.Remove(reponse);
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
