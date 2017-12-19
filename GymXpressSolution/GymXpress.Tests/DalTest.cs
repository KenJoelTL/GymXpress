using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymXpress.Models;
using System.Collections.Generic;
using System.Linq;

namespace GymXpress.Tests
{
    [TestClass]
    public class DalTest
    {

        [TestMethod]
        public void CreerUnCompte()
        {
            using (Dal dal = new Dal())
            {
                dal.CreerCompte(3, "test@mail.com", "mdp", "testPrenom", "testNom");
                List<Compte> compte = dal.ObtenirTousLesComptes();
                Assert.IsNotNull(compte);
                Assert.AreEqual(2, compte.Count);
                var compte2 = dal.ObtenirTousLesComptes().LastOrDefault();
                Assert.AreEqual("test@mail.com", compte2.Courriel);
            }
        }

        [TestMethod]
        public void ModifierCompte()
        {
            using (Dal dal = new Dal())
            {

                dal.ModifierCompte(2, 3, "test2@mail.com", "mdp", "testPrenom", "testNom");
                List<Compte> compte = dal.ObtenirTousLesComptes();
                Assert.IsNotNull(compte);
                Assert.AreEqual(2, compte.Count);
                Assert.AreEqual("test2@mail.com", compte[1].Courriel);
            }
        }

        [TestMethod]
        public void CreerUneDispo()
        {
            using (Dal dal = new Dal())
            {
                dal.CreerDispo(1, "heureDebutTest", "heureFinTest", "dateTest");
                List<Dispo> dispo = dal.ObtenirToutesLesDispos();
                Assert.IsNotNull(dispo);
               // Assert.AreEqual(1, dispo.Count);
                var dispo2 = dal.ObtenirToutesLesDispos().OrderBy(d=>d.IdDispo).LastOrDefault();
                Assert.AreEqual("heureDebutTest", dispo2.HeureDebut);
            }
        }

        [TestMethod]
        public void ModifierDispo()
        {
            using (Dal dal = new Dal())
            {
                //Pour que le test fonctionne, il faut s'assurer que le idDispo est bon, pcq il s'incrémente à chaque fois!!

                dal.ModifierDispo(1, 1, "heureDebutTest2", "heureFinTest", "dateFinTest");
                List<Dispo> dispo = dal.ObtenirToutesLesDispos();
                Assert.IsNotNull(dispo);
                Assert.AreEqual(1, dispo.Count);
                Assert.AreEqual("heureDebutTest2", dispo[0].HeureDebut);
            }
        }

        [TestMethod]
        public void CreerUnRDV()
        {
            using (Dal dal = new Dal())
            {
                dal.CreerRDV(1, 1, 1);
                List<RendezVous> rdv = dal.ObtenirTousLesRDV();
                Assert.IsNotNull(rdv);
                //Assert.AreEqual(1, rdv.Count);
                var rdv2 = dal.ObtenirTousLesRDV().OrderBy(r => r.IdRDV).LastOrDefault();
                Assert.AreEqual(1, rdv2.IdDispo);
                Assert.AreEqual(1, rdv2.IdEntraineur);
                Assert.AreEqual(1, rdv2.IdClient);
            }
        }

        [TestMethod]
        public void CreerUnPlan()
        {
            using (Dal dal = new Dal())
            {
                dal.CreerPlan(1, 1, "plan1", "description");
                List<Plan> plan = dal.ObtenirTousLesPlans();
                Assert.IsNotNull(plan);
               // Assert.AreEqual(1, plan.Count);
                var plan2 = dal.ObtenirTousLesPlans().OrderBy(p => p.IdPlan).LastOrDefault();
                Assert.AreEqual("description", plan2.Description);
                Assert.AreEqual("plan1", plan2.Nom);
                Assert.AreEqual(1, plan2.IdEntraineur);
                Assert.AreEqual(1, plan2.IdCompte);
            }
        }

        [TestMethod]
        public void ModifierPlan()
        {
            using (Dal dal = new Dal())
            {

                dal.ModifierPlan(1, 1, 1, "planTEST", "description");
                List<Plan> plan = dal.ObtenirTousLesPlans();
                Assert.IsNotNull(plan);
                Assert.AreEqual(1, plan.Count);
                Assert.AreEqual("planTEST", plan[0].Nom);
            }
        }


    }
}
