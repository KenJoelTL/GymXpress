using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace GymXpress.Models
{
    public class DbContext
    {
        protected static MySqlConnection cnx;
        public DbContext()
        {
            string cs = ConfigurationManager.ConnectionStrings["MySQLConnection"].ConnectionString;

            try
            {
                cnx = new MySqlConnection(cs);
                cnx.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }
        }
        public void Dispose()
        {
            if (cnx != null)
            {
                cnx.Close();
            }
        }
    }
}