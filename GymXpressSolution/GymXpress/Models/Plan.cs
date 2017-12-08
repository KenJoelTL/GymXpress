using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymXpress.Models {

    public class Plan {

        private int idPlan;
        private int idCompte;
        private int idEntraineur;
        private string nom;

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

        public string Nom {
            get { return nom; }
            set { nom = value; }
        }



    }

}