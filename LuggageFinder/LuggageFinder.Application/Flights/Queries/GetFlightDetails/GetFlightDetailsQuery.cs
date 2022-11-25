using MediatR;

namespace LuggageFinder.Application.Flights.Queries.GetFlightDetails
{
    public class GetFlightDetailsQuery : IRequest<FlightDetailsVm>
    {
        public long? Id { get; set; }
    }
}
