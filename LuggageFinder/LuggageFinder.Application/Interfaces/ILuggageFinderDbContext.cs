using LuggageFinder.Domain;
using Microsoft.EntityFrameworkCore;

namespace LuggageFinder.Application.Interfaces
{
    public interface ILuggageFinderDbContext
    {
        DbSet<Flight> Flights { get; set; }
        DbSet<Airport> Airports { get; set; }
        DbSet<User> Users { get; set; } 

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
