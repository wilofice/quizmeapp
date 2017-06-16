using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizMeApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Acceuil(string categorie)
        {
            if (categorie.Equals("Enseignant"))
            {
                //return View("HomeEnseignant");
                return RedirectToAction("Index", "Cours");
            }
            //return RedirectToAction("Index", "Evaluations");
            return View("HomeEtudiant");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}