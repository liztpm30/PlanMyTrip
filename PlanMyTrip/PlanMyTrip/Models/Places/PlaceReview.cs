using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Places
{
    public class PlaceReview
    {
        [JsonPropertyName("author_name")]
        public string AuthorName { get; set; }

        [JsonPropertyName("rating")]
        public int Rating { get; set; }

        [JsonPropertyName("relative_time_description")]
        public string RelativeTimeDescription { get; set; }

        [JsonPropertyName("time")]
        public double Time { get; set; }

        [JsonPropertyName("author_url")]
        public string AuthorUrl { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        [JsonPropertyName("profile_photo_url")]
        public string ProfilePhotoUrl { get; set; }

        [JsonPropertyName("text")]
        public string Text { get; set; }
    }
}
