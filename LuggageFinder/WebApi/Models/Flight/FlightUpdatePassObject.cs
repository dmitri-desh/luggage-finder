using System;

namespace WebApi.Models.Flight
{
    public class FlightUpdatePassObject : FlightPassObject
    {
        public int Id { get; set; }
        public int Status { get; set; }
        public DateTime ModificationDate { get; set; }
    }
}
