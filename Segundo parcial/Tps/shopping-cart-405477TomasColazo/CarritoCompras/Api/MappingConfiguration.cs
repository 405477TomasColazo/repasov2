using Api.Domain;
using Api.Dtos;
using AutoMapper;

namespace Api
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration()
        {
            CreateMap<User, UserDto>();
        }
    }
}
