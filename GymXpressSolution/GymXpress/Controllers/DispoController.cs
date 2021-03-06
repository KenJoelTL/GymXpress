﻿using GymXpress.Filters;
using GymXpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymXpress.Controllers
{
    [AuthorizationConnectionFilter]
    public class DispoController : Controller
    {
        // GET: Dispo
        public ActionResult Index()
        {
            using (IDal dal = new Dal())
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
        public ActionResult Create(string heureDebut, string heureFin, string date)
        {
            try
            {
                using (IDal dal = new Dal())
                {
                    dal.CreerDispo((int)HttpContext.Session["connecte"], heureDebut, heureFin, date);
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
                using (IDal dal = new Dal())
                {
                    Dispo dispo = dal.ObtenirToutesLesDispos().FirstOrDefault(d=>d.IdDispo== id.Value);
                    if (dispo == null)
                        return View("_Error");
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
            using (IDal dal = new Dal())
            {
                Dispo dispo = dal.ObtenirToutesLesDispos().SingleOrDefault(d => d.IdDispo == id);
                if(dispo != null) {
                    dal.ModifierDispo(id, idEntraineur, heureDebut, heureFin, date);
                    return RedirectToAction("Index");
                }
                return View();
            }

        }

        // GET: Dispo/Delete/5
        public ActionResult Delete(int id)
        {
            using (IDal dal = new Dal())
            {
                Dispo dispo = dal.ObtenirToutesLesDispos().SingleOrDefault(d => d.IdDispo == id);
                    
            return View(dispo);
            }
        }

        // POST: Dispo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (IDal dal = new Dal()) {
                    Dispo dispo = dal.ObtenirToutesLesDispos().SingleOrDefault(d => d.IdDispo == id);
                    if (dispo != null) {
                        dal.SupprimerDispo(id);
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

        public JsonResult ListeDispoParDate(int Id, String date)
        {
            using (IDal dal = new Dal())
            {
                List<Dispo> listeDispo = new List<Dispo>(dal.ObtenirToutesLesDispos().Where(d => d.Date == date).Where(d => d.IdEntraineur == Id).OrderBy(d => d.HeureDebut));
                foreach (Dispo item in listeDispo)
                {
                    item.Entraineur = dal.ObtenirTousLesComptes().FirstOrDefault(d => d.IdCompte == item.IdEntraineur);
                }
                return Json(listeDispo);
            }
        }
        public JsonResult ListeDispoPourClient(String date)
        {
            using (IDal dal = new Dal())
            {
                List<Dispo> listeDispo = new List<Dispo>(dal.ObtenirToutesLesDispos().Where(d => d.Date == date).OrderBy(d => d.HeureDebut));
                foreach (Dispo item in listeDispo)
                {
                    item.Entraineur = dal.ObtenirTousLesComptes().FirstOrDefault(d => d.IdCompte == item.IdEntraineur);
                }
                return Json(listeDispo);
            }
        }
    }
}
