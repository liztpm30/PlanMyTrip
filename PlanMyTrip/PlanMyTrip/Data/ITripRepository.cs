using System.Collections.Generic;
using PlanMyTrip.Data.Entities;

namespace PlanMyTrip.Data
{
    public interface ITripRepository
    {
        IEnumerable<User> GetAllUsers();
        IEnumerable<User> GetUserByUsername(string userName);
        public bool AddUser(User user);
        public int AddItinerary(int userId, Itinerary itinerary);
        ICollection<UserItinerary> GetUserItineraries(int userId);
        UserItinerary GetUserItinerarybyID(int userId, int iteneraryid);
    }
}