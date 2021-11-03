using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Matrices
{
    public enum Avoid
    {
        [EnumMember(Value = "tolls")]
        TOLLS = 0,
        [EnumMember(Value = "highways")]
        HIGHWAYS = 1,
        [EnumMember(Value = "ferries")]
        FERRIES = 2,
        [EnumMember(Value = "indoor")]
        INDOOR = 3
    }
}
