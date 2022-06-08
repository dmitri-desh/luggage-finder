using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace DAL.Context
{
    public class AppConfiguration
    {
        public AppConfiguration()
        {
            ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
           
            string path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
           
            configurationBuilder.AddJsonFile(path, false);
           
            IConfigurationRoot root = configurationBuilder.Build();
            
            IConfigurationSection appSettings = root.GetSection("ConnectionStrings:FlightsConnectionString");
           
            SqlConnectionString = appSettings.Value;
        }

        public String SqlConnectionString { get; set; }
    }
}
