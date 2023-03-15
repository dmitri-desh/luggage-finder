using LuggageFinder.Domain;
using MediatR;

namespace LuggageFinder.Application.Flights.Commands.CreateFlight
{
    public class CreateFlightCommand : IRequest<long>
    {
        public long UserId { get; set; }
        public string DestinationAddress { get; set; }
        public string TrackNumber { get; set; }
        public Status? Status { get; set; }
        public DateTime CreationDate { get; set; }
        public long? ArrivalAirportId { get; set; }
        public long? DepartureAirportId { get; set; }
    }
}
