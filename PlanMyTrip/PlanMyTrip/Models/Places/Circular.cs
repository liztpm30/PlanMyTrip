using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Places
{
    public class Circular
    {
        public double Radius { get; set; }

        public Coordinates Coordinates { get; set; }

        public override string ToString()
        {
            return $"{Radius}@{Coordinates}";
        }
    }
}
