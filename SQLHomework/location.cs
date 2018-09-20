using System;
using System.Collections.Generic;
using System.Text;

namespace SQLHomework
{
    public class Location
    {
        public int LocationID { get; set; }
        public string Name { get; set; }
        public double CostRate { get; set; }
        public decimal Availability { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
