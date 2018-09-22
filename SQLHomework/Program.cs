using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;

namespace SQLHomework
{
    class Program
    {
        static void Main(string[] args)
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

            LocationRepository locRepo = new LocationRepository();

            List<Location> ReadLocations = locRepo.GetLocation();



            foreach (Location readlocation in ReadLocations)
            {
                Console.WriteLine($"LocationID = {readlocation.LocationID} Name = {readlocation.Name} CostRate = {readlocation.CostRate}\n" +
                                  $"Availability = {readlocation.Availability} ModifiedDate = {readlocation.ModifiedDate}\n");
                //Console.WriteLine($"{product.Id} {product.Name}------${product.Price}\n");
            }





            //Console.WriteLine("Creating new Location enrty...");

            //locRepo.CreateLocation("Beard Oil", 1.50, 15.00m, DateTime.Now);
            //Console.WriteLine("Transaction Completed!!!");
            // Console.ReadLine();
            /*
            Location l = new Location();
            l.LocationID = 61;
            l.Name = "Kingz of Kingz Beard Oil";
            l.CostRate = 2.50;
            l.Availability = 20.50m;
            l.ModifiedDate = DateTime.Now;
            */

            //Console.WriteLine("Updating Location Table.....");
            //Udate All fields
            //locRepo.UpdateLocation(l);


            locRepo.UpdateLocation("Kingz of Kingz Beard Club Beard Oil",61,DateTime.Now);

            //Update CostRate
            //locRepo.UpdateLocation(3.15, 61, DateTime.Now);

            //Update Availability
            //locRepo.UpdateLocation(25.50m, 61, DateTime.Now);


            Console.WriteLine("Deleting an record from the Location Table");
            //Deleting a record based on LocationId
            //locRepo.DeleteLocation(61);

            //Deleteing a record based on LocationID
            //locRepo.DeleteLocation("Beard Oil");

            //locRepo.DeleteLocation(64,"Beard Oil");


            Console.WriteLine("Transaction Completed!!!");

            Console.ReadLine();
        }
    }
}
