using System;

namespace SQLHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            LocationRepository location = new LocationRepository();

            Console.WriteLine("Creating new Location enrty...");

            location.CreateLocation("Beard Oil", 1.50, 15.00m, DateTime.Now);

            Console.WriteLine("Transaction Completed!!!");

            Console.ReadLine();
        }
    }
}
