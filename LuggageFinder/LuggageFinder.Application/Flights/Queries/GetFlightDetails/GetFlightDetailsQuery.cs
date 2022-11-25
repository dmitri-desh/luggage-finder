using MediatR;

namespace LuggageFinder.Application.Flights.Queries.GetFlightDetails
{
    public class GetFlightDetailsQuery : IRequest<FlightDetailsVm>
    {
        public long UserId { get; set; }
        public long? Id { get; set; }
    }
}
