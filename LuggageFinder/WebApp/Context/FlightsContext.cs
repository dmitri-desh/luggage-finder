using Microsoft.EntityFrameworkCore;
using WebApp.Models;
using WebApp.AuthModels;

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
                .HasOne(a => a.DepartureAirport)
                .WithMany()
                .HasForeignKey(af => af.DepartureAirportId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Flight>()
               .HasOne(a => a.ArrivalAirport)
               .WithMany()
               .HasForeignKey(af => af.ArrivalAirportId)
               .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Flight> Flights { get; set; }
    }
}
