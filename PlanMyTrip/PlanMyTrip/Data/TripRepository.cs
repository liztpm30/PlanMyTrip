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

        public int AddItinerary(int userId, Itinerary itinerary)
        {
            var user = _context.Users
                .Where(c => c.Id == userId)
                .Include(u => u.UserItinerary)
                .FirstOrDefault();

            user.UserItinerary.Add(new UserItinerary { Itinerary = itinerary });
            return user.UserItinerary
                .Where(x => x.Itinerary.LastUpdatedDate == itinerary.LastUpdatedDate)
                .FirstOrDefault().Id;
        }

        public ICollection<UserItinerary> GetUserItineraries(int userId)
        {
            var user = _context.Users
                .Where(c => c.Id == userId)
                .Include(u => u.UserItinerary)
                .ToList();

            //Since user id is unique only one record should be returned from the above query
            return user.First().UserItinerary;
        }

        public UserItinerary GetUserItinerarybyID(int userId, int iteneraryid)
        {
            var user = _context.Users
                .Where(c => c.Id == userId)
                .Include(u => u.UserItinerary)
                .ThenInclude(u => u.Itinerary)
                .ThenInclude(u => u.Places)
                .ThenInclude(u => u.Place)
                .FirstOrDefault();
               

            if (user.UserItinerary != null)
            {
                return user.UserItinerary.FirstOrDefault(x => x.Id == iteneraryid);
            }

            return null;
        }
    }
}
