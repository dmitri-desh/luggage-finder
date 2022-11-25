using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggageFinder.Application.Airports.Commands.CreateAirport
{
    public class CreateAirportCommand : IRequest<long>
    {
        public string Name { get; set; }
    }
}
