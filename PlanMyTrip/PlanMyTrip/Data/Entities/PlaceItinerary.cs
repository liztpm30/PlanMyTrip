using System;
namespace PlanMyTrip.Data.Entities
{
    public class PlaceItinerary
    {
        public int Id { get; set; }
        public Itinerary Itinerary { get; set; }
        public Place Place { get; set; }
        public int PlaceIndex { get; set; }
        public int DayNumber { get; set; }

    }
}
