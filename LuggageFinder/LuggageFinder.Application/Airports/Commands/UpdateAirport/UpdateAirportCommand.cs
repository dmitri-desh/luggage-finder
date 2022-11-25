using MediatR;

namespace LuggageFinder.Application.Airports.Commands.UpdateAirport
{
    public class UpdateAirportCommand : IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
