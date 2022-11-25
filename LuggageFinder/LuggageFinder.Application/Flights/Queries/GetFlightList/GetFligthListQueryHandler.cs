using AutoMapper;
using AutoMapper.QueryableExtensions;
using LuggageFinder.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggageFinder.Application.Flights.Queries.GetFlightList
{
    public class GetFligthListQueryHandler : IRequestHandler<GetFligthListQuery, FligthListVm>
    {
        private readonly ILuggageFinderDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetFligthListQueryHandler(ILuggageFinderDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<FligthListVm> Handle(GetFligthListQuery request, CancellationToken cancellationToken)
        {
            var fligthsQuery = await _dbContext.Flights.Where(fligth => fligth.UserId == request.UserId)
                .ProjectTo<FlightLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new FligthListVm { Flights = fligthsQuery };
        }
    }
}
