using AutoMapper;
using PersonsApi.Domain;
using PersonsApi.Dto;

namespace PersonsApi
{
    public class MappingConfiguration : Profile
    {
        public MappingConfiguration() 
        {
            CreateMap<UpdatePersonDto, Person>()
                .ForMember(dest => dest.Id, source => source.MapFrom(x => Guid.Parse(x.Id)));

            CreateMap<Person, PersonDto>()
                .ForMember(dest => dest.Id, source => 
                    source.MapFrom(x => x.Id.ToString().Replace("-", string.Empty)));
        }
    }
}
