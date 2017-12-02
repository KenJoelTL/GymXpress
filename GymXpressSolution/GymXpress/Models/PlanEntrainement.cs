using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymXpress.Models {

    public class PlanEntrainement {

        private int idPlanEntraienement;
        private int idCompte;
        private int idEntraineur;
        private string nom;

        public int IdPlanEntrainement {
            get { return idPlanEntraienement; }
            set { idPlanEntraienement = value; }
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