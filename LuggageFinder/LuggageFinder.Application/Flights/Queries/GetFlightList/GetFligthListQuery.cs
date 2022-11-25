using MediatR;

namespace LuggageFinder.Application.Flights.Queries.GetFlightList
{
    public class GetFligthListQuery : IRequest<FlightListVm>
    {
        public long UserId { get; set; }    
    }
}
