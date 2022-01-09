﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApi.Context;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class AirportController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/Airport
        public IQueryable<Airport> GetAirports()
        {
            return db.Airports;
        }

        // GET: api/Airport/5
        [ResponseType(typeof(Airport))]
        public IHttpActionResult GetAirport(int id)
        {
            Airport airport = db.Airports.Find(id);
            if (airport == null)
            {
                return NotFound();
            }

            return Ok(airport);
        }

        // PUT: api/Airport/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAirport(int id, Airport airport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != airport.Id)
            {
                return BadRequest();
            }

            db.Entry(airport).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AirportExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Airport
        [ResponseType(typeof(Airport))]
        public IHttpActionResult PostAirport(Airport airport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Airports.Add(airport);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = airport.Id }, airport);
        }

        // DELETE: api/Airport/5
        [ResponseType(typeof(Airport))]
        public IHttpActionResult DeleteAirport(int id)
        {
            Airport airport = db.Airports.Find(id);
            if (airport == null)
            {
                return NotFound();
            }

            db.Airports.Remove(airport);
            db.SaveChanges();

            return Ok(airport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AirportExists(int id)
        {
            return db.Airports.Count(e => e.Id == id) > 0;
        }
    }
}