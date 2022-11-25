using LuggageFinder.Application.Common.Mappings;
using LuggageFinder.Domain;
using AutoMapper;

namespace LuggageFinder.Application.Flights.Queries.GetFlightDetails
{
    public class FlightDetailsVm : IMapWith<Flight>
    {
        public long? Id { get; set; }
        public long UserId { get; set; }
        public string DestinationAddress { get; set; }
        public string TrackNumber { get; set; }
        public Status? Status { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ModificationDate { get; set; }
        public long? ArrivalAirportId { get; set; }
        public long? DepartureAirportId { get; set; }

        public virtual Airport? ArrivalAirport { get; set; }
        public virtual Airport? DepartureAirport { get; set; }
        public virtual User User { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Flight, FlightDetailsVm>()
                .ForMember(flightVm => flightVm.TrackNumber, opt => opt.MapFrom(flight => flight.TrackNumber))
                .ForMember(flightVm => flightVm.DestinationAddress, opt => opt.MapFrom(flight => flight.DestinationAddress))
                .ForMember(flightVm => flightVm.Status, opt => opt.MapFrom(flight => flight.Status))
                .ForMember(flightVm => flightVm.CreationDate, opt => opt.MapFrom(flight => flight.CreationDate))
                .ForMember(flightVm => flightVm.ModificationDate, opt => opt.MapFrom(flight => flight.ModificationDate))
                .ForMember(flightVm => flightVm.ArrivalAirportId, opt => opt.MapFrom(flight => flight.ArrivalAirportId))
                .ForMember(flightVm => flightVm.DepartureAirportId, opt => opt.MapFrom(flight => flight.DepartureAirportId))
                .ForMember(flightVm => flightVm.ArrivalAirport, opt => opt.MapFrom(flight => flight.ArrivalAirport))
                .ForMember(flightVm => flightVm.DepartureAirport, opt => opt.MapFrom(flight => flight.DepartureAirport))
                .ForMember(flightVm => flightVm.UserId, opt => opt.MapFrom(flight => flight.UserId))
                .ForMember(flightVm => flightVm.User, opt => opt.MapFrom(flight => flight.User));
        }
    }
}
