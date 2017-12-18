using MySql.Data.MySqlClient;
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
                        IdCompte = rdr.GetInt32(0),
                        Role = rdr.GetInt32(1),
                        Courriel = rdr.GetString(2),
                        MotPasse = rdr.GetString(3),
                        Prenom = rdr.GetString(4),
                        Nom = rdr.GetString(5)
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
                cmd.CommandText = "INSERT INTO compte(ROLE, COURRIEL, MOT_PASSE, PRENOM, NOM) VALUES(@Role, @Courriel, @MotPasse, @Prenom, @Nom)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@Role", compte.Role);
                cmd.Parameters.AddWithValue("@Courriel", compte.Courriel);
                cmd.Parameters.AddWithValue("@MotPasse", compte.MotPasse);
                cmd.Parameters.AddWithValue("@Prenom", compte.Prenom);
                cmd.Parameters.AddWithValue("@Nom", compte.Nom);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }

        }

        public void Update(Compte compte)
        {

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cnx;
                cmd.CommandText = "UPDATE compte SET ROLE = @Role, COURRIEL = @Courriel, MOT_PASSE = @MotPasse, PRENOM = @Prenom, NOM = @Nom WHERE ID_COMPTE = @IdCompte";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@IdCompte", compte.IdCompte);
                cmd.Parameters.AddWithValue("@Role", compte.Role);
                cmd.Parameters.AddWithValue("@Courriel", compte.Courriel);
                cmd.Parameters.AddWithValue("@MotPasse", compte.MotPasse);
                cmd.Parameters.AddWithValue("@Prenom", compte.Prenom);
                cmd.Parameters.AddWithValue("@Nom", compte.Nom);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
        }


        public void Remove(Compte compte)
        {

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cnx;
                cmd.CommandText = "DELETE FROM compte WHERE ID_COMPTE = @IdCompte";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@IdCompte", compte.IdCompte);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
        }

        public void Clear()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cnx;
                cmd.CommandText = "DELETE FROM compte";

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
        }


    }
}