using System.Collections.Generic;
using PlanMyTrip.Data.Entities;

namespace PlanMyTrip.Data
{
    public interface ITripRepository
    {
        IEnumerable<User> GetAllUsers();
        IEnumerable<User> GetUserByUsername(string userName);
        public bool saveAllChanges();
    }
}