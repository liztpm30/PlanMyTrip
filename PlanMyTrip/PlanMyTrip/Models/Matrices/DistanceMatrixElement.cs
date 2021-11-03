using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Matrices
{
    public class DistanceMatrixElement
    {
        [JsonPropertyName("status")]
        public DistanceMatrixElementStatus Status { get; set; }

        [JsonPropertyName("distance")]
        public TextValueObject Distance { get; set; }

        [JsonPropertyName("duration")]
        public TextValueObject Duration { get; set; }

        [JsonPropertyName("duration_in_traffic")]
        public TextValueObject DurationInTraffic { get; set; }

        [JsonPropertyName("fare")]
        public Fare Fare { get; set; }
    }
}
