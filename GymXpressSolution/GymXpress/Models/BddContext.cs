using GymXpress.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymXpress.Models
{
    public class BddContext : DbContext
    {
    //---------------------------------------------
        // Attributes |

        private CompteDAO compte;
        private PlanDAO plan;
        private DispoDAO dispo;
        private RendezVousDAO rdv;


    //---------------------------------------------
        // Constructor |
        public BddContext() : base()
        {
            Compte = new CompteDAO(cnx);
            Plan = new PlanDAO(cnx);
            Dispo = new DispoDAO(cnx);
            RDV = new RendezVousDAO(cnx);
        }


       
    //---------------------------------------------
        // Getters | Setters

        public CompteDAO Compte{
            get{ return compte; }
            set{ compte = value; }
        }

        public PlanDAO Plan {
            get { return plan; }
            set { plan = value; }
        }

        public DispoDAO Dispo
        {
            get { return dispo; }
            set { dispo = value; }
        }


        public RendezVousDAO RDV
        {
            get { return rdv; }
            set { rdv = value; }
        }



    }
}