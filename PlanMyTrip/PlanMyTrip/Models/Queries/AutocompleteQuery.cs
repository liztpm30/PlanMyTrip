using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Queries
{
    public class AutocompleteQuery
    {
        public AutocompleteQuery(string input)
        {
            Input = input;
        }

        [AliasAs("input")]
        public string Input { get; set; }

        [AliasAs("language")]
        public string Language { get; set; }

        [AliasAs("location")]
        public string Location { get; set; }

        [AliasAs("offset")]
        public string Offset { get; set; }

        [AliasAs("radius")]
        public int Radius { get; set; } = 150;
    }
}
