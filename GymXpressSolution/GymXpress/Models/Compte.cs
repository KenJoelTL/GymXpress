using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymXpress.Models
{
    public class Compte
    {
        private int idCompte;
        private int role;
        private string courriel;
        private string motPasse;

        public int IdCompte
        {
            get { return idCompte; }
            set { idCompte = value; }
        }

        public int Role
        {
            get { return role; }
            set { role = value; }
        }        

        public string Courriel
        {
            get { return courriel; }
            set { courriel = value; }
        }
        
        public string MotPasse
        {
            get { return motPasse; }
            set { motPasse = value; }
        }

        


    }
}