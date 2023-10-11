using AutoMapper;
using WebUser.Data;
using WebUser.Models;
using WebUser.Repositories.Interfaces;

namespace WebUser.Repositories
{
    public class RoleRepository : Repository<Role>, IRoleRepository
    {
        public RoleRepository(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
        }
    }
}
