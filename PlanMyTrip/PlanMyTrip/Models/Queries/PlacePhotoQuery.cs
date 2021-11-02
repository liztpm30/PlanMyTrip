using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Queries
{
    public class PlacePhotoQuery
    {
        public PlacePhotoQuery(string reference, int maxwidth = 300, int maxheight = 300)
        {
            PhotoReference = reference;
            MaxHeight = maxheight;
            MaxWidth = maxwidth;
        }

        [AliasAs("photo_reference")]
        public string PhotoReference { get; }

        [AliasAs("maxheight")]
        public int MaxHeight { get; set; }

        [AliasAs("maxwidth")]
        public int MaxWidth { get; set; }
    }
}
