using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IFlightOperations
    {
        Task<Flight> AddLuggageRequest(Flight flight);
        Task<List<Flight>> GetLuggageRequestsByUsername(string email);
    }
}
