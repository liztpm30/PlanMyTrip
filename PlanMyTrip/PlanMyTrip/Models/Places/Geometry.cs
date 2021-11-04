using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Places
{
    public class Geometry
    {
        [JsonPropertyName("location")]
        public Coordinates Location { get; set; }


        [JsonPropertyName("viewport")]
        public BoundingBox Viewport { get; set; }
    }
}
