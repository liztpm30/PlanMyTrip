using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Matrices
{
    public class DistanceMatrixRow
    {
        [JsonPropertyName("elements")]
        public List<DistanceMatrixElement> Elements { get; set; }
    }
}
