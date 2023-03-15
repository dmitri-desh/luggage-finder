using LuggageFinder.Application.Common.Exceptions;
using LuggageFinder.Application.Interfaces;
using LuggageFinder.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggageFinder.Application.Airports.Commands.UpdateAirport
{
    public class UpdateAirportCommandHandler : IRequestHandler<UpdateAirportCommand>
    {
        private readonly ILuggageFinderDbContext _dbContext;
        public UpdateAirportCommandHandler(ILuggageFinderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(UpdateAirportCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Airports.FirstOrDefaultAsync(airport => airport.Id == request.Id, cancellationToken);
            if (entity is null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Airport), request.Id);
            }

            entity.Name = request.Name;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
