using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Matrices
{
    public enum TrafficModel
    {
        [EnumMember(Value = "best_guess")]
        BESTGUESS = 0,
        [EnumMember(Value = "pessimistic")]
        PESSIMISTIC = 1,
        [EnumMember(Value = "optimistic")]
        OPTIMISTIC = 2
    }
}
