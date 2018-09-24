using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace SQLHomework
{
    class Program
    {
        private static LocationRepository locRepo = new LocationRepository();
        private static List<Location> ReadLocations = locRepo.GetLocation();
        

        static void Main(string[] args)
        {
            Console.WriteLine("Before running the console appliaction look up the /n" +
                              "Auto-Increment in Location table. Change the value for the new run /n" +
                              "of the applcation. The current Auto-Increment value is 74 ");
            //Setting Application flies
            ConsoleAppSettings();
            //Creating records
            CreatingRecords();
            //Reading records
            ReadingAllLocations();
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
            //Create LocationId = 74
            locRepo.CreateLocation("Beard Oil", 1.50, 15.00m, DateTime.Now);
            //Create LocationId = 75
            locRepo.CreateLocation("Test 1", 2.50, 4.00m, DateTime.Now);
            //Create LocationId = 76
            locRepo.CreateLocation("Test 2", 3.00, 8.50m, DateTime.Now);
           
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
                LocationID = 74,
                Name = "Kingz of Kingz Beard Oil",
                CostRate = 2.50,
                Availability = 20.50m,
                ModifiedDate = DateTime.Now
            };

            ShowCrudHeading("U (Updating records in the table)");

            Console.WriteLine("This will update All fields");
            ShowUpdateResults(74, "Before the update...", ConsoleColor.White, ConsoleColor.White);
            locRepo.UpdateLocation(l);
            ShowUpdateResults(74, "Updated the all fields", ConsoleColor.Yellow, ConsoleColor.White);
            locRepo.UpdateLocation("Kingz of Kingz Beard Club Beard Oil", 61, DateTime.Now);
            ShowUpdateResults(74, "Updated the Name field", ConsoleColor.Yellow, ConsoleColor.White);
            locRepo.UpdateLocation(3.15, 61, DateTime.Now);
            ShowUpdateResults(74, "Updated the CostRate field", ConsoleColor.Yellow, ConsoleColor.White);
            locRepo.UpdateLocation(25.50m, 61, DateTime.Now);
            ShowUpdateResults(74, "Updated the Availability field", ConsoleColor.Yellow, ConsoleColor.White);
        }


        /// <summary>
        ///    This method outputs messages to the screen,
        ///    changes the Console.ForegroundColor,
        ///    calls locRepo.GetOneLocation(int LocationID),
        ///    and Console.ForegroundColor again. in 
        ///    most cases it will change it back white.
        /// </summary>
        public static void ShowUpdateResults(int locationID, string message, ConsoleColor colorChange, ConsoleColor colorReset)
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
            locRepo.DeleteLocation(74);
            locRepo.IsRecordInDatabase(74);

            //Deleteing a record based on Name
            Console.WriteLine("Deleting in the record location table on Name");
            locRepo.DeleteLocation("Test 1");
            locRepo.IsRecordInDatabase(75);

            //Deleteing a record based on LocationID and Name 
            Console.WriteLine("Deleting in the record location table on LocationID and Name");
            locRepo.DeleteLocation(76, "Test 2");
            locRepo.IsRecordInDatabase(76);


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