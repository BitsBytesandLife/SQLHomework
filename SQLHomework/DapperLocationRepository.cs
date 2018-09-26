using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Text;
using Dapper;
using System.Linq;

namespace SQLHomework
{
    class DapperLocationRepository : IRepository
    {
        private static string connectionString = "Server=localhost;Database=adventureworks;Uid=root;Pwd=password;";

        public void CreateLocation(string n, double c, decimal a, DateTime m)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                conn.Execute("INSERT INTO location (Name, CostRate, Availability,ModifiedDate) " +
                             "VALUES (@name, @costrate,@availability,@modifiedate)", new { name = n,costrate = c, availability = a, modifiedate = DateTime.Now });
            }
        }

        public List<Location> GetLocation()
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                return conn.Query<Location>("SELECT LocationId, Name, CostRate, Availability, ModifiedDate FROM location;").ToList();     
            }
        }

        public void UpdateLocation(Location l)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                conn.Execute("UPDATE location SET Name = @name, CostRate = @costrate, " +
                                  "Availability = @availability,ModifiedDate =  @modifiedate " +
                                  "WHERE LocationID = @locationID", new { name = l.Name, costrate = l.CostRate, availability = l.Availability, @modifiedate = DateTime.Now, @locationID = l.LocationID });
            }
            
        }

        public void DeleteLocation(int LocationId)
        {
            using (var conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                conn.Execute("DELETE FROM location WHERE LocationId = @lId;", new { lId = LocationId });
            }
        }
       
    }
}
