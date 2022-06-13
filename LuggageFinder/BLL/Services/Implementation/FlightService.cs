using BLL.Services.Interfaces;
using BLL.Services.Models;
using BLL.Services.Models.Flight;
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
    public class FlightService : IFlightService
    {
        private readonly ICRUD _crud = new CRUD();
        private readonly IFlightOperations _flightOperations = new FlightOperations();

        public async Task<GenericResultSet<FlightResultSet>> AddLuggageRequest(Flight flight)
        {
            var result = new GenericResultSet<FlightResultSet>()
            {
                ResultSet = new FlightResultSet()
            };
            const string methodFullName = "BLL.Services.Implementation.FlightService: AddLuggageRequest()";
            try
            {
                Flight flightAdded = await _flightOperations.AddLuggageRequest(flight);

                result.ResultSet = new FlightResultSet
                {
                    Id = flightAdded.Id,
                    FirstName = flightAdded.FirstName,
                    LastName = flightAdded.LastName,
                    Email = flightAdded.Email,
                    Phone = flightAdded.Phone,
                    Status = flightAdded.Status,
                    DestinationAddress = flightAdded.DestinationAddress,
                    DepartureAirportId = flightAdded.DepartureAirportId,
                    ArrivalAirportId = flightAdded.ArrivalAirportId,
                    TrackNumber = flightAdded.TrackNumber,
                    CreationDate = flightAdded.CreationDate
                };

                result.UserMessage = "The supplied flight was added successfully";
                result.InternalMessage = $"{methodFullName} method executed successfully.";
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.UserMessage = "We failed to register your information for your child. Please try again.";
                result.InternalMessage = $"ERROR: {methodFullName}: {exception.Message}";
            }
            return result;
        }

        public async Task<GenericResultSet<FlightResultSet>> GetFlightById(int flightId)
        {
            var result = new GenericResultSet<FlightResultSet>();
            const string methodFullName = "BLL.Services.Implementation.FlihgtService: GetFlightById()";

            try
            {
                var flight = await _crud.Read<Flight>(flightId);

                var flightReturned = new FlightResultSet
                {
                    Id = flight.Id,
                    FirstName = flight.FirstName,
                    LastName = flight.LastName,
                    Email = flight.Email,
                    DestinationAddress = flight.DestinationAddress,
                    Phone = flight.Phone,
                    Status = flight.Status,
                    DepartureAirportId = flight.DepartureAirportId,
                    ArrivalAirportId = flight.ArrivalAirportId,
                    TrackNumber = flight.TrackNumber
                };

                result.UserMessage = "Your flight was located successfully";
                result.InternalMessage = $"{methodFullName} method executed successfully.";
                result.ResultSet = flightReturned;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.UserMessage = "We failed to find the flight you are looking for.";
                result.InternalMessage = $"ERROR: {methodFullName}: {exception.Message}";
            }

            return result;
        }

        public async Task<GenericResultSet<List<FlightResultSet>>> GetFlightsByUsername(string email)
        {
            var result = new GenericResultSet<List<FlightResultSet>>()
            {
                ResultSet = new List<FlightResultSet>()
            };
            const string methodFullName = "BLL.Services.Implementation.FlightService: GetLuggageRequestsByUsername()";

            try
            {
                List<Flight> luggageRequests = await _flightOperations.GetLuggageRequestsByUsername(email);

                luggageRequests.ForEach(flight => {
                    result.ResultSet.Add(new FlightResultSet
                    {
                        Id = flight.Id,
                        FirstName = flight.FirstName,
                        LastName = flight.LastName,
                        DestinationAddress = flight.DestinationAddress,
                        Phone = flight.Phone,
                        Email = flight.Email,
                        Status = flight.Status,
                        CreationDate = flight.CreationDate,
                        DepartureAirportId = flight.DepartureAirportId,
                        ArrivalAirportId = flight.ArrivalAirportId
                    });
                });

                result.UserMessage = "Your flight requests were located successfully";
                result.InternalMessage = $"{methodFullName} method executed successfully.";
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.UserMessage = "We failed to find the flight requests you were looking for.";
                result.InternalMessage = $"ERROR: {methodFullName}: {exception.Message}";
            }
            
            return result;
        }

        public async Task<GenericResultSet<FlightResultSet>> UpdateFlight(int flightId, Status status)
        {
            var result = new GenericResultSet<FlightResultSet>();
            const string methodFullName = "BLL.Services.Implementation.FlightService: UpdateFlight()";
            try
            {
                var flight = new Flight
                {
                    Id = flightId,
                    Status = status,
                    ModificationDate = DateTime.UtcNow
                };

                flight = await _crud.Update(flight, flightId);

                var flightUpdated = new FlightResultSet
                {
                    Id = flight.Id,
                    Status = flight.Status,
                    ModificationDate = flight.ModificationDate
                };

                result.UserMessage = "The supplied flight was updated successfully";
                result.InternalMessage = $"{methodFullName} method executed successfully.";
                result.ResultSet = flightUpdated;
                result.Success = true;
            }
            catch (Exception exception)
            {
                result.Exception = exception;
                result.UserMessage = "We failed to update your information for the flight supplied. Please try again.";
                result.InternalMessage = $"ERROR: {methodFullName}: {exception.Message}";
            }
            
            return result;
        }
    }
}
