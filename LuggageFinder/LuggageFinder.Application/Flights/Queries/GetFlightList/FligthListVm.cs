using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuggageFinder.Application.Flights.Queries.GetFlightList
{
    public class FligthListVm
    {
        public IList<FlightLookupDto> Flights { get; set; }
    }
}
