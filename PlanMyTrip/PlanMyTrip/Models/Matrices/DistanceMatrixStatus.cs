using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Matrices
{
    public enum DistanceMatrixStatus
    {
        [EnumMember(Value = "OK")]
        OK = 0,
        [EnumMember(Value = "INVALID_REQUEST")]
        INVALID_REQUEST  = 1,
        [EnumMember(Value = "MAX_ELEMENTS_EXCEEDED")]
        MAX_ELEMENTS_EXCEEDED = 2,
        [EnumMember(Value = "MAX_DIMENSIONS_EXCEEDED")]
        MAX_DIMENSIONS_EXCEEDED = 3,
        [EnumMember(Value = "OVER_DAILY_LIMIT")]
        OVER_DAILY_LIMIT = 4,
        [EnumMember(Value = "OVER_QUERY_LIMIT")]
        OVER_QUERY_LIMIT = 5,
        [EnumMember(Value = "REQUEST_DENIED")]
        REQUEST_DENIED = 6,
        [EnumMember(Value = "UNKNOWN_ERROR")]
        UNKNOWN_ERROR = 7
    }
}
