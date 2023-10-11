using WebUser.Models;

namespace WebUser.Services.Interfaces
{
    public interface IRelationshipService : IServiceBase<Relationship>
    {
        Task DeleteByUserAsync(int userId);
    }
}
