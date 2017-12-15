using System;
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

        public int IdPlan {
            get { return idPlan; }
            set { idPlan = value; }
        }

        public int IdCompte {
            get { return idCompte; }
            set { idCompte = value; }
        }

        public int IdEntraineur {
            get { return idEntraineur; }
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