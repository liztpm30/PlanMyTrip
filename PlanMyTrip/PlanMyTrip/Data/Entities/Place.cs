using System;
namespace PlanMyTrip.Data.Entities
{
    public class Place
    {
        public int Id { get; set; }
        public string GooglePlaceID { get; set; }
        public string PlaceName { get; set; }
        public string Details { get; set; }
    }
}
