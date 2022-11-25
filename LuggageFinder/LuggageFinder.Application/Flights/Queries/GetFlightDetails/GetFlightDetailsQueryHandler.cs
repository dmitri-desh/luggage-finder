using AutoMapper;
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

namespace LuggageFinder.Application.Flights.Queries.GetFlightDetails
{
    public class GetFlightDetailsQueryHandler : IRequestHandler<GetFlightDetailsQuery, FlightDetailsVm>
    {
        private readonly ILuggageFinderDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetFlightDetailsQueryHandler(ILuggageFinderDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<FlightDetailsVm> Handle(GetFlightDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Flights.FirstOrDefaultAsync(flight => flight.Id == request.Id, cancellationToken);
            if (entity is null || entity.Id != request.Id)
            {
                throw new NotFoundException(nameof(Flight), request.Id);
            }

            return _mapper.Map<FlightDetailsVm>(entity);
        }
    }
}
