using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IFlightOperations
    {
        Task<Flight> AddFullFlight(string firstName, string lastName, string email, string phone, string destinationAddress);
        Task<List<Flight>> GetFlightsByUser(string firstName, string lastName, string email);
    }
}
