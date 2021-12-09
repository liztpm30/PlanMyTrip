using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PlanMyTrip.Data.Entities;

namespace PlanMyTrip.Data
{
    public class TripRepository : ITripRepository
    {
        private readonly TripContext _context;

        public TripRepository(TripContext context)
        {
            this._context = context;
        }

        /// <summary>
        ///  This method gets all users stored on the database
        /// </summary>
        /// <returns>All users records stored on the database</returns>
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        /// <summary>
        /// This method gets the user record with the given username
        /// </summary>
        /// <param name="userName">The userName of the user to be returned</param>
        /// <returns>User record with the given userName</returns>
        public IEnumerable<User> GetUserByUsername(string userName)
        {
            return _context.Users.Where(c => c.UserName == userName).ToList();
        }

        /// <summary>
        /// This method saves a new user entry to the database
        /// </summary>
        /// <returns>True if at least one record was added</returns>
        public bool AddUser (User user)
        {
            _context.Set<User>().Add(user);
            var numberOfRecordsAdded = _context.SaveChanges();
            return numberOfRecordsAdded > 0;
        }

        public ICollection<UserItinerary> GetUserItineraries(int userId)
        {
            var user = _context.Users
                .Where(c => c.Id == userId)
                .Include(u => u.Itineraries)
                .ToList();

            return user.First().Itineraries;
        }
        public List<List<Itinerary>> GetItineraries(ICollection<UserItinerary> UserIt)
        {
            List<List<Itinerary>> list = new List<List<Itinerary>>();
            foreach (UserItinerary UserItinerary in UserIt)
            {
                var record = _context.Itinerary
                    .Where(c => c.Id == UserItinerary.ItineraryId)
                    .ToList();

                list.Add(record);
            }

            return list;
        }

    }
}
