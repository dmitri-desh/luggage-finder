using AutoMapper;
using LuggageFinder.Application.Common.Mappings;
using LuggageFinder.Application.Flights.Commands.UpdateFlight;

namespace LuggageFinder.WebApi.Models
{
    public class UpdateFlightDto : IMapWith<UpdateFlightCommand>
    {
        public long Id { get; set; }
        public string? DestinationAddress { get; set; }
        public long? ArrivalAirportId { get; set; }
        public long? DepartureAirportId { get; set; }
        public int Status { get; set; }
        public string TrackNumber {get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateFlightDto, UpdateFlightCommand>()
                .ForMember(flightCommand => flightCommand.Id,
                    opt => opt.MapFrom(flightDto => flightDto.Id))
                .ForMember(flightCommand => flightCommand.DestinationAddress, 
                    opt => opt.MapFrom(flightDto => flightDto.DestinationAddress))
                .ForMember(flighCommand => flighCommand.ArrivalAirportId, 
                    opt => opt.MapFrom(flightDto => flightDto.ArrivalAirportId))
                .ForMember(flightCommand => flightCommand.DepartureAirportId, 
                    opt => opt.MapFrom(flightDto => flightDto.DepartureAirportId))
                .ForMember(flightCommand => flightCommand.TrackNumber, 
                    opt => opt.MapFrom(flightDto => flightDto.TrackNumber))
                .ForMember(flighCommand => flighCommand.Status, 
                    opt => opt.MapFrom(flightDto => flightDto.Status));
        }
    }
}
