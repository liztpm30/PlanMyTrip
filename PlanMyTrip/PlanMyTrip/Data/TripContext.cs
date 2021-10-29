using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PlanMyTrip.Data.Entities;

namespace PlanMyTrip.Data
{
    public class TripContext : DbContext
    {
        private readonly IConfiguration _config;

        public DbSet<User> Users { get; set; }


        public TripContext(IConfiguration configuration)
        {
            this._config = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config.GetConnectionString("Database"));
        }
    }
}
