using AutoMapper;
using LuggageFinder.Application.Flights.Commands.CreateFlight;
using LuggageFinder.Application.Flights.Commands.DeleteFlight;
using LuggageFinder.Application.Flights.Commands.UpdateFlight;
using LuggageFinder.Application.Flights.Queries.GetFlightDetails;
using LuggageFinder.Application.Flights.Queries.GetFlightList;
using LuggageFinder.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LuggageFinder.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class FlightController : BaseController
    {
        private readonly IMapper _mapper;
        public FlightController(IMapper mapper)
        {
            _mapper = mapper;
        }

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

        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] CreateFlightDto createFlightDto)
        {
            var command = _mapper.Map<CreateFlightCommand>(createFlightDto);
            command.UserId = UserId;

            var flightId = await Mediator.Send(command);

            return Ok(flightId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateFlightDto updateFlightDto)
        {
            var command = _mapper.Map<UpdateFlightCommand>(updateFlightDto);
            command.UserId = UserId;
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var command = new DeleteFlightCommand
            {
                Id = id,
                UserId = UserId
            };
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
