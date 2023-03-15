using DAL.Context;
using DAL.Entities;
using DAL.Functions.Interfaces;
using DAL.Functions.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Specific
{
    public class FlightOperations : IFlightOperations
    {
        public async Task<Flight> AddLuggageRequest(Flight flight)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    using (var transaction = await context.Database.BeginTransactionAsync())
                    {
                        try
                        {
                            var dateTimeNow = DateTime.UtcNow;
                            var generator = new RandomGenerator();
                            var randomNumber = generator.RandomNumber(0, 999).ToString().PadLeft(3, '0');
                            var randomString = generator.RandomString(4);

                            var luggageToFind = new Flight
                            {
                                FirstName = flight.FirstName,
                                LastName = flight.LastName,
                                Email = flight.Email,
                                DestinationAddress = flight.DestinationAddress,
                                DepartureAirportId = flight.DepartureAirportId,
                                ArrivalAirportId = flight.ArrivalAirportId,
                                Status = Status.Accepted,
                                TrackNumber = $"{randomString}{randomNumber}",
                                CreationDate = dateTimeNow

                            };
                            var trackingLuggage = await context.Flights.AddAsync(luggageToFind);
                            await context.SaveChangesAsync();
                            await transaction.CommitAsync();
                          
                            return luggageToFind;
                        }
                        catch (Exception ex)
                        {
                            await transaction.RollbackAsync();
                            throw new Exception(ex.Message);
                        }
                    }
                }
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<List<Flight>> GetLuggageRequestsByUsername(string email)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    List<Flight> luggageRequests = 
                        await context.Flights.Where(f => f.Email.Equals(email, StringComparison.OrdinalIgnoreCase)).ToListAsync();

                    return luggageRequests;
                }
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
