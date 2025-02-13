using AutoMapper;
using DoraTourist.API.Dtos;
using DoraTourist.API.Models;

namespace DoraTourist.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForDetailedDto>();
            CreateMap<Hotel, HotelForListDto>();
            CreateMap<Hotel, HotelForDetailedDto>();

            CreateMap<ReviewForCreationDto, Review>().ReverseMap();
        }
    }
}