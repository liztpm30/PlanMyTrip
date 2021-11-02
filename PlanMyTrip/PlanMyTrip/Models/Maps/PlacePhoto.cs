using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Maps
{
    public class PlacePhoto
    {
        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("html_attributions")]
        public List<string> HtmlAttributions { get; set; }

        [JsonPropertyName("photo_reference")]
        public string PhotoReference { get; set; }

        [JsonPropertyName("width")]
        public int Width { get; set; }
    }
}
