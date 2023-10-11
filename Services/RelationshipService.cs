using WebUser.Models;
using WebUser.Repositories.Interfaces;
using WebUser.Services.Interfaces;

namespace WebUser.Services
{
    public class RelationshipService : ServiceBase<Relationship>, IRelationshipService
    {
        public RelationshipService(IRelationshipRepository repository) : base(repository)
        {
        }

        public async Task DeleteByUserAsync(int userId)
        {
            var list = await RepositoryBase.GetAsync(x => x.UserId == userId);
            await RepositoryBase.ForcedDeleteAsync(list);
        }
    }
}
