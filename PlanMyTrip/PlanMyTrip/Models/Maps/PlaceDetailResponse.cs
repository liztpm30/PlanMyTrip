using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Maps
{
    public class PlaceDetailResponse
    {
        [JsonPropertyName("result")]
        public Place Result { get; set; }

        [JsonPropertyName("status")]
        public PlacesSearchStatus Status { get; set; }

        [JsonPropertyName("html_attributions")]
        public List<string> HtmlAttributions { get; set; }

        [JsonPropertyName("info_messages")]
        public List<string> InfoMessages { get; set; }
    }
}
