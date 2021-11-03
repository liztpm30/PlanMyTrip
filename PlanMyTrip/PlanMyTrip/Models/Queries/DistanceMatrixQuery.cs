using PlanMyTrip.Models.Matrices;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Queries
{
    public class DistanceMatrixQuery
    {
        public DistanceMatrixQuery(List<string> origins, List<string> destinations)
        {
            Origins = origins;
            Destinations = destinations;
        }

        [AliasAs("origins")]
        public List<string> Origins { get; set; }

        [AliasAs("destinations")]
        public List<string> Destinations { get; set; }

        [AliasAs("arrival_time")]
        public long? ArrivalTime { get; set; } = null;

        [AliasAs("departure_time")]
        public long DepartureTime { get; set; } = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

        [AliasAs("avoid")]
        public Avoid? Avoid { get; set; } = null;

        [AliasAs("language")]
        public string Language { get; set; }

        [AliasAs("mode")]
        public TravelMode Mode { get; set; } = TravelMode.DRIVING;

        [AliasAs("region")]
        public string Region { get; set; }

        [AliasAs("traffic_model")]
        public TrafficModel TrafficModel { get; set; } = TrafficModel.PESSIMISTIC;

        [AliasAs("transit_mode")]
        public List<TransitMode>? TransitMode { get; set; } = null;

        [AliasAs("transit_routing_preference")]
        public RoutingPreferences? TransitRoutingPreference { get; set; } = null;

        [AliasAs("units")]
        public string Units { get; set; }
    }
}
