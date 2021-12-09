using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Queries
{
    public class NearbyPlaceQuery
    {
        public NearbyPlaceQuery(string location)
        {
            Location = location;
        }

        [AliasAs("keyword")]
        public string Keyword { get; set; }

        [AliasAs("location")]
        public string Location { get; set; }

        [AliasAs("maxprice")]
        public string MaxPrice { get; set; }

        [AliasAs("minprice")]
        public string MinPrice { get; set; }

        [AliasAs("opennow")]
        public Boolean? OpenNow { get; set; } = null;

        [AliasAs("pagetoken")]
        public string PageToken { get; set; }

        [AliasAs("radius")]
        public int Radius { get; set; } = 150;

        // prominence or distance
        [AliasAs("rankby")]
        public string RankBy { get; set; }

        [AliasAs("type")]
        public string Type { get; set; }
    }
}
