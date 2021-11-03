using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Places
{
    public class Prediction
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("matched_substrings")]
        public List<PlaceAutocompleteMatchedSubstring> MatchedSubstrings { get; set; }

        [JsonPropertyName("structured_formatting")]
        public PlaceAutocompleteStructuredFormat StructuredFormatting { get; set; }

        [JsonPropertyName("terms")]
        public List<PlaceAutocompleteTerm> Terms { get; set; }

        [JsonPropertyName("place_id")]
        public string PlaceID { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("types")]
        public List<string> Types { get; set; }
    }
}
