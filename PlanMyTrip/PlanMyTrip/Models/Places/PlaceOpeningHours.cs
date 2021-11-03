using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlanMyTrip.Models.Places
{
    public class PlaceOpeningHours
    {
        [JsonPropertyName("open_now")]
        public bool OpenNow { get; set; }

        [JsonPropertyName("periods")]
        public List<PlaceOpeningHours> Periods { get; set; }

        [JsonPropertyName("weekday_text")]
        public List<string> WeekdayText { get; set; }
    }

    public class PlaceOpeningHoursPeriod
    {
        [JsonPropertyName("open")]
        public PlaceOpeningHoursPeriodDetail Open { get; set; }

        [JsonPropertyName("close")]
        public PlaceOpeningHoursPeriodDetail Close { get; set; }
    }

    public class PlaceOpeningHoursPeriodDetail
    {
        [JsonPropertyName("day")]
        public int Day { get; set; }

        [JsonPropertyName("time")]
        public string Time { get; set; }
    }
}
