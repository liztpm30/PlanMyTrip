using System;
namespace PlanMyTrip.Data.Entities
{
    public class UserItinerary
    {
        public int Id { get; set; }
        public User user { get; set; }
        public Itinerary Itinerary { get; set; }
        public int ItineraryId { get; internal set; }
    }
}
