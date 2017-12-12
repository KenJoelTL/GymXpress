using GymXpress.App_Start;
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
                List<Plan> listeDesPlans = dal.ObtenirTousLesPlans();
                return View(listeDesPlans);
            }
            
        }

        // GET: Plan/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

                    dal.CreerPlan(plan.IdCompte, plan.IdEntraineur, plan.Nom);
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
            return View();
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
                            Convert.ToInt32(collection["IdEntraineur"]), Convert.ToString(collection["Nom"]));
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
            return View();
        }

        // POST: Plan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (IDal dal = new Dal())
                {
                    Plan plan= dal.ObtenirTousLesPlans().FirstOrDefault(p => p.IdPlan == id);
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
