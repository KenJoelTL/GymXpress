using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GymXpress.Models.DAO
{
    public class RendezVousDAO
    {

        private List<RendezVous> rdvListe = new List<RendezVous>();
        private MySqlConnection cnx;

        public RendezVousDAO(MySqlConnection cnx)
        {
            this.cnx = cnx;
        }

        public List<RendezVous> ToList()
        {
            MySqlDataReader rdr = null;

            string stm = "SELECT * FROM rendezvous";

            try
            {
                MySqlCommand cmd = new MySqlCommand(stm, cnx);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    rdvListe.Add(new RendezVous()
                    {
                        IdRDV = rdr.GetInt32(0),
                        IdDispo = rdr.GetInt32(1),
                        IdClient = rdr.GetInt32(2),
                        IdEntraineur = rdr.GetInt32(3)
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

            return rdvListe;
        }

        public void Add(RendezVous rdv)
        {

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cnx;
                cmd.CommandText = "INSERT INTO rendezvous(ID_DISPO, ID_CLIENT, ID_ENTRAINEUR) VALUES(@IdDispo, @IdClient@, IdEntraineur)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@IdDispo", rdv.IdDispo);
                cmd.Parameters.AddWithValue("@IdClient", rdv.IdClient);
                cmd.Parameters.AddWithValue("@IdEntraineur", rdv.IdEntraineur);


                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }

        }

        public void Update(RendezVous rdv)
        {

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cnx;
                cmd.CommandText = "UPDATE rendezvous SET ID_DISPO = @IdDispo, ID_CLIENT= @IdClient, ID_ENTRAINEUR= @IdEntraineur, WHERE ID_RENDEZ_VOUS= @IdDispo";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@IdRendezVous", rdv.IdRDV);
                cmd.Parameters.AddWithValue("@IdDispo", rdv.IdDispo);
                cmd.Parameters.AddWithValue("@IdClient", rdv.IdClient);
                cmd.Parameters.AddWithValue("@IdEntraineur", rdv.IdEntraineur);
                
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }

        }

    }
}