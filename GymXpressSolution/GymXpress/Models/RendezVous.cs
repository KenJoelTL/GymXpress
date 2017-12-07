using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymXpress.Models
{
    public class RendezVous
    {
        private int idRDV;
        private int idDispo;
        private int idClient;
        private int idEntraineur;

        public int IdRDV
        {
            get { return idRDV; }
            set { idRDV = value; }
        }

        public int IdDispo
        {
            get { return idDispo; }
            set { idDispo = value; }
        }

        public int IdClient
        {
            get { return idClient; }
            set { idClient = value; }
        }

        public int IdEntraineur
        {
            get { return idEntraineur; }
            set { idEntraineur = value; }
        }





    }
}