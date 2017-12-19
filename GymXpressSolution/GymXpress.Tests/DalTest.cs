using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymXpress.Models;
using System.Collections.Generic;

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
                Assert.AreEqual("test@mail.com", compte[1].Courriel);
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
                Assert.AreEqual(1, dispo.Count);
                Assert.AreEqual("heureDebutTest", dispo[0].HeureDebut);
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
                Assert.AreEqual(1, rdv.Count);
                Assert.AreEqual(1, rdv[0].IdDispo);
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
                Assert.AreEqual(1, plan.Count);
                Assert.AreEqual("description", plan[0].Description);
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
