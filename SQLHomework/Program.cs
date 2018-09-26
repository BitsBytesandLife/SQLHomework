using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace SQLHomework
{
    class Program
    {
        private static LocationRepository locRepo = new LocationRepository();
        private static DapperLocationRepository dapperLocRepo = new DapperLocationRepository();
        private static List<Location> ReadLocations = locRepo.GetLocation();
        

        static void Main(string[] args)
        {
            Console.WriteLine("Before running the console application look up the /n" +
                              "Auto-Increment in Location table. Change the value for the new run /n" +
                              "of the application. The current Auto-Increment value is 90 /n");
            //Setting Application flies
            ConsoleAppSettings();


            //Reading records
            ReadingAllLocations();

            //Creating records
            CreatingRecords();
            
            //Updating a record
            UpdateTableARecord();
            
            //Delete record(s)
            DeleteRecords();

            Console.ReadLine();
        }

        /// <summary>
        ///     Display the content from the Location table>
        ///     Query: SELECT * FROM location.
        /// </summary>
        private static void ReadingAllLocations()
        {
            ShowCrudHeading("R (Reading the table.)");

            foreach (Location readlocation in ReadLocations)
            {
                Console.WriteLine($"LocationID = {readlocation.LocationID} Name = {readlocation.Name} CostRate = {readlocation.CostRate}\n" +
                                  $"Availability = {readlocation.Availability} ModifiedDate = {readlocation.ModifiedDate}\n");
            }
        }

        /// <summary>
        ///     This method will create and insert records in the location table.
        /// </summary>
        private static void CreatingRecords()
        {

            ShowCrudHeading("C (Creating records in the table)");
            //Create LocationId = 90
            locRepo.CreateLocation("Beard Oil", 1.50, 15.00m, DateTime.Now);
            ShowQueryResults(90, "Record inserted...", ConsoleColor.DarkGreen, ConsoleColor.White);
            //Create LocationId = 91
            locRepo.CreateLocation("Test 1", 2.50, 4.00m, DateTime.Now);
            ShowQueryResults(91, "Record inserted...", ConsoleColor.DarkGreen, ConsoleColor.White);
            //Create LocationId = 92
            locRepo.CreateLocation("Test 2", 3.00, 8.50m, DateTime.Now);
            ShowQueryResults(92, "Record inserted...", ConsoleColor.DarkGreen, ConsoleColor.White);
            //Create from Dapper LocationId = 81
            dapperLocRepo.CreateLocation("Dapper Test Location",4.00, 7.56m, DateTime.Now);
            ShowQueryResults(93, "Dapper record inserted...", ConsoleColor.Magenta, ConsoleColor.White);

        }

        /// <summary>
        ///     This method will update the location table.
        ///     It will show all of the differnt ways to update the location table.
        ///     Update all fields, Update the Name, Update the CostRate, Update Availability
        /// </summary>
        private static void UpdateTableARecord()
        {
            Location l = new Location
            {
                LocationID = 90,
                Name = "Kingz of Kingz Beard Oil",
                CostRate = 2.50,
                Availability = 20.50m,
                ModifiedDate = DateTime.Now
            };

            //For Dapper
            Location l2 = new Location
            {
                LocationID = 93,
                Name = "Dapper Location",
                CostRate = 4.50,
                Availability = 7.50m,
                ModifiedDate = DateTime.Now
            };

            ShowCrudHeading("U (Updating records in the table)");

            Console.WriteLine("This will update All fields");
            ShowQueryResults(90, "Before the update...", ConsoleColor.White, ConsoleColor.White);
            locRepo.UpdateLocation(l);
            ShowQueryResults(90, "Updated the all fields", ConsoleColor.Yellow, ConsoleColor.White);
            locRepo.UpdateLocation("Kingz of Kingz Beard Club Beard Oil", 61, DateTime.Now);
            ShowQueryResults(90, "Updated the Name field", ConsoleColor.Yellow, ConsoleColor.White);
            locRepo.UpdateLocation(3.15, 61, DateTime.Now);
            ShowQueryResults(90, "Updated the CostRate field", ConsoleColor.Yellow, ConsoleColor.White);
            locRepo.UpdateLocation(25.50m, 61, DateTime.Now);
            ShowQueryResults(90, "Updated the Availability field", ConsoleColor.Yellow, ConsoleColor.White);
            ShowQueryResults(93,"Dapper Before the update...", ConsoleColor.Cyan, ConsoleColor.White);
            dapperLocRepo.UpdateLocation(l2);
            ShowQueryResults(93, "Dapper Before the update...", ConsoleColor.Magenta, ConsoleColor.White);
        }


        /// <summary>
        ///    This method outputs messages to the screen,
        ///    changes the Console.ForegroundColor,
        ///    calls locRepo.GetOneLocation(int LocationID),
        ///    and Console.ForegroundColor again. in 
        ///    most cases it will change it back white.
        /// </summary>
        public static void ShowQueryResults(int locationID, string message, ConsoleColor colorChange, ConsoleColor colorReset)
        {
            Console.WriteLine("Querying the database.... ");
            Console.WriteLine(message);
            Console.ForegroundColor = colorChange;
            locRepo.GetOneLocation(locationID);
            Console.ForegroundColor = colorReset;
            Console.WriteLine();
        }

        /// <summary>
        ///     This method will delete records in location table.
        ///     It will show all of the differnt ways it will delete the location table.
        ///     Delete the record by LocationId, Delete the record by Name, Delete the record by LocationID and Name
        /// </summary>
        public static void DeleteRecords()
        {
            ShowCrudHeading("D (Deleting records in the table)");
            //Deleting a record based on LocationId
            Console.WriteLine("Deleting in the record location table on LocationID");
            locRepo.DeleteLocation(90);
            locRepo.IsRecordInDatabase(90);

            //Deleting a record based on Name
            Console.WriteLine("Deleting in the record location table on Name");
            locRepo.DeleteLocation("Test 1");
            locRepo.IsRecordInDatabase(91);

            //Deleting a record based on LocationID and Name 
            Console.WriteLine("Deleting in the record location table on LocationID and Name");
            locRepo.DeleteLocation(92, "Test 2");
            locRepo.IsRecordInDatabase(92);

            Console.WriteLine("Dapper Deleting in the record location table on LocationID");
            dapperLocRepo.DeleteLocation(93);
            locRepo.IsRecordInDatabase(93);

        }

        /// <summary>
        ///     This methond outputs text to the screen.
        /// </summary>
        public static void ShowCrudHeading(string message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"This the {message} in CRUD.");
            Console.ForegroundColor = ConsoleColor.White;

        }

        public static void ConsoleAppSettings()
        {
            var config = new Microsoft.Extensions.Configuration.ConfigurationBuilder()

                .SetBasePath(Directory.GetCurrentDirectory())

                .AddJsonFile("appsettings.json")

#if DEBUG

                .AddJsonFile("appsettings.Debug.json")

#else

                .AddJsonFile("appsettings.Release.json")

#endif

                .Build();

            string connString = config.GetConnectionString("DefaultConnection");

        }
    }

}