using AutoMapper;
using PersonInfo.Dtos;
using PersonInfo.Models;

namespace PersonInfo.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<PersonCreateDto, Person>();
        }
    }
}
