﻿using System;
using System.Collections.Generic;

namespace PlanMyTrip.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public ICollection<UserItinerary> Itineraries { get; set; }
    }
}
