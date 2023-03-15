using MediatR;

namespace LuggageFinder.Application.Flights.Commands.DeleteFlight
{
    public class DeleteFlightCommand : IRequest
    {
        public long Id { get; set; }
        public long UserId { get; set; }
    }
}
