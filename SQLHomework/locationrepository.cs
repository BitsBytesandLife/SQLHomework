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
        ///     This method return the records from the location table.
        ///     Query: SELECT * FROM location 
        /// </summary>
        public List<Location> GetLocation()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT LocationId, Name, CostRate, Availability, ModifiedDate FROM location;";
                MySqlDataReader reader = cmd.ExecuteReader();


                List<Location> locations = new List<Location>();
                while (reader.Read())
                {
                    Location loc = new Location();
                    loc.LocationID = (int)reader["LocationID"];
                    loc.Name = reader["Name"].ToString();
                    loc.CostRate = (double)reader["CostRate"];
                    loc.Availability = (decimal)reader["Availability"];
                    loc.ModifiedDate = (DateTime)reader["ModifiedDate"];

                    locations.Add(loc);
                }
                return locations;
            }
        }

        /// <summary>
        ///     This method return the record from the location table.
        ///     Parameter: int ID 
        ///     Query: SELECT * FROM location WHERE LocationID = ID
        /// </summary>
        public void GetOneLocation(int ID)
        {
            MySqlConnection conn = new MySqlConnection(connectionString);

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT LocationId, Name, CostRate, Availability, ModifiedDate " +
                                  "FROM location " +
                                  "WHERE LocationID = @locationid;";
                cmd.Parameters.AddWithValue("locationid", ID);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Location loc = new Location();
                    loc.LocationID = (int)reader["LocationID"];
                    loc.Name = reader["Name"].ToString();
                    loc.CostRate = (double)reader["CostRate"];
                    loc.Availability = (decimal)reader["Availability"];
                    loc.ModifiedDate = (DateTime)reader["ModifiedDate"];


                    Console.WriteLine($"LocationID = {loc.LocationID} Name = {loc.Name} CostRate = {loc.CostRate}\n" +
                                  $"Availability = {loc.Availability} ModifiedDate = {loc.ModifiedDate}\n");

                }
            }
        }


        /// <summary>
        ///     This method returns the last record in the location table
        ///     The table is ordered by locationID.
        /// </summary>
        public int GetLastLocationID()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            var lastLocationID = 0;

            using (conn)
            {
                conn.Open();

                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT LocationID " +
                                  "FROM location " +
                                  "ORDER BY LocationID desc " +
                                  "LIMIT 1";

                return lastLocationID = (int)cmd.ExecuteScalar();
            }
        }

        /// <summary>
        ///     CreateLocation method takes four parameters  (n = Name, c = CostRate, a = Availability, d = ModifiedDate)
        ///     And creates a Location within our database with that Name,CostRate, Availability, and ModifiedDate.
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
        ///     UpdateLocation method updates the CostRate field in the location table
        ///     takes Location object parameters 
        ///     And updates a Location within our database with that all fields.
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
        ///     UpdateLocation method updates the Name  field in the location table
        ///     takes three parameters  (n = Name,  l = LocationID, d = ModifiedDate)
        ///     And updates a Location within our database with that a new Name and ModifiedDate.
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
        ///     UpdateLocation method updates the CostRate field in the location table
        ///     takes three parameters  (c = CostRate,  l = LocationID, d = ModifiedDate)
        ///     And updates a Location within our database with that new CostRate and ModifiedDate.
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

        /// <summary>
        ///     DeleteLocation method deletes and record from the location table
        ///     takes one parameters  (LocationID)
        ///     Deletes and record with a specific LocationId .
        /// </summary>
        public void DeleteLocation(int LocationId)

        {

            using (var conn = new MySqlConnection(connectionString))

            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = "DELETE FROM Location WHERE LocationId = @lId;";
                cmd.Parameters.AddWithValue("lId", LocationId);
                cmd.ExecuteNonQuery();
            }

        }

        /// <summary>
        ///     DeleteLocation method deletes and record from the location table
        ///     takes one parameters  (Name)
        ///     Deletes and record with a specific Name
        ///     Warning: This is deleting records matching wildcard "%" + name + "%".
        ///              This may result in multiple records may me deleted.
        ///              The preferred overloaded method DeleteLocation(string name, int LocationId)
        /// </summary>
        public void DeleteLocation(string name)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = "DELETE FROM Location WHERE Name LIKE @name;";
                cmd.Parameters.AddWithValue("name", "%" + name + "%");
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        ///     DeleteLocation method deletes and record from the location table
        ///     takes one parameters  (LocationID and Name)
        ///     Deletes and record with a specific LocationId and Name .
        /// </summary>
        public void DeleteLocation(int LocationId, string name)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = "DELETE FROM location WHERE Name LIKE @name AND LocationId = @lid;";
                cmd.Parameters.AddWithValue("name", "%" + name + "%");
                cmd.Parameters.AddWithValue("lid", LocationId);
                cmd.ExecuteNonQuery();
            }
        }

        public void IsRecordInDatabase(int LocationId)

        {

            using (var conn = new MySqlConnection(connectionString))

            {
                conn.Open();
                var cmd = conn.CreateCommand();

                cmd.CommandText = "SELECT * FROM Location WHERE LocationId = @lId;";
                cmd.Parameters.AddWithValue("lId", LocationId);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("Record is in the Database!!!");
                    Console.ForegroundColor = ConsoleColor.Green;
                    GetOneLocation(LocationId);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Record does not exists");
                    Console.ForegroundColor = ConsoleColor.White;
                }

            }
        }
    }
}