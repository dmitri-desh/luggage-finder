using LuggageFinder.Application.Common.Exceptions;
using LuggageFinder.Application.Interfaces;
using LuggageFinder.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LuggageFinder.Application.Flights.Commands.UpdateFlight
{
    public class UpdateFlightCommandHandler : IRequestHandler<UpdateFlightCommand>
    {
        private readonly ILuggageFinderDbContext _dbContext;
        public UpdateFlightCommandHandler(ILuggageFinderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateFlightCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Flights.FirstOrDefaultAsync(flight => flight.Id == request.Id, cancellationToken);
            if (entity is null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Flight), request.Id);
            }

            entity.UserId = request.UserId;
            entity.TrackNumber = request.TrackNumber;
            entity.ModificationDate = DateTime.Now;
            entity.ArrivalAirportId = request.ArrivalAirportId;
            entity.DepartureAirportId = request.DepartureAirportId;
            entity.Status = request.Status;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
