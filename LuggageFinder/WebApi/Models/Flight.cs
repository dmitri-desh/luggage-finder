using System;

namespace WebApi.Models
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
    public class Flight
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Airport Departure { get; set; }
        public Airport Arrival { get; set; }
        public string TrackNumber { get; set; }
        public Status Status { get; set; }
        public DateTime Date { get; set; }
    }
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
}