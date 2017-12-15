using GymXpress.Filter;
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
        const string connecte = "connecte";
        const string role = "role";
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
            using (IDal dal = new Dal()) {
                Compte compte = dal.ObtenirTousLesComptes().FirstOrDefault(c => c.IdCompte == id);
                if (compte == null)
                    return View("_Error");
                return View(compte);
            }
        }

        // GET: Compte/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compte/Create
        [HttpPost, AllowAnonymous]
        public ActionResult Create(Compte compte, string confirmationMotPasse)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                using (IDal dal = new Dal())
                {
                    Compte cpt = dal.ObtenirTousLesComptes().SingleOrDefault(c => c.Courriel == compte.Courriel);
                    if (compte == null) {
                        dal.CreerCompte(compte.Role, compte.Courriel, compte.MotPasse, compte.Prenom, compte.Nom);
                        if(HttpContext.Session[connecte] == null && HttpContext.Session[role] == null && (int)HttpContext.Session[role] < 2)
                            return RedirectToAction("Login");
                        else {
                            return RedirectToAction("Index");
                        }
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
        public ActionResult Edit(Compte compte)
        {
            if (!ModelState.IsValid)
                return View();
            using (IDal dal = new Dal())
            {
                Compte cpt = dal.ObtenirTousLesComptes().FirstOrDefault(c => c.IdCompte == compte.IdCompte);
                if (compte != null)
                    dal.ModifierCompte(compte.IdCompte, compte.Role, compte.Courriel, compte.MotPasse, compte.Prenom, compte.Nom);
                return RedirectToAction("Index");
            }

        }

        // GET: Compte/Delete/5
        [AuthorizationConnectionFilter]
        public ActionResult Delete(int id)
        {
            using (IDal dal = new Dal()) {

                Compte compte = dal.ObtenirTousLesComptes().FirstOrDefault(c => c.IdCompte == id);
                if (compte != null) {
                    dal.SupprimerCompte(compte.IdCompte);
                    return View(compte);
                }
                else
                    return View("Index");
            }

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
            if (HttpContext.Session[connecte] != null) {
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        [HttpPost, AllowAnonymous]
        public ActionResult Login(string courriel, string motPasse)
        {
            try
            {
                using (IDal dal = new Dal())
                {
                    Compte compte = dal.ObtenirTousLesComptes().SingleOrDefault(c => c.Courriel == courriel && c.MotPasse == motPasse);
                    if ((compte != null) || (HttpContext.Session[connecte] != null)) {
                        HttpContext.Session[connecte] = compte.IdCompte;
                        HttpContext.Session[role] = compte.Role;
                        return RedirectToAction("Index","Home");                        
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

                    Compte compte = dal.ObtenirTousLesComptes().SingleOrDefault(c => c.IdCompte == (int)HttpContext.Session[connecte]);
                    if (compte != null && HttpContext.Session[connecte] != null) {
                        HttpContext.Session.Clear();
                        return RedirectToAction("Login");
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
