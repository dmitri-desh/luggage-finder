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

namespace LuggageFinder.Application.Flights.Commands.DeleteFlight
{
    public class DeleteFlightCommandHandler : IRequestHandler<DeleteFlightCommand>
    {
        private readonly ILuggageFinderDbContext _dbContext;
        public DeleteFlightCommandHandler(ILuggageFinderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Flights.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity is null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Flight), request.Id);
            }

            _dbContext.Flights.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
