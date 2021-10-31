using System;
using System.Collections.Generic;
using System.Linq;
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
        /// This method saves all changes made to the db records
        /// </summary>
        /// <returns>True if at least one row was changed</returns>
        public bool saveAllChanges()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
