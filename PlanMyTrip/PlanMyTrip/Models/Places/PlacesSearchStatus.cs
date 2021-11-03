using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Places
{
    public enum PlacesSearchStatus
    {
        [EnumMember(Value = "OK")]
        OK = 0,
        [EnumMember(Value = "ZERO_RESULTS")]
        ZERO_RESULTS = 1,
        [EnumMember(Value = "INVALID_REQUEST")]
        INVALID_REQUEST = 2,
        [EnumMember(Value = "OVER_QUERY_LIMIT")]
        OVER_QUERY_LIMIT = 3,
        [EnumMember(Value = "REQUEST_DENIED")]
        REQUEST_DENIED = 4,
        [EnumMember(Value = "UNKNOWN_ERROR")]
        UNKNOWN_ERROR = 5

    }
}
