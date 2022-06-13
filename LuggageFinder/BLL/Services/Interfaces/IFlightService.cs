using BLL.Services.Models;
using BLL.Services.Models.Flight;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IFlightService
    {
        Task<GenericResultSet<FlightResultSet>> AddLuggageRequest(Flight flight);
        Task<GenericResultSet<FlightResultSet>> GetFlightById(int flightId);
        Task<GenericResultSet<FlightResultSet>> UpdateFlight(int flightId, Status status);
        Task<GenericResultSet<List<FlightResultSet>>> GetFlightsByUsername(string email);

    }
}
