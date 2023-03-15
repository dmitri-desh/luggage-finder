using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAL.Context;
using DAL.Entities;
using BLL.Services.Interfaces;
using DAL.Functions.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportsController : ControllerBase
    {
        private readonly ICRUD _crud;
        private readonly IAirportService _airportService;

        public AirportsController(IAirportService airportService)
        {
            _airportService = airportService;
        }

        // GET: api/Airports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Airport>>> GetAirports()
        {
            var result = await _airportService.GetAllAirports();

            switch (result.Success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        // GET: api/Airports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Airport>> GetAirport(int id)
        {
            var result = await _airportService.GetAirportById(id);

            switch (result.Success)
            {
                case true:
                    return Ok(result);

                case false:
                    return StatusCode(500, result);
            }
        }

        // PUT: api/Airports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutAirport(int id, Airport airport)
        //{
        //    if (id != airport.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(airport).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!AirportExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/Airports
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Airport>> PostAirport(Airport airport)
        //{
        //    _context.Airports.Add(airport);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAirport", new { id = airport.Id }, airport);
        //}

        //// DELETE: api/Airports/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteAirport(int id)
        //{
        //    var airport = await _context.Airports.FindAsync(id);
        //    if (airport == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Airports.Remove(airport);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        //private bool AirportExists(int id)
        //{
        //    return _context.Airports.Any(e => e.Id == id);
        //}
    }
}
