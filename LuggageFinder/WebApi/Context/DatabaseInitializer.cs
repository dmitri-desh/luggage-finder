using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApi.Models;

namespace WebApi.Context
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class DatabaseInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
        {
            base.Seed(context);
            var airports = new List<Airport>()
            {
                new Airport { Code = "SVO", Name = "Moscow"},
                new Airport { Code = "LCY", Name = "London"},
                new Airport { Code = "JFK", Name = "New York"},
                new Airport { Code = "OSL", Name = "Oslo"},
                new Airport { Code = "AMS", Name = "Amsterdam"},
                new Airport { Code = "FRA", Name = "Frankfurt"},
                new Airport { Code = "WAW", Name = "Warsaw"},
                new Airport { Code = "HND", Name = "Tokyo"},
                new Airport { Code = "MSQ", Name = "Minsk"},
                new Airport { Code = "IST", Name = "Istanbul"}
            };

            airports.ForEach(x => context.Airports.Add(x));

            context.SaveChanges();
        }
    }
}