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
            param = -1;
            var result3 = planController.Edit(param) as RedirectToRouteResult;
            Assert.AreEqual("Index", result3.RouteValues["action"]);
        }
        /*
        [TestMethod]
        public void EditPostTest() {
            Plan param = new Plan();
            var result = planController.Edit(param) as ViewResult;
            Assert.IsNull(result);
            var result2 = planController.Edit(param) as RedirectToRouteResult;
            Assert.AreEqual("Index", result2.RouteValues["action"]);
        }
        */
        /*
        [TestMethod]
        public void TestRenvoieVueLorsqueNon() {
            var result = planController.Index() as ViewResult;
            Assert.AreEqual("", result.ViewName);
        }*/



    }
}
