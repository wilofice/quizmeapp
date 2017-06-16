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
    public class ApprenantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Apprenants
        public ActionResult Index()
        {
            return View(db.Apprenants.ToList());
        }

        // GET: Apprenants/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apprenant apprenant = db.Apprenants.Find(id);
            if (apprenant == null)
            {
                return HttpNotFound();
            }
            return View(apprenant);
        }

        // GET: Apprenants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Apprenants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,nom,prenom")] Apprenant apprenant)
        {
            if (ModelState.IsValid)
            {
                db.Apprenants.Add(apprenant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(apprenant);
        }

        // GET: Apprenants/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apprenant apprenant = db.Apprenants.Find(id);
            if (apprenant == null)
            {
                return HttpNotFound();
            }
            return View(apprenant);
        }

        // POST: Apprenants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,nom,prenom")] Apprenant apprenant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(apprenant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(apprenant);
        }

        // GET: Apprenants/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Apprenant apprenant = db.Apprenants.Find(id);
            if (apprenant == null)
            {
                return HttpNotFound();
            }
            return View(apprenant);
        }

        // POST: Apprenants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Apprenant apprenant = db.Apprenants.Find(id);
            db.Apprenants.Remove(apprenant);
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
