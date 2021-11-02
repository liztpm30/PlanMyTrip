using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Queries
{
    public class PlaceDetailsQuery
    {
        public PlaceDetailsQuery(string id) => PlaceID = id;

        [AliasAs("place_id")]
        public string PlaceID { get; }
    }
}
