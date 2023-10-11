using System.Linq.Expressions;
using WebUser.Common;
using WebUser.Models;
using WebUser.Models.Enums;
using WebUser.Repositories.Interfaces;
using WebUser.Services.Interfaces;

namespace WebUser.Services
{
    public class UserService : Service<User>, IUserService
    {
        private const int PageSize = 25;
        public UserService(IUserRepository repository) : base(repository)
        {
        }

        public async override Task<User> GetByIdAsync(int userId)
        {
            return await Repository.GetByIdAsync(userId, $"{nameof(User.Relations)}.{nameof(Relationship.Role)}" );
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await Repository.GetFirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            return await Repository.ExistsAsync(x => x.Email == email);
        }

        public async Task<Page<User>> GetPageAsync(int page, Field? sortedField, bool? isAsc, Field? filterField, string? pattern)
        {
            return await Repository.GetByPageAsync(page,
                                                    PageSize,
                                                    GetFilterStrategy(filterField, pattern),
                                                    GetOrderStrategy(sortedField, isAsc),
                                                    $"{nameof(User.Relations)}.{nameof(Relationship.Role)}");
        }

        public async Task DeleteUserAsync(User user)
        {
            await RepositoryBase.ForcedDeleteAsync(user);
            return;
        }

        private Func<IQueryable<User>, IQueryable<User>> GetOrderStrategy(Field? sortedField, bool? isAsc)
        {
            return sortedField switch
            {
                Field.Age => isAsc.GetValueOrDefault()
                            ? list => list.OrderBy(x => x.Age)
                            : list => list.OrderByDescending(x => x.Age),
                Field.Email => isAsc.GetValueOrDefault()
                            ? list => list.OrderBy(x => x.Email)
                            : list => list.OrderByDescending(x => x.Email),
                _ => isAsc.GetValueOrDefault() 
                            ? list => list.OrderBy(x => x.Name) 
                            : list => list.OrderByDescending(x => x.Name),                
            };
        }

        private Expression<Func<User, bool>> GetFilterStrategy(Field? filterField, string pattern)
        {
            return filterField switch
            {
                Field.UserName => x => string.IsNullOrEmpty(pattern) || x.Name.Contains(pattern),
                Field.Age      => x => string.IsNullOrEmpty(pattern) || x.Age.Equals(pattern),
                Field.Email    => x => string.IsNullOrEmpty(pattern) || x.Email.Contains(pattern),
                _ => x => true
            };
        }
    }
}
