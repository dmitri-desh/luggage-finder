using BLL.Services.Models;
using BLL.Services.Models.Airport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IAirportService
    {
        Task<GenericResultSet<AirportResultSet>> GetAirportById(int airportId);
        Task<GenericResultSet<List<AirportResultSet>>> GetAllAirports();
    }
}
