using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GymXpress.Models;
using System.Collections.Generic;

namespace GymXpress.Tests
{
    [TestClass]
    public class DalTest
    {
        [TestInitialize]
        public void Init_AvantChaqueTest()
        {
            using (Dal dal = new Dal())
            {
                dal.viderDispo();

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
                dal.CreerDispo(1, "heureDebutTest", "heureFinTest", "dateTest");
                dal.ModifierDispo(3, 1, "heureDebutTest2", "heureFinTest", "dateFinTest");
                List<Dispo> dispo = dal.ObtenirToutesLesDispos();
                Assert.IsNotNull(dispo);
                Assert.AreEqual(1, dispo.Count);
                Assert.AreEqual("heureDebutTest2", dispo[0].HeureDebut);
            }
        }

        [TestMethod]
        public void CreerUnCompte()
        {
            using (Dal dal = new Dal())
            {
                dal.CreerCompte(3, "test@mail.com", "mdp", "testPrenom", "testNom");
                List<Compte> compte = dal.ObtenirTousLesComptes();
                Assert.IsNotNull(compte);
                Assert.AreEqual(1, compte.Count);
                Assert.AreEqual("test@mail.com", compte[0].Courriel);
            }
        }
    }
}
