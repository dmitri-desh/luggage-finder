using System.Linq;
using DAL.Entities;
using DAL.Entities.Auth;

namespace DAL.Context
{
    public static class InitialData
    {
        public static void Seed(this DatabaseContext dbContext)
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

            if (!dbContext.Roles.Any())
            {
                dbContext.Roles.Add(new Role { Name = "Admin" });
                dbContext.Roles.Add(new Role { Name = "Customer" });

                dbContext.SaveChanges();
            }
        }
    }
}
