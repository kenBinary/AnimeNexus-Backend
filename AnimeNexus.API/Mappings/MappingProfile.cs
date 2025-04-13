using AutoMapper;
using backend.AnimeNexus.API.Domain.DTOs;
using backend.AnimeNexus.API.Domain.Entities;

namespace backend.AnimeNexus.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
        }
    }
}