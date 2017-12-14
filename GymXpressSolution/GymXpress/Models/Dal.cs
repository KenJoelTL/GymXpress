using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymXpress.Models
{
    public class Dal : IDal
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
        public void CreerCompte(int role, string courriel, string motPasse, string prenom, string nom)
        {
            bdd.Compte.Add(new Compte { Role = role, Courriel = courriel, MotPasse = motPasse, Prenom = nom, Nom = nom });
        }

        public List<Compte> ObtenirTousLesComptes() {
            return bdd.Compte.ToList();
        }
        public void ModifierCompte(int id, int role, string courriel, string motPasse, string prenom, string nom) {
            bdd.Compte.Update(new Compte { IdCompte = id, Role = role, Courriel = courriel, MotPasse = motPasse, Prenom = prenom, Nom = nom });
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

    //---------------------------------------------
        // dispo |

        public void CreerDispo(int idEntraineur, string heureDebut, string heureFin, string date)
        {
            bdd.Dispo.Add(new Dispo { IdEntraineur = idEntraineur, HeureDebut = heureDebut, HeureFin = heureFin, Date = date });
        }
        public List<Dispo> ObtenirToutesLesDispos()
        {
            return bdd.Dispo.ToList(); 
        }
        public void ModifierDispo(int idDispo, int idEntraineur, string heureDebut, string heureFin, string date)
        {
            bdd.Dispo.Update(new Dispo { IdDispo = idDispo, IdEntraineur = idEntraineur, HeureDebut = heureDebut, HeureFin = heureFin, Date = date });
        }
        public void SupprimerDispo(int idDispo) {
            bdd.Dispo.Remove(new Dispo { IdDispo = idDispo});
        }

        //---------------------------------------------
        // Rendez vous |
        public void CreerRDV(int idDispo, int idClient)
        {
            bdd.RDV.Add(new RendezVous { IdDispo = idDispo, IdClient = idClient });
        }
        public List<RendezVous> ObtenirTousLesRDV()
        {
            return bdd.RDV.ToList();
        }
        public void ModifierRDV(int idRDV, int idDispo, int idClient)
        {
            bdd.RDV.Update(new RendezVous { IdRDV = idRDV, IdDispo = idDispo, IdClient = idClient });
        }
        public void SupprimerRDV(int idRDV) {
            bdd.RDV.Remove(new RendezVous { IdRDV = idRDV});
        }

    }
#endregion

}