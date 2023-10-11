using WebUser.Common;
using WebUser.Models;
using WebUser.Models.Enums;

namespace WebUser.Services.Interfaces
{
    public interface IUserService : IService<User>
    {           
        Task<User> GetUserByEmailAsync(string email);
        Task<bool> IsEmailUniqueAsync(string email);
        Task<Page<User>> GetPageAsync(int page, Field? sortedField, bool? isAsc, Field? filterField, string pattern);
        Task DeleteUserAsync(User user);
    }
}
