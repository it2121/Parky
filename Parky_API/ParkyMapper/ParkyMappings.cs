using AutoMapper;
using Parky_API.Models;
using Parky_API.Models.Dtos;

namespace Parky_API.ParkyMapper
{
    public class ParkyMappings :Profile
    {
        public ParkyMappings()
        {
            CreateMap<NationalPark, NationalParkDto>().ReverseMap();
            CreateMap<Trail, TrailDto>().ReverseMap();
            CreateMap<Trail, TrailUpdateDto>().ReverseMap();
            CreateMap<Trail, TrailCreateDto>().ReverseMap();

        }



    }
}
