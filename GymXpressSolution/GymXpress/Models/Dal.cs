using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymXpress.Models
{
    public class Dal : Idal
    {
        private BddContext bdd;

        public Dal()
        {
            bdd = new BddContext();
        }

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

        public void Dispose()
        {
            bdd.Dispose();
        }
    }
}