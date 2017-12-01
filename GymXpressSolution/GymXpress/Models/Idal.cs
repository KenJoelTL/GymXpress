using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymXpress.Models
{
    interface Idal : IDisposable
    {
        void CreerCompte(int role, string courriel, string motPasse);
        List<Compte> ObtenirTousLesComptes();
        void ModifierCompte(int id, int role, string courriel, string motPasse);
     
    }
}