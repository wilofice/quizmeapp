using QuizMeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;

namespace QuizMeApp.Controllers
{
    public class PasserEvaluationController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: PasserEvaluation
        public ActionResult Index()
        {
            var evaluations = db.Evaluations.Include(e => e.Enseignant);
            return View(evaluations.ToList());
        }

        public ActionResult LancerEvaluation(int evaluationId)
        {
            var question = db.Questions.Where(rq => rq.EvaluationId == evaluationId).First();

            return View(question);
        }

        [HttpPost]
        public ActionResult VerifierReponse(string questionId, string intitule)
        {
            int question = Int32.Parse(questionId);
            Question q = db.Questions.Where(qre => qre.Id == question).Single();
            Option juste = null;
            foreach (Option op in q.Options)
            {
                if(op.is_correct == true) { juste = op; }
            }

            if(juste.intitule.Equals(intitule))
            {
                ViewBag.verdict = "Bonne reponse! Cliquez sur suivant pour passer à la prochaine question";
            } else
            {
                ViewBag.verdict = "Mauvaise reponse! La bonne reponse était : " + juste.intitule;
            }
            return View("Resultat", q);
        }


        public ActionResult Suivant(int lastquestion)
        {
            var question = db.Questions.Where(rq => rq.Id == lastquestion).Single();
            string userId = (string) Session["userId"];

            var old_questions = db.Reponses.Include(rp => rp.Apprenant && )

            return View(question);
        }




















        // GET: PasserEvaluation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PasserEvaluation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PasserEvaluation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PasserEvaluation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PasserEvaluation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: PasserEvaluation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PasserEvaluation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
