using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymXpress.Models {

    public class PlanEntrainement {

        private int idPlanEntraienement;
        private int idCompte;
        private int idEntrainement;
        private string nom;

        public int IdPlanEntrainement {
            get { return idPlanEntraienement; }
            set { idPlanEntraienement = value; }
        }


        public int IdCompte {
            get { return idCompte; }
            set { idCompte = value; }
        }


        public int IdEntrainement {
            get { return idEntrainement; }
            set { idEntrainement = value; }
        }


        public string Nom {
            get { return nom; }
            set { nom = value; }
        }



    }

}