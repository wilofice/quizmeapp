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
    public class CertificatsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Certificats
        public ActionResult Index()
        {
            var certificats = db.Certificats.Include(c => c.Evaluation);
            return View(certificats.ToList());
        }

        // GET: Certificats/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certificat certificat = db.Certificats.Find(id);
            if (certificat == null)
            {
                return HttpNotFound();
            }
            return View(certificat);
        }

        // GET: Certificats/Create
        public ActionResult Create()
        {
            ViewBag.EvaluationId = new SelectList(db.Evaluations, "Id", "date_creation");
            return View();
        }

        // POST: Certificats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,description,EvaluationId")] Certificat certificat)
        {
            if (ModelState.IsValid)
            {
                db.Certificats.Add(certificat);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EvaluationId = new SelectList(db.Evaluations, "Id", "date_creation", certificat.EvaluationId);
            return View(certificat);
        }

        // GET: Certificats/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certificat certificat = db.Certificats.Find(id);
            if (certificat == null)
            {
                return HttpNotFound();
            }
            ViewBag.EvaluationId = new SelectList(db.Evaluations, "Id", "date_creation", certificat.EvaluationId);
            return View(certificat);
        }

        // POST: Certificats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,description,EvaluationId")] Certificat certificat)
        {
            if (ModelState.IsValid)
            {
                db.Entry(certificat).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EvaluationId = new SelectList(db.Evaluations, "Id", "date_creation", certificat.EvaluationId);
            return View(certificat);
        }

        // GET: Certificats/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Certificat certificat = db.Certificats.Find(id);
            if (certificat == null)
            {
                return HttpNotFound();
            }
            return View(certificat);
        }

        // POST: Certificats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Certificat certificat = db.Certificats.Find(id);
            db.Certificats.Remove(certificat);
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
