using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Functions.Interfaces
{
    public interface IAirportOperations
    {
        Task<Airport> GetAirportById(int id);
        Task<List<Airport>> GetAllAirports();
    }
}
