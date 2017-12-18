using GymXpress.Filters;
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
            using (IDal dal = new Dal()) {
                List<RendezVous> listeDesRDV = dal.ObtenirTousLesRDV();
                return View(listeDesRDV);
            }
        }

        // GET: RendezVous/Details/5
        public ActionResult Details(int id) {
            return View();
        }

        // GET:RendezVous/Create
        public ActionResult Create(int idDispo, string idClient) {
            List<Dispo> dispo;
            List<Compte> entraineur;
            using (IDal dal = new Dal())
                {
                 dispo = new List<Dispo>(dal.ObtenirToutesLesDispos().Where(d => d.IdDispo == idDispo));
                }
            using (IDal dal = new Dal())
            {
                entraineur = new List<Compte>(dal.ObtenirTousLesComptes().Where(c => c.IdCompte== dispo[0].IdEntraineur));
            }
            ViewBag.Dispo = dispo[0];
            ViewBag.Entraineur = entraineur[0];
            ViewBag.IdDispo = idDispo;
            ViewBag.IdClient = idClient;
            return View();
        }

        // POST: RendezVous/Create
        [HttpPost]

        public ActionResult Create(int idDispo, int idClient) {
            try {
                using (IDal dal = new Dal()) {
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
                using (IDal dal = new Dal()) {
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
            using (IDal dal = new Dal()) {
                RendezVous rdv = dal.ObtenirTousLesRDV().SingleOrDefault(r => r.IdRDV == id);
                if (rdv != null) {
                    dal.ModifierRDV(id, idDispo, idClient);
                    return RedirectToAction("Index");
                }
                return View();
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
                using (IDal dal = new Dal()) {
                    RendezVous rdv = dal.ObtenirTousLesRDV().SingleOrDefault(r => r.IdRDV == id);
                    if (rdv != null) {
                        dal.SupprimerRDV(id);
                        return RedirectToAction("Index");
                    }
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }





    }
}