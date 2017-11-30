using GymXpress.Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymXpress.Models
{
    public class BddContext : DbContext
    {
      

        private CompteDAO compte;

        public BddContext() : base()
        {
            Compte = new CompteDAO(cnx);
        }

        public CompteDAO Compte
        {
            get
            {
                return compte;
            }

            set
            {
                compte = value;
            }
        }
    }
}