using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebApi.Models;

namespace WebApi.Context
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("FlightsDb")
        { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}