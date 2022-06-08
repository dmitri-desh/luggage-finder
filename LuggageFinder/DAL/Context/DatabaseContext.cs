using Microsoft.EntityFrameworkCore;
using DAL.Entities;
using System;
using DAL.Entities.Auth;

namespace DAL.Context
{
    public class DatabaseContext : DbContext
    {
        public class OptionsBuild 
        {
            //CONSTRUCTOR
            public OptionsBuild()
            {
                Settings = new AppConfiguration();

                OptionsBuilder = new DbContextOptionsBuilder<DatabaseContext>();
                
                OptionsBuilder.UseSqlServer(Settings.SqlConnectionString);
                
                DatabaseOptions = OptionsBuilder.Options;
            }
            public DbContextOptionsBuilder<DatabaseContext> OptionsBuilder { get; set; }
            public DbContextOptions<DatabaseContext> DatabaseOptions { get; set; }
            private AppConfiguration Settings { get; set; }
        }
       
        public static OptionsBuild Options = new OptionsBuild();

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           builder.Entity<Flight>()
               .HasOne(a => a.ArrivalAirport)
               .WithMany()
               .HasForeignKey(af => af.ArrivalAirportId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Flight>()
               .HasOne(a => a.DepartureAirport)
               .WithMany()
               .HasForeignKey(af => af.DepartureAirportId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}