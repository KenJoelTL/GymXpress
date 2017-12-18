using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymXpress.Models
{
    public class Compte
    {
        public const int UTILISATEUR = 0;
        public const int ENTRAINEUR = 1;
        public const int ADMIN = 2; 

        private int idCompte;
        private int role;
        private string courriel;
        private string motPasse;
        private string prenom;
        private string nom;


        public int IdCompte {
            get { return idCompte; }
            set { idCompte = value; }
        }

        [Required]
        public int Role {
            get { return role; }
            set { role = value; }
        }        

        [Required]
        public string Courriel {
            get { return courriel; }
            set { courriel = value; }
        }

        [DisplayName("Mot de passe"), Required]
        public string MotPasse {
            get { return motPasse; }
            set { motPasse = value; }
        }

        [Required]
        public string Prenom {
            get { return prenom; }
            set { prenom = value; }
        }

        [Required]
        public string Nom {
            get { return nom; }
            set { nom = value; }
        }
        

    }
}