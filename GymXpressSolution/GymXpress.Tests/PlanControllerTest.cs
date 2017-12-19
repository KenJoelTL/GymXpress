using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymXpress.Controllers;
using System.Web.Mvc;

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
        public void TestRenvoieVueLorsqueNon() {
            var result = planController.Index() as ViewResult;
            Assert.AreEqual("", result.ViewName);
        }



    }
}
