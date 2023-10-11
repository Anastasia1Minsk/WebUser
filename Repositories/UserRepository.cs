using AutoMapper;
using WebUser.Data;
using WebUser.Models;
using WebUser.Repositories.Interfaces;

namespace WebUser.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
        }
    }
}
