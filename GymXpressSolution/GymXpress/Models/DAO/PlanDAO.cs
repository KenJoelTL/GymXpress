﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymXpress.Models.DAO {
    public class PlanDAO {

        private List<Plan> plansListe = new List<Plan>();
        private MySqlConnection cnx;

        public PlanDAO(MySqlConnection cnx) {
            this.cnx = cnx;
        }

        public List<Plan> ToList() {
            MySqlDataReader rdr = null;

            string stm = "SELECT * FROM plan_entrainement";

            try {
                MySqlCommand cmd = new MySqlCommand(stm, cnx);
                rdr = cmd.ExecuteReader();

                while (rdr.Read()) {
                    plansListe.Add(new Plan() {
                        IdPlan = rdr.GetInt32(0),
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

        public void Add(Plan plan) {

            try {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cnx;
                cmd.CommandText = "INSERT INTO plan_entrainement(ID_COMPTE, ID_ENTRAINEUR, NOM) VALUES(@IdCompte, @IdEntraineur, @Nom)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@IdCompte", plan.IdCompte);
                cmd.Parameters.AddWithValue("@IdEntraineur", plan.IdEntraineur);
                cmd.Parameters.AddWithValue("@Nom", plan.Nom);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex) {
                Console.WriteLine("Error: {0}", ex.ToString());

            }

        }

        public void Update(Plan plan) {

            try {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cnx;
                cmd.CommandText = "UPDATE plan_entrainement SET NOM = @Nom, ID_COMPTE = @IdCompte, ID_ENTRAINEUR = @IdEntraineur WHERE ID_PLAN_ENTRAINEMENT = @IdPlan";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Nom", plan.Nom);
                cmd.Parameters.AddWithValue("@IdCompte", plan.IdCompte);
                cmd.Parameters.AddWithValue("@IdEntraineur", plan.IdEntraineur);
                cmd.Parameters.AddWithValue("@IdPlan", plan.IdPlan);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex) {
                Console.WriteLine("Error: {0}", ex.ToString());

            }

        }

        public void Remove(Plan plan)
        {

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cnx;
                cmd.CommandText = "DELETE FROM plan_entrainement WHERE ID_PLAN_ENTRAINEMENT = @IdPlan";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Nom", plan.Nom);
                cmd.Parameters.AddWithValue("@IdCompte", plan.IdCompte);
                cmd.Parameters.AddWithValue("@IdEntraineur", plan.IdEntraineur);
                cmd.Parameters.AddWithValue("@IdPlan", plan.IdPlan);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }

        }



    }


}