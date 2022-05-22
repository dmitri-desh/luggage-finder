using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Context
{
    public class FlightsContext : DbContext
    {
        public FlightsContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Flight>()
               .HasOne(a => a.ArrivalAirport)
               .WithMany(f => f.Flights)
               .HasForeignKey(af => af.ArrivalAirportId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Flight>().Ignore("ArrivalAirport")
                .HasOne(a => a.DepartureAirport)
                .WithMany(f => f.Flights)
                .HasForeignKey(af => af.DepartureAirportId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
    }
}
