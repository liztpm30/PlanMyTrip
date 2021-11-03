using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Places
{
    public class BoundingBox
    {
        [JsonPropertyName("southwest")]
        public Coordinates MinCoordinates { get; set; }

        [JsonPropertyName("northeast")]
        public Coordinates MaxCoordinates { get; set; }

        public override string ToString()
        {
            return $"{MinCoordinates}|{MaxCoordinates}";
        }
    }
}
