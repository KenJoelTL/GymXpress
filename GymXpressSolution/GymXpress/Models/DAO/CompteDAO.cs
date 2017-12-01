﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymXpress.Models.DAO
{
    public class CompteDAO
    {
        private List<Compte> comptesListe = new List<Compte>();
        private MySqlConnection cnx;

        public CompteDAO(MySqlConnection cnx)
        {
            this.cnx = cnx;
        }

        public List<Compte> ToList()
        {
            MySqlDataReader rdr = null;

            string stm = "SELECT * FROM compte";

            try
            {
                MySqlCommand cmd = new MySqlCommand(stm, cnx);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    comptesListe.Add(new Compte()
                    {
                        Role = rdr.GetInt32(0),
                        Courriel = rdr.GetString(1),
                        MotPasse = rdr.GetString(2)
                    });
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {
                rdr.Close();
            }

            return comptesListe;
        }

        public void Add(Compte compte)
        {

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cnx;
                cmd.CommandText = "INSERT INTO compte(ROLE, COURRIEL, MOT_PASSE) VALUES(@Role, @Courriel, @MotPasse)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Role", compte.Role);
                cmd.Parameters.AddWithValue("@Courriel", compte.Courriel);
                cmd.Parameters.AddWithValue("@MotPasse", compte.MotPasse);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }

        }
    }
}