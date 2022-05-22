using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Context
{
    public static class InitialData
    {
        public static void Seed(this FlightsContext dbContext)
        {
            if (!dbContext.Airports.Any())
            {
                dbContext.Airports.Add(new Airport { Name = "Moscow" });
                dbContext.Airports.Add(new Airport { Name = "London" });
                dbContext.Airports.Add(new Airport { Name = "New York" });
                dbContext.Airports.Add(new Airport { Name = "Oslo" });
                dbContext.Airports.Add(new Airport { Name = "Amsterdam" });
                dbContext.Airports.Add(new Airport { Name = "Frankfurt" });
                dbContext.Airports.Add(new Airport { Name = "Warsaw" });
                dbContext.Airports.Add(new Airport { Name = "Tokyo" });
                dbContext.Airports.Add(new Airport { Name = "Minsk" });
                dbContext.Airports.Add(new Airport { Name = "Istanbul" });

                dbContext.SaveChanges();
            }
        }
    }
}
