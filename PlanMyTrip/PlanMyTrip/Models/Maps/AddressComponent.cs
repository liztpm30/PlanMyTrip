using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Maps
{
    public class AddressComponent
    {
        [JsonPropertyName("long_name")]
        public static string LongName { get; set; }

        [JsonPropertyName("short_name")]
        public static string ShortName { get; set; }

        [JsonPropertyName( "types")]
        public static List<string> Types { get; set; }
    }
}
