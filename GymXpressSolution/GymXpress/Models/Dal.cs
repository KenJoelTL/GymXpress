using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymXpress.Models
{
    public class Dal : Idal
    {
    //---------------------------------------------
        // Attributes |
        private BddContext bdd;

    //---------------------------------------------
        // Constructor |
        public Dal()
        {
            bdd = new BddContext();
        }

    //---------------------------------------------
        // Méthode implémentée |
        public void Dispose() {
            bdd.Dispose();
        }

#region

    //======================================================
        // Méthodes implémentées CRUD |
        
    //---------------------------------------------
        // Compte |
        public void CreerCompte(int role, string courriel, string motPasse)
        {
            bdd.Compte.Add(new Compte { Role = role, Courriel = courriel, MotPasse = motPasse });
        }

        public List<Compte> ObtenirTousLesComptes() {
            return bdd.Compte.ToList();
        }
        public void ModifierCompte(int id, int role, string courriel, string motPasse) {
            bdd.Compte.Update(new Compte { IdCompte = id, Role = role, Courriel = courriel, MotPasse = motPasse });
        }

        public void SupprimerCompte(int idCompte) {
            bdd.Compte.Remove(new Compte { IdCompte = idCompte });
        }


    //---------------------------------------------
        // Plan |
        public void CreerPlan(int idCompte, int idEntraineur, string nom) {
            bdd.Plan.Add(new Plan { IdCompte = idCompte, IdEntraineur = idEntraineur, Nom = nom });
        }

        public List<Plan> ObtenirTousLesPlans() {
            return bdd.Plan.ToList();
        }

        public void ModifierPlan(int idPlan, int idCompte, int idEntraineur, string nom) {
            bdd.Plan.Update(new Plan { IdPlan = idPlan, IdCompte = idCompte, IdEntraineur = idEntraineur, Nom = nom });
        }

        public void SupprimerPlan(int idPlan) {
            bdd.Plan.Remove(new Plan { IdPlan = idPlan });
        }

    }
#endregion

}