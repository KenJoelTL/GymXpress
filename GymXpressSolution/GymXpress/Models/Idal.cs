using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymXpress.Models
{
    interface IDal : IDisposable {

    //---------------------------------------------
        // Compte |
        void CreerCompte(int role, string courriel, string motPasse, string prenom, string nom);
        List<Compte> ObtenirTousLesComptes();
        void ModifierCompte(int id, int role, string courriel, string motPasse, string prenom, string nom);
        void SupprimerCompte(int idCompte);
     
    //---------------------------------------------
        // Plan |
        void CreerPlan(int idCompte, int idEntraineur, string nom, string description);
        List<Plan> ObtenirTousLesPlans();
        void ModifierPlan(int idPlan, int idCompte, int idEntraineur, string nom, string description);
        void SupprimerPlan(int idPlan);
    //---------------------------------------------
        // Dispo |
        void CreerDispo(int idEntraineur, string heureDebut, string heureFin, string date);
        List<Dispo> ObtenirToutesLesDispos();
        void ModifierDispo(int idDispo, int idEntraineur, string heureDebut, string heureFin, string date);
        void SupprimerDispo(int idDispo);
    //---------------------------------------------
        // Rendez vous |
        void CreerRDV(int idDispo, int idClient, int idEntraineur);
        List<RendezVous> ObtenirTousLesRDV();
        void ModifierRDV(int idRDV, int idDispo, int idClient, int idEntraineur);
        void SupprimerRDV(int idRDV);
    }
}