using GymXpress.App_Start;
using GymXpress.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymXpress.Controllers
{
    [HandleError]
    public class CompteController : Controller
    {
        // GET: Compte
        [AuthorizationConnectionFilter]
        public ActionResult Index()
        {
            using (IDal dal = new Dal())
            {
                List<Compte> listeDesComptes = dal.ObtenirTousLesComptes();
                return View(listeDesComptes);
            }
        }

        // GET: Compte/Details/5
        [AuthorizationConnectionFilter]
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
        [HttpPost, AllowAnonymous]
        public ActionResult Create(int? role, string courriel, string motPasse, string confirmationMotPasse, string prenom, string nom)
        {
            try
            {
                using (IDal dal = new Dal())
                {
                    Compte compte = dal.ObtenirTousLesComptes().SingleOrDefault(c => c.Courriel == courriel);
                    if (compte == null) {
                        dal.CreerCompte(role?? 0, courriel, motPasse, prenom, nom);
                        return RedirectToAction("Login");
                    }
                    else {
                        return View();
                    }
                }
            }
            catch
            {
                return View();
            }
        }

        [AuthorizationConnectionFilter]
        public ActionResult Edit(int? id)
        {
            if (id.HasValue)
            {
                using (IDal dal = new Dal())
                {
                    Compte compte = dal.ObtenirTousLesComptes().FirstOrDefault(c => c.IdCompte == id.Value);
                    if (compte == null)
                        return View("_Error");
                    return View(compte);
                }
            }
            else
                return HttpNotFound();
        }

        [HttpPost, AuthorizationConnectionFilter]
        public ActionResult Edit(int id, int role, string courriel, string motPasse)
        {
            if (!ModelState.IsValid)
                return View();
            using (IDal dal = new Dal())
            {
                dal.ModifierCompte(id, role, courriel, motPasse);
                return RedirectToAction("Index");
            }

        }

        // GET: Compte/Delete/5
        [AuthorizationConnectionFilter]
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Compte/Delete/5
        [HttpPost, AuthorizationConnectionFilter]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (IDal dal = new Dal())
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
                using (IDal dal = new Dal())
                {
                    string connecte = "connecte";
                    string role = "role";
                    Compte compte = dal.ObtenirTousLesComptes().SingleOrDefault(c => c.Courriel == courriel && c.MotPasse == motPasse);
                    if ((compte != null) || (HttpContext.Session[connecte] != null)) {
                        HttpContext.Session[connecte] = compte.IdCompte;
                        HttpContext.Session[role] = compte.Role;
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

        public ActionResult Logout() {
            try {
                using (IDal dal = new Dal()) {

                    string connecte = "connecte";
                    Compte compte = dal.ObtenirTousLesComptes().SingleOrDefault(c => c.IdCompte == (int)HttpContext.Session[connecte]);
                    if (compte != null && HttpContext.Session[connecte] != null) {
                        HttpContext.Session.Clear();
                        return RedirectToAction("Index");
                    }
                    else {
                        return View();
                    }
                }

            }
            catch {
                return View();
            }

        }

        public ActionResult Test()
        {
            return View("_Error");   
        }



    }
}
