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
            bdd.Compte.Add(new Compte { Role = role, Courriel = courriel, MotPasse = motPasse, Prenom = prenom, Nom = nom });
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
        public void viderCompte()
        {
            bdd.Compte.Clear();
        }


        //---------------------------------------------
        // Plan |
        public void CreerPlan(int idCompte, int idEntraineur, string nom, string description) {
            bdd.Plan.Add(new Plan { IdCompte = idCompte, IdEntraineur = idEntraineur, Nom = nom, Description = description });
        }

        public List<Plan> ObtenirTousLesPlans() {
            return bdd.Plan.ToList();
        }

        public void ModifierPlan(int idPlan, int idCompte, int idEntraineur, string nom, string description) {
            bdd.Plan.Update(new Plan { IdPlan = idPlan, IdCompte = idCompte, IdEntraineur = idEntraineur, Nom = nom, Description = description });
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

        public void viderDispo()
        {
            bdd.Dispo.Clear();
        }

        //---------------------------------------------
        // Rendez vous |
        public void CreerRDV(int idDispo, int idClient, int idEntraineur)
        {
            bdd.RDV.Add(new RendezVous { IdDispo = idDispo, IdClient = idClient, IdEntraineur = idEntraineur });
        }
        public List<RendezVous> ObtenirTousLesRDV()
        {
            return bdd.RDV.ToList();
        }
        public void ModifierRDV(int idRDV, int idDispo, int idClient, int idEntraineur)
        {
            bdd.RDV.Update(new RendezVous { IdRDV = idRDV, IdDispo = idDispo, IdClient = idClient, IdEntraineur = idEntraineur });
        }
        public void SupprimerRDV(int idRDV) {
            bdd.RDV.Remove(new RendezVous { IdRDV = idRDV});
        }

    }
#endregion

}