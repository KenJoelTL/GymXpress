using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GymXpress.Models.DAO
{
    public class DispoDAO
    {
        private List<Dispo> dispoListe = new List<Dispo>();
        private MySqlConnection cnx;

        public DispoDAO(MySqlConnection cnx)
        {
            this.cnx = cnx;
        }

        public List<Dispo> ToList()
        {
            MySqlDataReader rdr = null;

            string stm = "SELECT * FROM dispo";

            try
            {
                MySqlCommand cmd = new MySqlCommand(stm, cnx);
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    dispoListe.Add(new Dispo()
                    {
                        IdDispo = rdr.GetInt32(0),
                        IdEntraineur = rdr.GetInt32(1),
                        HeureDebut = rdr.GetString(2),
                        HeureFin = rdr.GetString(3),
                        Date = rdr.GetString(4)
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

            return dispoListe;
        }

        public void Add(Dispo dispo)
        {

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cnx;
                cmd.CommandText = "INSERT INTO dispo(ID_ENTRAINEUR, HEURE_DEBUT, HEURE_FIN, DATE) VALUES(@IdEntraineur, @HeureDebut, @HeureFin, @Date)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@IdEntraineur", dispo.IdEntraineur);
                cmd.Parameters.AddWithValue("@HeureDebut", dispo.HeureDebut);
                cmd.Parameters.AddWithValue("@HeureFin", dispo.HeureFin);
                cmd.Parameters.AddWithValue("@Date", dispo.Date);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }

        }

        public void Update(Dispo dispo)
        {

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cnx;
                cmd.CommandText = "UPDATE dispo SET ID_ENTRAINEUR = @IdEntraineur, HEURE_DEBUT= @HeureDebut, HEURE_FIN = @HeureFin, DATE = @Date WHERE ID_DISPO = @IdDispo";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@IdDispo", dispo.IdDispo);
                cmd.Parameters.AddWithValue("@IdEntraineur", dispo.IdEntraineur);
                cmd.Parameters.AddWithValue("@HeureDebut", dispo.HeureDebut);
                cmd.Parameters.AddWithValue("@HeureFin", dispo.HeureFin);
                cmd.Parameters.AddWithValue("@Date", dispo.Date);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }

        }

        public void Remove(Dispo dispo) {

            try {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cnx;
                cmd.CommandText = "DELETE FROM dispo WHERE ID_DISPO = @IdDispo";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@IdDispo", dispo.IdDispo);

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex) {
                Console.WriteLine("Error: {0}", ex.ToString());

            }

        }

        public void Clear()
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = cnx;
                cmd.CommandText = "DELETE FROM dispo";

                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
        }



    }
}