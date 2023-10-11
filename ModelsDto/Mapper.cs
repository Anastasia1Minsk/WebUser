using AutoMapper;
using WebUser.Models;

namespace WebUser.ModelsDto
{
    public class Mapper : Profile
    {
        public Mapper() 
        {
            CreateMap<NewUserDto, User>();
            CreateMap<NewRelationDto, Relationship>();
            CreateMap<UserDto, User>();
        }
    }
}
