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


    //---------------------------------------------
        // Constructor |
        public BddContext() : base()
        {
            Compte = new CompteDAO(cnx);
            Plan = new PlanDAO(cnx);
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

    }
}