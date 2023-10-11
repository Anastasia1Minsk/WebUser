using WebUser.Models;

namespace WebUser.Services.Interfaces
{
    public interface IRoleService : IService<Role>
    {
        Task<bool> RolesExistAsync(List<int> ids);
    }
}
