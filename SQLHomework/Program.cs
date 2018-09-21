using System;

namespace SQLHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            LocationRepository location = new LocationRepository();

            //Console.WriteLine("Creating new Location enrty...");

            //location.CreateLocation("Beard Oil", 1.50, 15.00m, DateTime.Now);

            //Console.WriteLine("Transaction Completed!!!");

            Location l = new Location();
            l.LocationID = 61;
            l.Name = "Kingz of Kingz Beard Oil";
            l.CostRate = 2.50;
            l.Availability = 20.50m;
            l.ModifiedDate = DateTime.Now;

            Console.WriteLine("Updating Location Table.....");
            //Udate All fields
            //location.UpdateLocation(l);

            //Update Name
            //location.UpdateLocation("Kingz of Kingz Beard Club Beard Oil",61,DateTime.Now);

            //Update CostRate
            //location.UpdateLocation(3.15, 61, DateTime.Now);

            //Update Availability
            location.UpdateLocation(25.50m, 61, DateTime.Now);

            Console.WriteLine("Transaction Completed!!!");

            Console.ReadLine();
        }
    }
}
