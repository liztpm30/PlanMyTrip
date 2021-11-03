using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Places
{
    public enum AutoCompleteType
    {
        [EnumMember(Value = "geocode")]
        GEOCODE = 0,
        [EnumMember(Value = "address")]
        ADDRESS = 1,
        [EnumMember(Value = "establishment")]
        ESTABLISHMENT = 2,
        [EnumMember(Value = "locality")]
        LOCALITY = 3,
        [EnumMember(Value = "sublocality")]
        SUBLOCALITY = 4,
        [EnumMember(Value = "postal_code")]
        POSTALCODE = 5,
        [EnumMember(Value = "country")]
        COUNTY = 6,
        [EnumMember(Value = "administrative_area_level_1")]
        ADMINISTRATIVEAREALEVEL1 = 7,
        [EnumMember(Value = "administrative_area_level_2")]
        ADMINISTRATIVEAREALEVEL2 = 8,
        [EnumMember(Value = "administrative_area_level_3")]
        ADMINISTRATIVEAREALEVEL3 = 9
    }
}
