using AutoMapper;
using LuggageFinder.Application.Common.Mappings;
using LuggageFinder.Domain;

namespace LuggageFinder.Application.Flights.Queries.GetFlightList
{
    public class FlightLookupDto : IMapWith<Flight>
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string TrackNumber { get; set; }
        public Status? Status { get; set; }
        public DateTime CreationDate { get; set; }
        public long? ArrivalAirportId { get; set; }
        public long? DepartureAirportId { get; set; }

        public virtual Airport? ArrivalAirport { get; set; }
        public virtual Airport? DepartureAirport { get; set; }
        public virtual User User { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Flight, FlightLookupDto>()
                .ForMember(flightDto => flightDto.Id, opt => opt.MapFrom(fligth => fligth.Id))
                .ForMember(flightDto => flightDto.UserId, opt => opt.MapFrom(fligth => fligth.UserId))
                .ForMember(flightDto => flightDto.User, opt => opt.MapFrom(fligth => fligth.User))
                .ForMember(flightDto => flightDto.Status, opt => opt.MapFrom(fligth => fligth.Status))
                .ForMember(flightDto => flightDto.TrackNumber, opt => opt.MapFrom(fligth => fligth.TrackNumber))
                .ForMember(flightDto => flightDto.CreationDate, opt => opt.MapFrom(fligth => fligth.CreationDate))
                .ForMember(flightDto => flightDto.ArrivalAirportId, opt => opt.MapFrom(fligth => fligth.ArrivalAirportId))
                .ForMember(flightDto => flightDto.ArrivalAirport, opt => opt.MapFrom(fligth => fligth.ArrivalAirport))
                .ForMember(flightDto => flightDto.DepartureAirportId, opt => opt.MapFrom(fligth => fligth.DepartureAirportId))
                .ForMember(flightDto => flightDto.DepartureAirport, opt => opt.MapFrom(fligth => fligth.DepartureAirport));
        }

    }
}
