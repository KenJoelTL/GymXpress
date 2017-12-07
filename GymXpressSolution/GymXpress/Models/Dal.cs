﻿using System;
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

        public void ModifierCompte(int id, int role, string courriel, string motPasse)
        {
            bdd.Compte.Update(new Compte { IdCompte = id, Role = role, Courriel = courriel, MotPasse = motPasse });
        }

        public List<Compte> ObtenirTousLesComptes()
        {
            return bdd.Compte.ToList();
        }

    //---------------------------------------------
        // PlanEntrainement |
        public void CreerPlanEntrainement(int idCompte, int idEntraineur, string nom) {
            bdd.PlanEntrainement.Add(new PlanEntrainement { IdCompte = idCompte, IdEntraineur = idEntraineur, Nom = nom });
        }

        public List<PlanEntrainement> ObtenirTousLesPlanEntrainements() {
            return bdd.PlanEntrainement.ToList();
        }

        public void ModifierPlanEntrainement(int idCompte, int idEntraineur, string nom) {
            bdd.PlanEntrainement.Update(new PlanEntrainement { IdCompte = idCompte, IdEntraineur = idEntraineur, Nom = nom });
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
    }
#endregion
}