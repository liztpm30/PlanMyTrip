using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Places
{
    public class PlaceAutocompleteStructuredFormat
    {
        [JsonPropertyName("main_text")]
        public string MainText { get; set; }

        [JsonPropertyName("main_text_matched_substrings")]
        public List<PlaceAutocompleteMatchedSubstring> MainTextMatchedSubstrings { get; set; }

        [JsonPropertyName("secondary_text")]
        public string SecondaryText { get; set; }

        [JsonPropertyName("secondary_text_matched_substrings")]
        public List<PlaceAutocompleteMatchedSubstring> SecondaryTextMatchedSubstrings { get; set; }
    }
}
