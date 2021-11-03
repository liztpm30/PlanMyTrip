using PlanMyTrip.Models.Matrices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Responses
{
    public class DistanceMatrixResponse
    {
        [JsonPropertyName("origin_addresses")]
        public List<string> OriginAddresses { get; set; }

        [JsonPropertyName("destination_addresses")]
        public List<string> DestinationAddresses { get; set; }

        [JsonPropertyName("rows")]
        public List<DistanceMatrixRow> Rows { get; set; }

        [JsonPropertyName("status")]
        public DistanceMatrixStatus Status { get; set; }
    }
}
