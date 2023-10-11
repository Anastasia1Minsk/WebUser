using WebUser.Repositories.Interfaces;
using WebUser.Services.Interfaces;

namespace WebUser.Services
{
    public abstract class ServiceBase<TEntity> : IServiceBase<TEntity>
    {
        protected IRepositoryBase<TEntity> RepositoryBase;

        protected ServiceBase(IRepositoryBase<TEntity> repository)
        {
            RepositoryBase = repository;
        }

        public virtual async Task<List<TEntity>> GetAllAsync()
        {
            return await RepositoryBase.GetAllAsync();
        }

        public virtual async Task InsertAsync(TEntity model)
        {
            await RepositoryBase.InsertAsync(model);
        }

        public virtual async Task InsertAsync(IEnumerable<TEntity> models)
        {
            await RepositoryBase.InsertAsync(models);
        }

        public virtual async Task UpdateAsync(TEntity model)
        {
            await RepositoryBase.UpdateAsync(model);
        }

        public virtual async Task UpdateAsync(IEnumerable<TEntity> models)
        {
            await RepositoryBase.UpdateAsync(models);
        }
    }
}
