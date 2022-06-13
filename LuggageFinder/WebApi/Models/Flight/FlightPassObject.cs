using System;
using WebApi.Models.Airport;

namespace WebApi.Models.Flight
{
    public class FlightPassObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DestinationAddress { get; set; }
        public string Phone { get; set; }
        public string TrackNumber { get; set; }
        public DateTime CreationDate { get; set; }
        public int DepartureAirportId { get; set; }
        public int ArrivalAirportId { get; set; }

        public AirportPassObject DepartureAirport { get; set; }
        public AirportPassObject ArrivalAirport { get; set; }
    }
}
