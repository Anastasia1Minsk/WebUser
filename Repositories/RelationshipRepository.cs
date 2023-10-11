using AutoMapper;
using WebUser.Data;
using WebUser.Models;
using WebUser.Repositories.Interfaces;

namespace WebUser.Repositories
{
    public class RelationshipRepository : RepositoryBase<Relationship>, IRelationshipRepository
    {
        public RelationshipRepository(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        {
        }
    }
}
