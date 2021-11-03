using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Matrices
{
    public enum TransitMode
    {
        [EnumMember(Value = "bus")]
        BUS = 0,
        [EnumMember(Value = "subway")]
        SUBWAY = 1,
        [EnumMember(Value = "train")]
        TRAIN = 2,
        [EnumMember(Value = "tram")]
        TRAM = 3,
        [EnumMember(Value = "rail")]
        RAIL = 4
    }
}
