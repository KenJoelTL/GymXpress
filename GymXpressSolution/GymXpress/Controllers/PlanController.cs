using GymXpress.Filter;
using GymXpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymXpress.Controllers
{
    [HandleError, AuthorizationConnectionFilter]
    public class PlanController : Controller
    {
        // GET: Plan
        public ActionResult Index()
        {
            using (IDal dal = new Dal()) {
                IEnumerable<Plan> listeDesPlans;
                int role = (int)Session["role"];
                switch (role) {
                    case 1:
                        listeDesPlans = dal.ObtenirTousLesPlans().Where(p => p.IdEntraineur == (int)Session["connecte"]);
                        break;
                    case 2:
                        listeDesPlans = dal.ObtenirTousLesPlans();
                        break;
                    default:
                        listeDesPlans = dal.ObtenirTousLesPlans().Where(p => p.IdCompte == (int)Session["connecte"]);
                        break;
                }
                return View(listeDesPlans);
            }
            
        }

        // GET: Plan/Details/5
        public ActionResult Details(int id)
        {
            using (IDal dal = new Dal()) {
                Plan plan = dal.ObtenirTousLesPlans().FirstOrDefault(p => p.IdPlan == id);
                if (plan != null) {
                    return View(plan);
                }
                else {
                    return RedirectToAction("Index");
                }
            }
        }

        // GET: Plan/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plan/Create
        [HttpPost]
        public ActionResult Create(Plan plan)
        {
            try
            {
                using (IDal dal = new Dal()) {

                    dal.CreerPlan(plan.IdCompte, plan.IdEntraineur, plan.Nom, plan.Description);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Plan/Edit/5
        public ActionResult Edit(int id)
        {
            using (IDal dal = new Dal()) {
                Plan plan = dal.ObtenirTousLesPlans().FirstOrDefault(p => p.IdPlan == id);
                if (plan != null) {
                    return View(plan);
                }
                else {
                    return RedirectToAction("Index");
                }
            }
        }

        // POST: Plan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                using (IDal dal = new Dal())
                {
                    Plan plan = dal.ObtenirTousLesPlans().FirstOrDefault(p => p.IdPlan == id);
                    if (plan == null)
                        return View("Error");
                    else {
                        dal.ModifierPlan(id, Convert.ToInt32(collection["IdCompte"]),
                            Convert.ToInt32(collection["IdEntraineur"]), Convert.ToString(collection["Nom"]), Convert.ToString(collection["Description"]));
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
        public ActionResult Delete(int id)
        {
            using (IDal dal = new Dal()) {
                Plan plan = dal.ObtenirTousLesPlans().FirstOrDefault(p => p.IdPlan == id);
                if (plan != null) {
                  return View(plan);
                }
                else {
                    return RedirectToAction("Index");
                }
            }
        }

        // POST: Plan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (IDal dal = new Dal())
                {
                    Plan plan = dal.ObtenirTousLesPlans().FirstOrDefault(p => p.IdPlan == id);
                    if (plan == null)
                        return View("Error");
                    else
                        dal.SupprimerPlan(plan.IdPlan);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
