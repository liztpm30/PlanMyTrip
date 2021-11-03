using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Matrices
{
    public enum RoutingPreferences
    {
        [EnumMember(Value = "less_walking")]
        LESSWALKING = 0,
        [EnumMember(Value = "fewer_transfers")]
        FEWERTRANSFERS = 1,
    }
}
