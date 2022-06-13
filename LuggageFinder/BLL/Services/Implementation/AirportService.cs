using BLL.Services.Interfaces;
using BLL.Services.Models;
using BLL.Services.Models.Airport;
using DAL.Entities;
using DAL.Functions.Crud;
using DAL.Functions.Interfaces;
using DAL.Functions.Specific;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Implementation
{
    public class AirportService : IAirportService
    {
        private readonly ICRUD _crud = new CRUD();
        private readonly IAirportOperations _airportOperations = new AirportOperations();

        public async Task<GenericResultSet<AirportResultSet>> GetAirportById(int airportId)
        {
            var result = new GenericResultSet<AirportResultSet>();
            const string methodFullName = "BLL.Services.Implementation.AirportService: GetAirportById()";

            try
            {
                var airport = await _crud.Read<Airport>(airportId);

                var airportReturned = new AirportResultSet
                {
                    Id = airport.Id,
                    Name = airport.Name
                };

                result.UserMessage = "Your airport was located successfully";
                result.InternalMessage = $"{methodFullName} method executed successfully.";
                result.ResultSet = airportReturned;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.UserMessage = "We failed to find the airport you are looking for.";
                result.InternalMessage = $"ERROR: {methodFullName}: {exception.Message}";
            }

            return result;
        }

        public async Task<GenericResultSet<List<AirportResultSet>>> GetAllAirports()
        {
            var result = new GenericResultSet<List<AirportResultSet>>()
            {
                ResultSet = new List<AirportResultSet>()
            };
            const string methodFullName = "BLL.Services.Implementation.AirportService: GetAllAirports()";

            try
            {
                var airports = await _airportOperations.GetAllAirports();

                airports.ForEach(airport => {
                    result.ResultSet.Add(new AirportResultSet
                    {
                        Id = airport.Id,
                        Name = airport.Name
                    });
                });

                result.UserMessage = "Your airports were located successfully";
                result.InternalMessage = $"{methodFullName} method executed successfully.";
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.UserMessage = "We failed to find the airports you were looking for.";
                result.InternalMessage = $"ERROR: {methodFullName}: {exception.Message}";
            }

            return result;
        }
    }
}
