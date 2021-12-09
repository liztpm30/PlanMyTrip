using System;
using System.Collections.Generic;

namespace PlanMyTrip.Data.Entities
{
    public class Itinerary
    {
        public int Id { get; set; }
        public string TripName { get; set; }
        public long LastUpdatedDate { get; set; }
        public int NumberOfDays { get; set; }
        public ICollection<PlaceItinerary> Places { get; set; }
    }
}
