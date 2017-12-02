using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymXpress.Models
{
    interface Idal : IDisposable {

    //---------------------------------------------
        // Compte |
        void CreerCompte(int role, string courriel, string motPasse);
        List<Compte> ObtenirTousLesComptes();
        void ModifierCompte(int id, int role, string courriel, string motPasse);
     
    //---------------------------------------------
        // PlanEntrainement |
        void CreerPlanEntrainement(int idCompte, int idEntraineur, string nom);
        List<PlanEntrainement> ObtenirTousLesPlanEntrainements();
        void ModifierPlanEntrainement(int idCompte, int idEntraineur, string nom);

    }
}