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

            return View();
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

        // GET: Compte/Edit/5
        public ActionResult Edit(int id, string nom)
        {
            Console.WriteLine("=========================================== "+nom);
            return View();
        }

        // POST: Compte/Edit/5
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

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
