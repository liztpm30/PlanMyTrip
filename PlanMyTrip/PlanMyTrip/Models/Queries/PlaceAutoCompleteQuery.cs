using PlanMyTrip.Models.Places;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Queries
{
    public class PlaceAutoCompleteQuery
    {
        public PlaceAutoCompleteQuery(string input)
        {
            Input = input;
        }

        [AliasAs("input")]
        public string Input { get; set; }

        [AliasAs("components")]
        public string Components { get; set; }

        [AliasAs("language")]
        public string Language { get; set; }

        [AliasAs("location")]
        public string Location { get; set; }

        [AliasAs("offset")]
        public string Offset { get; set; }

        [AliasAs("origin")]
        public string Origin { get; set; }

        [AliasAs("radius")]
        public int Radius { get; set; } = 150;

        [AliasAs("strictbounds")]
        public Boolean? StrictBounds { get; set; } = null;

        [AliasAs("types")]
        public AutoCompleteType Type { get; set; } = AutoCompleteType.ESTABLISHMENT;
    }
}
