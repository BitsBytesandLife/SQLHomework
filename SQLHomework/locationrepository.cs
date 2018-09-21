﻿using System;
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

        /// <summary>
        /// UdateLocation method updates the CostRate field in the location table
        /// takes Location object parameters 
        /// And updates a Location within our database with that all fields.
        /// </summary>
        public void UpdateLocation(Location l)
        {
            var conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE location SET Name = @name, CostRate = @costrate, " +
                                  "Availability = @availability,ModifiedDate =  @modifiedate " +
                                  "WHERE LocationID = @locationID";
                cmd.Parameters.AddWithValue("name", l.Name);
                cmd.Parameters.AddWithValue("costrate", l.CostRate);
                cmd.Parameters.AddWithValue("availability", l.Availability);
                cmd.Parameters.AddWithValue("modifiedate", l.ModifiedDate);
                cmd.Parameters.AddWithValue("LocationID", l.LocationID);
                cmd.ExecuteNonQuery();
            }

        }

        /// <summary>
        /// UdateLocation method updates the Name  field in the location table
        /// takes three parameters  (n = Name,  l = LocationID, d = ModifiedDate)
        /// And updates a Location within our database with that a new Name and ModifiedDate.
        /// </summary>
        public void UpdateLocation(string n, int l, DateTime m)
        {
            var conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE location SET Name = @name, ModifiedDate =  @modifiedate " +
                                  "WHERE LocationID = @locationID";
                cmd.Parameters.AddWithValue("name", n);
                cmd.Parameters.AddWithValue("modifiedate", m);
                cmd.Parameters.AddWithValue("LocationID", l);
                cmd.ExecuteNonQuery();
            }

        }

        /// <summary>
        /// UdateLocation method updates the CostRate field in the location table
        /// takes three parameters  (c = CostRate,  l = LocationID, d = ModifiedDate)
        /// And updates a Location within our database with that new CostRate and ModifiedDate.
        /// </summary>
        public void UpdateLocation(double c, int l, DateTime m)
        {
            var conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE location SET CostRate = @costrate, ModifiedDate =  @modifiedate " +
                                  "WHERE LocationID = @locationID";
                cmd.Parameters.AddWithValue("costrate", c);
                cmd.Parameters.AddWithValue("modifiedate", m);
                cmd.Parameters.AddWithValue("LocationID", l);
                cmd.ExecuteNonQuery();
            }

        }

        /// <summary>
        /// UdateLocation method updates the CostRate field in the location table
        /// takes three parameters  (c = CostRate,  l = LocationID, d = ModifiedDate)
        /// And update a Location within our database with that new Availability and ModifiedDate.
        /// </summary>
        public void UpdateLocation(decimal a, int l, DateTime m)
        {
            var conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                var cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE location SET Availability = @availability, ModifiedDate =  @modifiedate " +
                                  "WHERE LocationID = @locationID";
                cmd.Parameters.AddWithValue("availability", a);
                cmd.Parameters.AddWithValue("modifiedate", m);
                cmd.Parameters.AddWithValue("LocationID", l);
                cmd.ExecuteNonQuery();
            }

        }



    }
}
