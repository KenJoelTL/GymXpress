using GymXpress.Filters;
using GymXpress.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GymXpress.Controllers {
    [HandleError]
    public class CompteController : Controller
    {
        const string connecte = "connecte";
        const string role = "role";
        // GET: Compte
        [AuthorizationConnectionFilter, AutorisationAdminFilter]
        public ActionResult Index()
        {
            using (IDal dal = new Dal())
            {
                List<Compte> listeDesComptes = dal.ObtenirTousLesComptes();
                return View(listeDesComptes);
            }
        }

        // GET: Compte/Details/5
        [AuthorizationConnectionFilter, AutorisationAdminFilter]
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
        [HttpPost]
        public ActionResult Create(Compte compte, string confirmationMotPasse)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                using (IDal dal = new Dal())
                {
                    Compte cpt = dal.ObtenirTousLesComptes().SingleOrDefault(c => c.Courriel == compte.Courriel);
                    if (cpt == null) {
                        dal.CreerCompte(compte.Role, compte.Courriel, compte.MotPasse, compte.Prenom, compte.Nom);
                        if((HttpContext.Session[connecte] == null && HttpContext.Session[role] == null) || (int)HttpContext.Session[role] < Compte.ADMIN)
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
                return View("_Error");
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
        [AuthorizationConnectionFilter, AutorisationAdminFilter]
        public ActionResult Delete(int id)
        {
            using (IDal dal = new Dal()) {

                Compte compte = dal.ObtenirTousLesComptes().FirstOrDefault(c => c.IdCompte == id);
                if (compte != null) {
                    //dal.SupprimerCompte(compte.IdCompte);
                    return View(compte);
                }
                else
                    return RedirectToAction("Index");
            }

        }

        // POST: Compte/Delete/5
        [HttpPost, AuthorizationConnectionFilter, AutorisationAdminFilter]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (IDal dal = new Dal()) {
                    Compte compte = dal.ObtenirTousLesComptes().FirstOrDefault(c => c.IdCompte == id);

                    if (compte != null) {
                        dal.SupprimerCompte(id);
                        return RedirectToAction("Index");
                    }
                    else
                        return View("_Error");
                }

            }
            catch
            {
                return View();
            }
        }
        
        // GET: Login

        public ActionResult Login()
        {
            if (HttpContext.Session[connecte] != null) {
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        [HttpPost]
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
