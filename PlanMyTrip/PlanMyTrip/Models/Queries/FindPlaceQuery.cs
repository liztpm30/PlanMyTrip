using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using PlanMyTrip.Models.Places;
using Refit;

namespace PlanMyTrip.Models.Queries
{
    public class FindPlaceQuery
    {
        public FindPlaceQuery(string input)
        {
            Input = input;
        }

        public void SetPoint(Coordinates point) => LocationBias = $"point:{point}";

        public void SetCircular(Circular circular) => LocationBias = $"circular:{circular}";

        public void SetRectangle(BoundingBox boundingbox) => LocationBias = $"rectangle:{boundingbox}";


        [AliasAs("fields")]
        [Query(CollectionFormat.Csv)]
        public List<string> Fields { get; } = new List<string>() {
            "name","business_status","formatted_address","opening_hours","place_id","photos","place_id","price_level","rating"
        };

        [AliasAs("inputtype")]
        public string InputType { get; } = "textquery";

        [AliasAs("input")]
        public string Input { get; set; }

        [AliasAs("locationbias")]
        public string LocationBias { get; private set; } = "ipbias"; 

    }
}
