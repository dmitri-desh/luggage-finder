using MediatR;

namespace LuggageFinder.Application.Flights.Queries.GetFlightList
{
    public class GetFligthListQuery : IRequest<FligthListVm>
    {
        public long UserId { get; set; }    
    }
}
