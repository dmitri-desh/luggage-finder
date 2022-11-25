using LuggageFinder.Domain;
using MediatR;

namespace LuggageFinder.Application.Flights.Commands.UpdateFlight
{
    public class UpdateFlightCommand : IRequest
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string DestinationAddress { get; set; }
        public string TrackNumber { get; set; }
        public Status? Status { get; set; }
        public DateTime? ModificationDate { get; set; }
        public long? ArrivalAirportId { get; set; }
        public long? DepartureAirportId { get; set; }
    }
}
