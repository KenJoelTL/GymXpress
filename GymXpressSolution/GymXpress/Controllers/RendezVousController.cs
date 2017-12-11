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
    public class RendezVousController : Controller {
        // GET: RendezVous
        [AuthorizationConnectionFilter]
        public ActionResult Index() {
            using (Idal dal = new Dal()) {
                List<RendezVous> listeDesRDV = dal.ObtenirTousLesRDV();
                return View(listeDesRDV);
            }
        }

        // GET: RendezVous/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET:RendezVous/Create
        public ActionResult Create() {
            return View();
        }

        // POST: RendezVous/Create
        [HttpPost]
        public ActionResult Create(int idDispo, int idClient) {
            try {
                using (Idal dal = new Dal()) {
                    dal.CreerRDV(idDispo, idClient);
                    return RedirectToAction("Index");
                }
            }
            catch {
                return View();
            }
        }

        public ActionResult Edit(int? id) {
            if (id.HasValue) {
                using (Idal dal = new Dal()) {
                    RendezVous rdv = dal.ObtenirTousLesRDV().FirstOrDefault(r => r.IdRDV == id.Value);
                    if (rdv == null)
                        return View("Error");
                    return View(rdv);
                }
            }
            else
                return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(int id, int idDispo, int idClient) {
            if (!ModelState.IsValid)
                return View();
            using (Idal dal = new Dal()) {
                dal.ModifierRDV(id, idDispo, idClient);
                return RedirectToAction("Index");
            }

        }

        // GET: RendezVous/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RendezVous/Delete/5
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