using LuggageFinder.Application.Interfaces;
using LuggageFinder.Domain;
using MediatR;

namespace LuggageFinder.Application.Airports.Commands.CreateAirport
{
    public class CreateAirportCommandHandler : IRequestHandler<CreateAirportCommand, long>
    {
        private readonly ILuggageFinderDbContext _dbContext;
        public CreateAirportCommandHandler(ILuggageFinderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<long> Handle(CreateAirportCommand request, CancellationToken cancellationToken)
        {
            var airport = new Airport { Name = request.Name };

            var entity = await _dbContext.Airports.AddAsync(airport, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.Entity.Id;
        }
    }
}
