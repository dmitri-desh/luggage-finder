using DAL.Entities;
using System;

namespace BLL.Services.Models.Flight
{
    public class FlightResultSet
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DestinationAddress { get; set; }
        public string TrackNumber { get; set; }
        public Status? Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int? ArrivalAirportId { get; set; }
        public int? DepartureAirportId { get; set; }
    }
}
