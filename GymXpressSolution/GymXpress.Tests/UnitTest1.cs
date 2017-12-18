using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymXpress.Controllers;
using System.Web.Mvc;

namespace GymXpress.Tests {
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            PlanController planController = new PlanController();
            var result = planController.Index() as ViewResult;
            //ActionResult t = new ActionResult();
            Assert.AreEqual("Index", result.ViewName);
        }

        [TestMethod]
        public void TestRenvoieListe() {/*
            PlanController planController = new PlanController();
            var result = planController.Index() as ViewResult;
            var liste = result.
            Assert.AreEqual("Index", result.);*/
        }

        [TestMethod]
        public void TestRenvoieVueLorsqueNon() {
            PlanController planController = new PlanController();
            var result = planController.Index() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }

    }
}
