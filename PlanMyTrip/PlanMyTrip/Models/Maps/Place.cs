using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Maps
{
    public class Place
    {
        [JsonPropertyName("address_components")]
        public List<AddressComponent> AddressComponents { get; set; }

        [JsonPropertyName("adr_adress")]
        public string Address { get; set; }

        [JsonPropertyName("business_status")]
        public string BusinessStatus { get; set; }

        [JsonPropertyName("formatted_address")]
        public string FormattedAddress { get; set; }

        [JsonPropertyName("formatted_phone_number")]
        public string FormattedPhoneNumber { get; set; }

        [JsonPropertyName("geometry")]
        public Geometry Geometry { get; set; }

        [JsonPropertyName("icon")]
        public string Icon { get; set; }

        [JsonPropertyName("icon_background_color")]
        public string IconBackgroundColor { get; set; }

        [JsonPropertyName("icon_mask_base_uri")]
        public string IconMaskBaseUri { get; set; }

        [JsonPropertyName("international_phone_number")]
        public string InternationalPhoneNumber { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("opening_hours")]
        public PlaceOpeningHours OpeningHours { get; set; }

        [JsonPropertyName("permanently_closed")]
        public bool PermanentlyClosed { get; set; }

        [JsonPropertyName("photos")]
        public List<PlacePhoto> Photos { get; set; }

        [JsonPropertyName("place_id")]
        public string PlaceID { get; set; }

        [JsonPropertyName("plus_code")]
        public PlusCode PlusCode { get; set; }

        [JsonPropertyName("price_level")]
        public int PriceLevel { get; set; }

        [JsonPropertyName("rating")]
        public double Rating { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("reviews")]
        public List<PlaceReview> Reviews { get; set; }

        [JsonPropertyName("scope")]
        public string Scope { get; set; }

        [JsonPropertyName("types")]
        public List<string> Types { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("user_ratings_total")]
        public int UserRatingsTotal { get; set; }

        [JsonPropertyName("utc_offset")]
        public int UtcOffset { get; set; }

        [JsonPropertyName("vicinity")]
        public string Vicinity { get; set; }

        [JsonPropertyName("website")]
        public string Website { get; set; }

    }
}
