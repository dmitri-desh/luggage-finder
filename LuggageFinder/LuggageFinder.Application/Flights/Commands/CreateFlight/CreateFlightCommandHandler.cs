using LuggageFinder.Application.Interfaces;
using LuggageFinder.Domain;
using MediatR;

namespace LuggageFinder.Application.Flights.Commands.CreateFlight
{
    public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, long>
    {
        private readonly ILuggageFinderDbContext _dbContext;
        public CreateFlightCommandHandler(ILuggageFinderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<long> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = new Flight
            {
                UserId = request.UserId,
                DestinationAddress = request.DestinationAddress,
                TrackNumber = request.TrackNumber,
                Status = Status.Accepted,
                CreationDate = DateTime.Now,
                ArrivalAirportId = request.ArrivalAirportId,
                DepartureAirportId = request.DepartureAirportId
            };

            var entity = await _dbContext.Flights.AddAsync(flight, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Entity.Id;
        }
    }
}
