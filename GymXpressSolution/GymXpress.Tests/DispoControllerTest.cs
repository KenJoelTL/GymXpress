using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymXpress.Models;
using GymXpress.Controllers;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;

namespace GymXpress.Tests {
    [TestClass]
    public class DispoControllerTest {

        DispoController dispoController;

        [TestInitialize]
        public void TestSetup() {
            dispoController = new DispoController();
        }

        [TestMethod]
        public void IndexTest() {

            using (Dal dal = new Dal()) {
                List<Dispo> listeDesDispos = dal.ObtenirToutesLesDispos();
                var resultat = dispoController.Index() as ViewResult;
                Assert.AreEqual(listeDesDispos.Count, ((List<Dispo>)resultat.ViewData.Model).Count);
                for (int i = 0; i < listeDesDispos.Count; i++) {
                    Assert.AreEqual(listeDesDispos.ElementAt(i).IdDispo, ((List<Dispo>)resultat.ViewData.Model).ElementAt(i).IdDispo);
                }
            }
        }

        [TestMethod]
        public void CreationDispoVueTest() {
            var result = dispoController.Index() as ViewResult;
            Assert.AreEqual("", result.ViewName);

        }

        [TestMethod]
        public void ModificationDispoVueTest() {
            int param;
            using (Dal dal = new Dal()) {
                dal.CreerDispo(1, "debutTest", "finTest", "dateTest");
                Dispo dispo = dal.ObtenirToutesLesDispos().OrderBy(d => d.IdDispo).LastOrDefault();
                param = dispo.IdDispo;
                var resultat = dispoController.Edit(param) as ViewResult;
                Assert.AreEqual("", resultat.ViewName);
                Assert.AreEqual(param, ((Dispo)resultat.ViewData.Model).IdDispo);
            }
            param = -150;
            var result2 = dispoController.Edit(param) as ViewResult;
            Assert.AreEqual("_Error", result2.ViewName);
        }


        [TestMethod]
        public void ModificationDispoPostTest() {

            using (Dal dal = new Dal()) {
                dal.CreerDispo(1, "debutTest", "finTest", "dateTest");
                Dispo dispo = dal.ObtenirToutesLesDispos().OrderBy(d=>d.IdDispo).LastOrDefault();
                var resultat = dispoController.Edit(dispo.IdDispo, dispo.IdEntraineur, "Testdebut", "Testfin", "Testdate") as RedirectToRouteResult;
                Dispo dispo2 = dal.ObtenirToutesLesDispos().OrderBy(d => d.IdDispo).LastOrDefault();
                Assert.AreEqual(1,dispo2.IdEntraineur);
                Assert.AreEqual("Testdebut", dispo2.HeureDebut);
                Assert.AreEqual("Testfin", dispo2.HeureFin);
                Assert.AreEqual("Testdate", dispo2.Date);

                Assert.AreEqual("Index", resultat.RouteValues["action"]);
            }
                var param = -150;
                var result2 = dispoController.Edit(param, param, "","","") as ViewResult;
                Assert.AreEqual("", result2.ViewName);
        }


    }
}
