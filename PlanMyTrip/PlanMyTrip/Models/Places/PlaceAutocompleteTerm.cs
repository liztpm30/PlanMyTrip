using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Places
{
    public class PlaceAutocompleteTerm
    {
        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
