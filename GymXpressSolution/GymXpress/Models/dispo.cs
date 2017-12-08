using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymXpress.Models
{
    public class Dispo
    {
        private int idDispo;
        private int idEntraineur;
        private String heureDebut;
        private String heureFin;
        private String date;


        public int IdDispo
        {
            get { return idDispo; }
            set { idDispo = value; }
        }

        public int IdEntraineur
        {
            get { return idEntraineur; }
            set { idEntraineur = value; }
        }

        public String HeureDebut
        {
            get { return heureDebut; }
            set { heureDebut = value; }
        }
        

        public String HeureFin
        {
            get { return heureFin; }
            set { heureFin = value; }
        }
        
        public String Date
        {
            get { return date; }
            set { date = value; }
        }



    }
}