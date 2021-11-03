using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Matrices
{
    public enum TravelMode
    {
        [EnumMember(Value = "DRIVING")]
        DRIVING = 0,
        [EnumMember(Value = "WALKING")]
        WALKING = 1,
        [EnumMember(Value = "BICYCLING")]
        BICYCLING = 2,
        [EnumMember(Value = "TRANSIT")]
        TRANSIT = 3
    }
}
