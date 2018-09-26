using System;
using System.Collections.Generic;
using System.Text;

namespace SQLHomework
{
   public interface IRepository
    {
        List<Location> GetLocation();

        void CreateLocation(string n, double c, decimal a, DateTime m);
        void UpdateLocation(Location l);
        void DeleteLocation(int LocationId);
    }
}
