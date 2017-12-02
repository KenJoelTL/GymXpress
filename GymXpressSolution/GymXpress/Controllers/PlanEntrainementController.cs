using GymXpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymXpress.Controllers
{
    public class PlanEntrainementController : Controller
    {
        // GET: PlanEntrainement
        public ActionResult Index()
        {
            using (Idal dal = new Dal()) {
                List<PlanEntrainement> listeDesPlans = dal.ObtenirTousLesPlanEntrainements();
                return View(listeDesPlans);
            }
            
        }

        // GET: PlanEntrainement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PlanEntrainement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlanEntrainement/Create
        [HttpPost]
        public ActionResult Create(PlanEntrainement planEntrainement)
        {
            try
            {
                using (Idal dal = new Dal()) {

                    dal.CreerPlanEntrainement(planEntrainement.IdCompte, planEntrainement.IdEntraineur, planEntrainement.Nom);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: PlanEntrainement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PlanEntrainement/Edit/5
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

        // GET: PlanEntrainement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PlanEntrainement/Delete/5
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
