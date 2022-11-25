using LuggageFinder.Application.Flights.Queries.GetFlightDetails;
using LuggageFinder.Application.Flights.Queries.GetFlightList;
using Microsoft.AspNetCore.Mvc;

namespace LuggageFinder.WebApi.Controllers
{
    public class FlightController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<FlightListVm>> GetAll()
        {
            var query = new GetFligthListQuery { UserId = UserId };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FlightDetailsVm>> Get(long? id)
        {
            var query = new GetFlightDetailsQuery { UserId = UserId, Id = id };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
