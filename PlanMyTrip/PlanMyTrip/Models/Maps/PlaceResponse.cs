using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Maps
{
    public class PlaceResponse
    {
        [JsonPropertyName("candidates")]
        public List<Place> Candidates { get; set; }

        [JsonPropertyName("status")]
        public PlacesSearchStatus Status { get; set; }

        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }

        [JsonPropertyName("info_messages")]
        public List<string> InfoMessages { get; set; }
    }
}
