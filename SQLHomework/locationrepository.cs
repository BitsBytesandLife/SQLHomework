using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;

namespace SQLHomework
{
    public class LocationRepository
    {
        private static string connectionString = "Server=localhost;Database=adventureworks;Uid=root;Pwd=password;";

        /// <summary>
        /// CreateLocation method takes four parameters  (n = Name, c = CostRate, a = Availability, d = ModifiedDate)
        /// And creates a Location within our database with that Name,CostRate, Availability, and ModifiedDate.
        /// </summary>
        public void CreateLocation(string n, double c, decimal a, DateTime m)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO location (Name, CostRate, Availability,ModifiedDate) " +
                                   "VALUES (@name, @costrate,@availability,@modifiedate)";
                cmd.Parameters.AddWithValue("name", n);
                cmd.Parameters.AddWithValue("costrate", c);
                cmd.Parameters.AddWithValue("availability", a);
                cmd.Parameters.AddWithValue("modifiedate", m);
                cmd.ExecuteNonQuery();

            }
        }





    }       
}
