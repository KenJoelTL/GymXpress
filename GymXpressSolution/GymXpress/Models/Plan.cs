﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GymXpress.Models {

    public class Plan {

        private int idPlan;
        private int idCompte;
        private int idEntraineur;
        private string nom;
        private string description;
        public Compte Entraineur { get; set; }
        public Compte Client { get; set; }
        
        public int IdPlan {
            get { return idPlan; }
            set { idPlan = value; }
        }

        public int IdCompte {
            get { return idCompte; }
            set { idCompte = value; }
        }

        public int IdEntraineur {
            //obtient le id de l'entraineur courant
            get {
                //return Entraineur.IdCompte;
                return idEntraineur;
            }
            //change d'entraineur et non le id de l'entraineur courant
            set { idEntraineur = value; }       
        }

        [Required]
        public string Nom {
            get { return nom; }
            set { nom = value; }
        }

        public string Description {
            get { return description; }
            set { description = value; }
        }

    }

}