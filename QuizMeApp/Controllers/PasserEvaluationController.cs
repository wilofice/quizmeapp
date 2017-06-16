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
            string userId = (string)Session["userId"];
            Apprenant app = db.Apprenants.Where(ap => ap.ID == userId).Single();

            Evaluation eva = db.Evaluations.Where(evv => evv.Id == evaluationId).Single();

            Score score = new Score();

            score.score = 0;
            score.EvaluationId = evaluationId;
            score.Evaluation = eva;
            score.Apprenant = app;
            score.ApprenantId = userId;

            db.Scores.Add(score);

            db.SaveChanges();
            var question = db.Questions.Where(rq => rq.EvaluationId == evaluationId).First();

            return View(question);
        }

        [HttpPost]
        public ActionResult VerifierReponse(string questionId, string intitule)
        {
            int question = Int32.Parse(questionId);
            Question q = db.Questions.Where(qre => qre.Id == question).Single();
            string userId = (string)Session["userId"];

            Apprenant app = db.Apprenants.Where(ap => ap.ID == userId).Single();

            DateTime d = DateTime.Now;
            string day = d.Day + "";
            string month = d.Month + "";
            string yeah = d.Year + "";
            string date = day + "/" + month + "/" + yeah;

            Reponse rep = new Reponse();
            
            rep.ApprenantId = userId;
            rep.Apprenant = app;
            rep.choix = intitule;
            rep.dateReponse = date;
            rep.QuestionId = question;
            rep.Question = q;

            db.Reponses.Add(rep);
            db.SaveChanges();
            

            
            Option juste = null;

            foreach (Option op in q.Options)
            {
                if(op.is_correct == true) { juste = op; }
            }

            if(juste.intitule.Equals(intitule))
            {
                ViewBag.verdict = "Bonne reponse! Cliquez sur suivant pour passer à la prochaine question";
                Score score = db.Scores.Where(sc => sc.EvaluationId == q.EvaluationId && sc.ApprenantId == userId).Single();
                score.score += q.point;
                db.Entry(score).State = EntityState.Modified;
                db.SaveChanges();
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

            List<Reponse> old_questions = db.Reponses.Include(rp => rp.Apprenant).Where(rp => rp.Question.EvaluationId == question.EvaluationId && rp.ApprenantId == userId).ToList();

            List<Question> total_question = db.Questions.Where(qp => qp.EvaluationId == question.EvaluationId).ToList();

            List<Question> questions_restant = new List<Question>();

            bool test = false;
            foreach(Question q in total_question)
            {
                foreach(Reponse m in old_questions)
                {
                    if (q.Id == m.QuestionId)
                    {
                        test = true;
                        break;
                    }

                }

                if (test == true)
                {
                    test = false;
                    continue;
                }

                questions_restant.Add(q);
            }
            if(questions_restant.Count() == 0)
            {
                
                Evaluation eva = db.Evaluations.Where(evv => evv.Id == question.EvaluationId).Single();
                Score score = db.Scores.Where(sc => sc.EvaluationId == question.EvaluationId && sc.ApprenantId == userId).Single();

                List<Reponse> list_rep = db.Reponses.Where(repp => repp.ApprenantId == userId && repp.Question.EvaluationId == eva.Id).ToList();
                foreach(Reponse x in list_rep)
                {
                    db.Reponses.Remove(x);
                }

                db.SaveChanges();

                if (score.score >= eva.scoreSuccess) ViewBag.resultat_final = "Tres bien. Vous avez reussi l'evaluation! Votre score est : " + score.score;
                else ViewBag.resultat_final = "Mauvais! Vous devez encore vous améliorer! Votre score est : " + score.score;

                return View("FinEvaluation");
            }

            Question question_to_send = questions_restant.First();

            return View("LancerEvaluation", question_to_send);
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
