using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using WebUser.Data;
using WebUser.Models;
using WebUser.Repositories.Interfaces;

namespace WebUser.Repositories
{
    public abstract class Repository<TEntity> : RepositoryBase<TEntity>, IRepository<TEntity> where TEntity : Model, new()
    {
        protected Repository(DataContext dataContext, IMapper mapper) : base(dataContext, mapper)
        { }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await Entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TEntity> GetByIdAsync(int id, string navigationPropertyPath)
        {
            return await Entities.Include(navigationPropertyPath).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<TEntity> GetByIdAsync(int id, params string[] navigationPropertyPaths)
        {
            var query = navigationPropertyPaths.Aggregate(Entities, (entities, navigationPropertyPath) => entities.Include(navigationPropertyPath));
            return await query.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> GetByIdProjectToAsync<T>(int id)
        {
            return await Entities.Where(x => x.Id == id).ProjectTo<T>(Mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdProjectToAsync<T>(int id, string navigationPropertyPath)
        {
            return await Entities.Include(navigationPropertyPath).Where(x => x.Id == id).ProjectTo<T>(Mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdProjectToAsync<T>(int id, params string[] navigationPropertyPaths)
        {
            var query = navigationPropertyPaths.Aggregate(Entities, (entities, navigationPropertyPath) => entities.Include(navigationPropertyPath));
            return await query.Where(x => x.Id == id).ProjectTo<T>(Mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetByIdEvenDeletedAsync(int id)
        {
            return await AllEntities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> ExistsByIdAsync(int id)
        {
            return await ExistsAsync(x => x.Id == id);
        }
    }
}
