using DAL.Context;
using DAL.Entities;
using DAL.Functions.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Functions.Specific
{
    public class AirportOperations : IAirportOperations
    {
        public async Task<Airport> GetAirportById(int id)
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    return await context.Airports.FirstOrDefaultAsync(f => f.Id == id);
                }
            }
            catch
            {
                throw new NotImplementedException();
            }
        }

        public async Task<List<Airport>> GetAllAirports()
        {
            try
            {
                using (var context = new DatabaseContext(DatabaseContext.Options.DatabaseOptions))
                {
                    return await context.Airports.ToListAsync();
                }
            }
            catch
            {
                throw new NotImplementedException();
            }
        }
    }
}
