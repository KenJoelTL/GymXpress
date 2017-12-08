using GymXpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymXpress.Controllers
{
    public class CompteController : Controller
    {
        // GET: Compte
        public ActionResult Index()
        {
            using (Idal dal = new Dal())
            {
                List<Compte> listeDesComptes = dal.ObtenirTousLesComptes();
                return View(listeDesComptes);
            }
        }

        // GET: Compte/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Compte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compte/Create
        [HttpPost]
        public ActionResult Create(int role, string courriel, string motPasse)
        {
            try
            {
                using (Idal dal = new Dal())
                {

                    dal.CreerCompte(role, courriel, motPasse);
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
                    Compte compte = dal.ObtenirTousLesComptes().FirstOrDefault(c => c.IdCompte == id.Value);
                    if (compte == null)
                        return View("Error");
                    return View(compte);
                }
            }
            else
                return HttpNotFound();
        }

        [HttpPost]
        public ActionResult Edit(int id, int role, string courriel, string motPasse)
        {
            if (!ModelState.IsValid)
                return View();
            using (Idal dal = new Dal())
            {
                dal.ModifierCompte(id, role, courriel, motPasse);
                return RedirectToAction("Index");
            }

        }

        // GET: Compte/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Compte/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (Idal dal = new Dal())
                {
                    dal.SupprimerCompte(id);
                    return RedirectToAction("Index");
                }

            }
            catch
            {
                return View();
            }
        }
        
        // GET: Login
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost, AllowAnonymous]
        public ActionResult Login(string courriel, string motPasse)
        {
            try
            {
                // TODO: Add delete logic here
                using (Idal dal = new Dal())
                {
                    
                    Compte compte = dal.ObtenirTousLesComptes().FirstOrDefault(c => c.Courriel == courriel && c.MotPasse == motPasse);
                    if (compte == null) {
                        return RedirectToAction("Index");                        
                    }
                    else
                    {
                        return View();
                    }
                }

            }
            catch
            {
                return View();
            }

        }


        [AllowAnonymous]
        public ActionResult Test()
        {

            return View("Error");
            
        }



    }
}
