using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Maps
{
    public class PlusCode
    {
        [JsonPropertyName("global_code")]
        public string GlobalCode { get; set; }

        [JsonPropertyName("compound_code")]
        public string CompoundCode { get; set; }
    }
}
