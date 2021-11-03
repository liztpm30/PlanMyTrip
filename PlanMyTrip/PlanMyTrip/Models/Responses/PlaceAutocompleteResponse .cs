﻿using PlanMyTrip.Models.Places;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Responses
{
    public class PlaceAutocompleteResponse
    {
        [JsonPropertyName("predictions")]
        public List<Prediction> Predictions { get; set; }

        [JsonPropertyName("status")]
        public PlacesSearchStatus Status { get; set; }

        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }

        [JsonPropertyName("info_messages")]
        public List<string> InfoMessages { get; set; }
    }
}
