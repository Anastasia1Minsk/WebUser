using WebUser.Models;
using WebUser.Repositories.Interfaces;
using WebUser.Services.Interfaces;

namespace WebUser.Services
{
    public class RoleService : Service<Role>, IRoleService
    {
        public RoleService(IRoleRepository repository) : base(repository)
        {
        }

        public async Task<bool> RolesExistAsync(List<int> ids)
        {
            var allRoles = await GetAllAsync();
            return ids.All(x => allRoles.Any(z => z.Id == x));
        }
    }
}
