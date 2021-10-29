using System;
using System.Collections.Generic;

namespace PlanMyTrip.Data.Entities
{
    public class Itinerary
    {
        public int Id { get; set; }
        public int TripName { get; set; }
        public int LastUpdatedDate { get; set; }
        public int NumberOfDays { get; set; }
        public ICollection<PlaceItinerary> Places { get; set; }
    }
}
