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
        private PlanEntrainementDAO planEntrainement;


    //---------------------------------------------
        // Constructor |
        public BddContext() : base()
        {
            Compte = new CompteDAO(cnx);
            PlanEntrainement = new PlanEntrainementDAO(cnx);
        }


       
    //---------------------------------------------
        // Getters | Setters

        public CompteDAO Compte{
            get{ return compte; }
            set{ compte = value; }
        }

        public PlanEntrainementDAO PlanEntrainement {
            get { return planEntrainement; }
            set { planEntrainement = value; }
        }

    }
}