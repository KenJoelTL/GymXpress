using GymXpress.Filters;
using GymXpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GymXpress.Controllers {
    [HandleError, AuthorizationConnectionFilter]
    public class PlanController : Controller {
        // GET: Plan
        public ActionResult Index() {
            using (IDal dal = new Dal()) {
                IEnumerable<Plan> listeDesPlans;
                int role = (int)Session["role"];
                switch (role) {
                    case Compte.ENTRAINEUR:
                        listeDesPlans = dal.ObtenirTousLesPlans().Where(p => p.IdEntraineur == (int)Session["connecte"]);
                        break;
                    case Compte.ADMIN:
                        listeDesPlans = dal.ObtenirTousLesPlans();
                        break;
                    default:
                        listeDesPlans = dal.ObtenirTousLesPlans().Where(p => p.IdCompte == (int)Session["connecte"]);
                        break;
                }
                foreach (Plan item in listeDesPlans) {
                    item.Entraineur = dal.ObtenirTousLesComptes().FirstOrDefault(c => c.IdCompte == item.IdEntraineur);
                }

                return View(listeDesPlans);
            }

        }
        /*
        // GET: Plan/Details/5
        public ActionResult Details(int id) {
            using (IDal dal = new Dal()) {
                Plan plan = dal.ObtenirTousLesPlans().FirstOrDefault(p => p.IdPlan == id);

                if (plan != null) {
                    plan.Entraineur = dal.ObtenirTousLesComptes().FirstOrDefault(c => c.IdCompte == plan.IdEntraineur);
                    return View(plan);
                }
                else {
                    return RedirectToAction("Index");
                }
            }
        }*/

        // GET: Plan/Create
        [AutorisationEntraineurFilter]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plan/Create
        [HttpPost, AutorisationEntraineurFilter]
        public ActionResult Create(Plan plan) {
            try {
                using (IDal dal = new Dal()) {
                    dal.CreerPlan(plan.IdCompte, plan.IdEntraineur, plan.Nom, plan.Description);
                    return RedirectToAction("Index");
                }
            }
            catch {
                return View();
            }
        }

        // GET: Plan/Edit/5
        [AutorisationEntraineurFilter]
        public ActionResult Edit(int id)
        {
            using (IDal dal = new Dal()) {
                Plan plan = dal.ObtenirTousLesPlans().FirstOrDefault(p => p.IdPlan == id);
                if (plan != null) {
                    plan.Client = dal.ObtenirTousLesComptes().FirstOrDefault(c => c.IdCompte == plan.IdCompte);
                    plan.Entraineur = dal.ObtenirTousLesComptes().FirstOrDefault(c => c.IdCompte == plan.IdEntraineur);
                    ViewBag.Entraineurs = new SelectList(dal.ObtenirTousLesComptes().Where(c => c.Role == Compte.ENTRAINEUR),"IdCompte","Prenom");
                    return View(plan);
                }
                else {
                    return RedirectToAction("Index");
                }
            }
        }

        // POST: Plan/Edit/5
        [HttpPost, AutorisationEntraineurFilter]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                using (IDal dal = new Dal())
                {
                    Plan plan = dal.ObtenirTousLesPlans().FirstOrDefault(p => p.IdPlan == id);
                    Compte entraineur = dal.ObtenirTousLesComptes().FirstOrDefault(c => c.Courriel == Convert.ToString(collection["CourrielEntraineur"]));
                    Compte client = dal.ObtenirTousLesComptes().FirstOrDefault(c => c.Courriel == Convert.ToString(collection["CourrielClient"]));
                    if (plan == null)
                        return View("_Error");
                    else if (entraineur == null || client == null)
                        return View();
                    else {
                        dal.ModifierPlan(id, client.IdCompte, entraineur.IdCompte, Convert.ToString(collection["Nom"]), Convert.ToString(collection["Description"]));
                        return RedirectToAction("Index");
                    }
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Plan/Delete/5
        [AutorisationEntraineurFilter]
        public ActionResult Delete(int id)
        {
            using (IDal dal = new Dal()) {
                Plan plan = dal.ObtenirTousLesPlans().FirstOrDefault(p => p.IdPlan == id);
                if (plan != null) {
                    plan.Entraineur = dal.ObtenirTousLesComptes().FirstOrDefault(e => e.IdCompte == plan.IdEntraineur);
                    plan.Client = dal.ObtenirTousLesComptes().FirstOrDefault(u => u.IdCompte == plan.IdCompte);
                    return View(plan);
                }
                else {
                    return RedirectToAction("Index");
                }
            }
        }

        // POST: Plan/Delete/5
        [HttpPost, AutorisationEntraineurFilter]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (IDal dal = new Dal())
                {
                    Plan plan = dal.ObtenirTousLesPlans().FirstOrDefault(p => p.IdPlan == id);
                    if (plan != null) {
                        dal.SupprimerPlan(plan.IdPlan);
                        return RedirectToAction("Index");
                    }
                    else
                        return View("_Error");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
