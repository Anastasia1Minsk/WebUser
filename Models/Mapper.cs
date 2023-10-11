using AutoMapper;
using WebUser.ModelsDto;

namespace WebUser.Models
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<User, UserReturnDto>()
                .ForMember(dest => dest.Roles,
                    opt => opt
                        .MapFrom(src => src.Relations.Select(x => x.Role)));
            CreateMap<Role, RoleReturnDto>();
        }
    }
}
