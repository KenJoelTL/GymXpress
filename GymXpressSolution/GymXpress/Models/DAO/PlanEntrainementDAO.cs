using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymXpress.Models.DAO {
    public class PlanEntrainementDAO {

        private List<PlanEntrainement> plansListe = new List<PlanEntrainement>();
        private MySqlConnection cnx;

        public PlanEntrainementDAO(MySqlConnection cnx) {
            this.cnx = cnx;
        }

        public List<PlanEntrainement> ToList() {
            MySqlDataReader rdr = null;

            string stm = "SELECT * FROM plan_entrainement";

            try {
                MySqlCommand cmd = new MySqlCommand(stm, cnx);
                rdr = cmd.ExecuteReader();

                while (rdr.Read()) {
                    plansListe.Add(new PlanEntrainement() {
                        IdPlanEntrainement = rdr.GetInt32(0),
                        IdCompte = rdr.GetInt32(1),
                        IdEntraineur = rdr.GetInt32(2),
                        Nom = rdr.GetString(3)
                    });
                }
            }
            catch (MySqlException ex) {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally {
                rdr.Close();
            }

            return plansListe;
        }

        public void Add(PlanEntrainement planEntrainement) {

            try {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cnx;
                cmd.CommandText = "INSERT INTO plan_entrainement(ID_COMPTE, ID_ENTRAINEUR, NOM) VALUES(@IdCompte, @IdEntraineur, @Nom)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@IdCompte", planEntrainement.IdCompte);
                cmd.Parameters.AddWithValue("@IdEntraineur", planEntrainement.IdEntraineur);
                cmd.Parameters.AddWithValue("@Nom", planEntrainement.Nom);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex) {
                Console.WriteLine("Error: {0}", ex.ToString());

            }

        }

        public void Update(PlanEntrainement planEntrainement) {

            try {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cnx;
                cmd.CommandText = "UPDATE plan_entrainement SET NOM = @Nom, ID_COMPTE = @IdCompte, ID_ENTRAINEUR = @IdEntraineur WHERE ID_PLAN_ENTRAINEMENT = @IdPlanEntrainement";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Nom", planEntrainement.Nom);
                cmd.Parameters.AddWithValue("@IdCompte", planEntrainement.IdCompte);
                cmd.Parameters.AddWithValue("@IdEntraineur", planEntrainement.IdEntraineur);
                cmd.Parameters.AddWithValue("@IdPlanEntrainement", planEntrainement.IdPlanEntrainement);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex) {
                Console.WriteLine("Error: {0}", ex.ToString());

            }

        }


    }


}
