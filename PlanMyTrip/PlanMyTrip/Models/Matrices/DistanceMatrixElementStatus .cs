using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Matrices
{
    public enum DistanceMatrixElementStatus
    {
        [EnumMember(Value = "OK")]
        OK = 0,
        [EnumMember(Value = "NOT_FOUND")]
        NOT_FOUND = 1,
        [EnumMember(Value = "ZERO_RESULTS")]
        ZERO_RESULTS = 2,
        [EnumMember(Value = "MAX_ROUTE_LENGTH_EXCEEDED")]
        MAX_ROUTE_LENGTH_EXCEEDED = 3
    }
}
