using WebUser.Repositories.Interfaces;
using WebUser.Services.Interfaces;

namespace WebUser.Services
{
    public abstract class Service<TEntity> : ServiceBase<TEntity>, IService<TEntity>
    {
        protected IRepository<TEntity> Repository;

        protected Service(IRepository<TEntity> repository) : base(repository)
        {
            Repository = repository;
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await Repository.GetByIdAsync(id);
        }

        public virtual async Task<bool> ExistsByIdAsync(int id)
        {
            return await Repository.ExistsByIdAsync(id);
        }
    }
}
