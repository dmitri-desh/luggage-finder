using BLL.Services.Interfaces;
using DAL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models.Flight;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> AddLuggageRequest(FlightPassObject flight)
        {
            var flightToAdd = new Flight()
            {
                FirstName = flight.FirstName,
                LastName = flight.LastName,
                Email = flight.Email,
                Phone = flight.Phone,
                DestinationAddress = flight.DestinationAddress,
                DepartureAirportId = flight.DepartureAirportId,
                ArrivalAirportId = flight.ArrivalAirportId
            };
            var result = await _flightService.AddLuggageRequest(flightToAdd);

            switch (result.Success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }
    }
}
