using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymXpress.Controllers;
using System.Web.Mvc;
using GymXpress.Models;
using System.Linq;

namespace GymXpress.Tests {
    [TestClass]
    public class PlanControllerTest {
        PlanController planController;

        [TestInitialize]
        public void TestSetup(){
            planController = new PlanController();
        }

        [TestMethod]
        public void CreationPlanVueTest() {
            var result = planController.Create() as ViewResult;
            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void CreationPostTest() {
            Plan plan = new Plan() { Nom = "Plan de test", IdEntraineur = 1, Description = "Ceci est un plan de test", IdCompte = 1 };
            var result = planController.Create(plan) as RedirectToRouteResult;
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }
        
        [TestMethod]
        public void EditTest() {
            var param = 1;
            var result = planController.Edit(param) as ViewResult;
            Assert.AreEqual("", result.ViewName);
            using (Dal dal = new Dal()) {
                Plan plan = dal.ObtenirTousLesPlans().FirstOrDefault();
                var result2 = planController.Edit(plan.IdPlan) as ViewResult;
                Assert.AreEqual(plan.IdPlan,((Plan)result2.Model).IdPlan);
            }
            param = -150;
            var result3 = planController.Edit(param) as RedirectToRouteResult;
            Assert.AreEqual("Index", result3.RouteValues["action"]);
        }
        
        [TestMethod]
        public void EditPostTest() {
            var param = 1;
            var form = new FormCollection();
            using (Dal dal = new Dal()) {
                Plan plan = dal.ObtenirTousLesPlans().FirstOrDefault(p => p.IdPlan == param);
                plan.Client = dal.ObtenirTousLesComptes().FirstOrDefault(c => c.IdCompte == plan.IdCompte);
                plan.Entraineur = dal.ObtenirTousLesComptes().FirstOrDefault(c => c.IdCompte == plan.IdEntraineur);
                form["CourrielClient"] = plan.Client.Courriel;
                form["CourrielEntraineur"] = plan.Entraineur.Courriel;
                form["Nom"] = plan.Nom;
                form["Description"] = plan.Description;
                var result = planController.Edit(plan.IdPlan,form) as RedirectToRouteResult;
                Assert.AreEqual("Index", result.RouteValues["action"]);
            }
            param = -150;
            var result3 = planController.Edit(param,form) as ViewResult;
            Assert.AreEqual("_Error", result3.ViewName);

        }

        [TestMethod]
        public void DeleteTest() {
            var param = 1;
            var result = planController.Delete(param) as ViewResult;
            Assert.AreEqual("", result.ViewName);
            using (Dal dal = new Dal()) {
                Plan plan = dal.ObtenirTousLesPlans().FirstOrDefault();
                var result2 = planController.Delete(plan.IdPlan) as ViewResult;
                Assert.AreEqual(plan.IdPlan, ((Plan)result2.Model).IdPlan);
            }
            param = -150;
            var result3 = planController.Delete(param) as RedirectToRouteResult;
            Assert.AreEqual("Index", result3.RouteValues["action"]);
        }

        [TestMethod]
        public void DeletePostTest() {
            var form = new FormCollection();
            var param = 0;
            using (Dal dal = new Dal()) {
                dal.CreerPlan(1,1,"Plan de Test", "Pour la suppression");
                Plan plan = dal.ObtenirTousLesPlans().LastOrDefault();

                param = plan.IdPlan;
                var result = planController.Delete(param, form) as RedirectToRouteResult;
                Assert.AreEqual("Index", result.RouteValues["action"]);
            }

            param = -150;
            var result2 = planController.Delete(param, form) as ViewResult;
            Assert.AreEqual("_Error", result2.ViewName);
        }

        /*
        [TestMethod]
        public void TestRenvoieVueLorsqueNon() {
            var result = planController.Index() as ViewResult;
            Assert.AreEqual("", result.ViewName);
        }*/



    }
}
