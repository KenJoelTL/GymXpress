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
    public class DispoController : Controller
    {
        // GET: Dispo
        public ActionResult Index()
        {
            using (Idal dal = new Dal())
            {
                List<Dispo> listeDesDispos = dal.ObtenirToutesLesDispos();
                return View(listeDesDispos);
            }
        }

        // GET: Dispo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dispo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dispo/Create
        [HttpPost]
        public ActionResult Create(int idEntraineur, string heureDebut, string heureFin, string date)
        {
            try
            {
                using (Idal dal = new Dal())
                {
                    dal.CreerDispo(idEntraineur, heureDebut, heureFin, date);
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                using (Idal dal = new Dal())
                {
                    Dispo dispo = dal.ObtenirToutesLesDispos().FirstOrDefault(d=>d.IdDispo== id.Value);
                    if (dispo == null)
                        return View("Error");
                    return View(dispo);
                }
            }
            else
                return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(int id, int idEntraineur, string heureDebut, string heureFin, string date)
        {
            if (!ModelState.IsValid)
                return View();
            using (Idal dal = new Dal())
            {
                dal.ModifierDispo(id, idEntraineur, heureDebut, heureFin, date);
                return RedirectToAction("Index");
            }

        }

        // GET: Dispo/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Dispo/Delete/5
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

        public JsonResult ListeDispoParDate(int Id, String date)
        {
            using (Idal dal = new Dal())
            {
                List<Dispo> listeDispo = new List<Dispo>(dal.ObtenirToutesLesDispos().Where(d => d.Date == date).Where(d => d.IdEntraineur == Id));
                return Json(listeDispo);
            }
        }
    }
}
