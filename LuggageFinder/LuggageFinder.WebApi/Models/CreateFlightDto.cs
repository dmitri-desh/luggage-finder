using AutoMapper;
using LuggageFinder.Application.Common.Mappings;
using LuggageFinder.Application.Flights.Commands.CreateFlight;
using LuggageFinder.Domain;

namespace LuggageFinder.WebApi.Models
{
    public class CreateFlightDto : IMapWith<CreateFlightCommand>
    {
        public string? DestinationAddress { get; set; }
        public long? ArrivalAirportId { get; set; }
        public long? DepartureAirportId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateFlightDto, CreateFlightCommand>()
                .ForMember(flightCommand => flightCommand.DestinationAddress, 
                    opt => opt.MapFrom(flightDto => flightDto.DestinationAddress))
                .ForMember(flighCommand => flighCommand.ArrivalAirportId,
                    opt => opt.MapFrom(flightDto => flightDto.ArrivalAirportId))
                .ForMember(flightCommand => flightCommand.DepartureAirportId,
                    opt => opt.MapFrom(flightDto => flightDto.DepartureAirportId));  
        }
    }
}
