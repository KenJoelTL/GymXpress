using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymXpress.Controllers;
using System.Web.Mvc;
using System.Web;
using System.Reflection;
using System.Web.SessionState;
using System.IO;
using GymXpress.Models;
using System.Linq;
using System.Collections.Generic;

namespace GymXpress.Tests {
    [TestClass]
    public class CompteControllersTest {
        /*
        [TestInitialize]
        public void TestSetup() {
            // We need to setup the Current HTTP Context as follows:            

            // Step 1: Setup the HTTP Request
            var httpRequest = new HttpRequest("", "http://localhost/", "");

            // Step 2: Setup the HTTP Response
            var httpResponce = new HttpResponse(new StringWriter());

            // Step 3: Setup the Http Context
            var httpContext = new HttpContext(httpRequest, httpResponce);
            var sessionContainer =
                new HttpSessionStateContainer("id",
                                               new SessionStateItemCollection(),
                                               new HttpStaticObjectsCollection(),
                                               10,
                                               true,
                                               HttpCookieMode.AutoDetect,
                                               SessionStateMode.InProc,
                                               false);
            httpContext.Items["AspSession"] =
                typeof(HttpSessionState)
                .GetConstructor(
                                    BindingFlags.NonPublic | BindingFlags.Instance,
                                    null,
                                    CallingConventions.Standard,
                                    new[] { typeof(HttpSessionStateContainer) },
                                    null)
                .Invoke(new object[] { sessionContainer });

            // Step 4: Assign the Context
            HttpContext.Current = httpContext;
        }*/
        CompteController compteController;

        [TestInitialize]
        public void TestSetup() {
            compteController = new CompteController();
        }


        [TestMethod]
        public void IndexTest() {
            
            using (Dal dal = new Dal()) {
                List<Compte> listeDesComptes = dal.ObtenirTousLesComptes();
                var resultat = compteController.Index() as ViewResult;
                Assert.AreEqual(listeDesComptes.Count, ((List<Compte>)resultat.ViewData.Model).Count);
                for (int i = 0; i < listeDesComptes.Count; i++) {
                    Assert.AreEqual(listeDesComptes.ElementAt(i).IdCompte, ((List<Compte>)resultat.ViewData.Model).ElementAt(i).IdCompte);
                }
            }
        }

        [TestMethod]
        public void CreationCompteVueTest() {
            var result = compteController.Index() as ViewResult;
            Assert.AreEqual("", result.ViewName);

        }

        [TestMethod]
        public void CreationCompteExistantTest() {
            Compte compte = new Compte() { Courriel = "admin@mail.com", MotPasse = "admin", IdCompte = 1 };
            string confirmationMotPasse = compte.MotPasse;
            var result = compteController.Create(compte, confirmationMotPasse) as ViewResult;
            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void CreationCompteNonExistantTest() {
            Compte compte = new Compte() { Courriel = "test@mail.com", MotPasse = "test", Prenom="Test", Nom ="Unitaire", Role=0};
            string confirmationMotPasse = compte.MotPasse;
            using (Dal dal = new Dal()) {
                Compte cpt = dal.ObtenirTousLesComptes().SingleOrDefault(c => c.Courriel == compte.Courriel);
                if (cpt != null) {
                    dal.SupprimerCompte(cpt.IdCompte);
                }
                var result = compteController.Create(compte, confirmationMotPasse) as ViewResult;
                //Puisque le compte connecté n'est pas admin alors il est redirige vers Index
                Assert.AreNotEqual("Login", result.ViewName);
                //N'envoie pas vers le Index car la Controller.Session est null
                Assert.AreNotEqual("Index", result.ViewName);
                //Entre dans le catch car la session n'existe pas
                Assert.AreEqual("_Error", result.ViewName);
            }
        }

        [TestMethod]
        public void DetailsTest() {
            var param = -100;
            var result = compteController.Edit(param) as ViewResult;
            Assert.AreEqual("_Error", result.ViewName);

            param = 1;
            var result2 = compteController.Edit(param) as ViewResult;
            Assert.AreEqual("", result2.ViewName);
            Assert.AreEqual(1, ((Compte)result2.Model).IdCompte);
        }

        [TestMethod]
        public void EditTest() {
            var param = 1;
            var result = compteController.Edit(param) as ViewResult;
            Assert.AreEqual("", result.ViewName);
        }

        [TestMethod]
        public void EditPostTest() {
            Compte param = new Compte();
            var result = compteController.Edit(param) as ViewResult;
            Assert.IsNull(result);
            var result2 = compteController.Edit(param) as RedirectToRouteResult;
            Assert.AreEqual("Index", result2.RouteValues["action"]);
        }


        [TestMethod]
        public void DeleteTest() {
            var param = 1;
            var result = compteController.Delete(param) as ViewResult;
            Assert.AreEqual("", result.ViewName);
            using (Dal dal = new Dal()) {
                Compte compte = dal.ObtenirTousLesComptes().FirstOrDefault();
                var result2 = compteController.Delete(compte.IdCompte) as ViewResult;
                Assert.AreEqual(compte.IdCompte, ((Compte)result2.Model).IdCompte);
            }
            param = -150;
            var result3 = compteController.Delete(param) as RedirectToRouteResult;
            Assert.AreEqual("Index", result3.RouteValues["action"]);
        }

        [TestMethod]
        public void DeletePostTest() {
            var form = new FormCollection();
            var param = 0;
            using (Dal dal = new Dal()) {
                dal.CreerCompte(0, "testdelete@mail.com", "delete", "Test", "Delete");
                Compte compte = dal.ObtenirTousLesComptes().FirstOrDefault(c => c.Courriel == "testdelete@mail.com");

                param = compte.IdCompte;
                var result = compteController.Delete(param,form) as RedirectToRouteResult;
                Assert.AreEqual("Index", result.RouteValues["action"]);
            }

                param = -150;
                var result2 = compteController.Delete(param,form) as ViewResult;
                Assert.AreEqual("_Error", result2.ViewName);
        }


        /*
        [TestMethod]
        public void TestConnection() {
            CompteController compteController = new CompteController();
            HttpContext.Current.Session.Add("connecte", "capitaine@mail.com");
//            compteController.HttpContext.Session["connecte"] = "capitaine@mail.com";
//            compteController.HttpContext.Session["role"] = "1";
            HttpContext.Current.Session.Add("role", 1);

            var result = compteController.Login() as ViewResult;
            Assert.AreEqual("Index", result.ViewName);
        }*/

    }
}
