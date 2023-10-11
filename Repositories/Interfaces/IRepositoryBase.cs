using System.Linq.Expressions;
using WebUser.Common;

namespace WebUser.Repositories.Interfaces
{
    public interface IRepositoryBase<TEntity>
    {
        // GetAll *
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsync(string navigationPropertyPath);
        Task<List<TEntity>> GetAllAsync(params string[] navigationPropertyPaths);
        Task<List<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy);
        Task<List<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, string navigationPropertyPath);
        Task<List<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, params string[] navigationPropertyPaths);
        Task<List<TEntity>> GetAllAsync(IQueryable<TEntity> query);
        Task<List<TEntity>> GetAllAsync(IQueryable<TEntity> query, string navigationPropertyPath);
        Task<List<TEntity>> GetAllAsync(IQueryable<TEntity> query, params string[] navigationPropertyPaths);
        Task<List<TEntity>> GetAllAsync(IQueryable<TEntity> query, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy);
        Task<List<TEntity>> GetAllAsync(IQueryable<TEntity> query, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, string navigationPropertyPath);
        Task<List<TEntity>> GetAllAsync(IQueryable<TEntity> query, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, params string[] navigationPropertyPaths);
        Task<List<T>> GetAllProjectToAsync<T>();
        Task<List<T>> GetAllProjectToAsync<T>(string navigationPropertyPath);
        Task<List<T>> GetAllProjectToAsync<T>(params string[] navigationPropertyPaths);
        Task<List<T>> GetAllProjectToAsync<T>(Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy);
        Task<List<T>> GetAllProjectToAsync<T>(Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, string navigationPropertyPath);
        Task<List<T>> GetAllProjectToAsync<T>(Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, params string[] navigationPropertyPaths);
        Task<List<TEntity>> GetAllWithDeletedAsync();
        // GetAllByPage *
        Task<Page<TEntity>> GetAllByPageAsync(int pageNumber, int pageSize);

        Task<Page<TEntity>> GetAllByPageAsync(int pageNumber, int pageSize, string navigationPropertyPath);

        Task<Page<TEntity>> GetAllByPageAsync(int pageNumber, int pageSize, params string[] navigationPropertyPaths);
        Task<Page<TEntity>> GetAllByPageAsync(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy);
        Task<Page<TEntity>> GetAllByPageAsync(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, string navigationPropertyPath);
        Task<Page<TEntity>> GetAllByPageAsync(int pageNumber, int pageSize, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, params string[] navigationPropertyPaths);
        // Get *
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where, string navigationPropertyPath);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where, params string[] navigationPropertyPaths);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, string navigationPropertyPath);
        Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, params string[] navigationPropertyPaths);
        Task<List<TEntity>> GetAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where);
        Task<List<TEntity>> GetAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where, string navigationPropertyPath);
        Task<List<TEntity>> GetAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where, params string[] navigationPropertyPaths);
        Task<List<TEntity>> GetAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy);
        Task<List<TEntity>> GetAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, string navigationPropertyPath);
        Task<List<TEntity>> GetAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, params string[] navigationPropertyPaths);
        // GetByPage *
        Task<Page<TEntity>> GetByPageAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> where);
        Task<Page<TEntity>> GetByPageAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> where, string navigationPropertyPath);
        Task<Page<TEntity>> GetByPageAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> where, params string[] navigationPropertyPaths);
        Task<Page<TEntity>> GetByPageAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy);
        Task<Page<TEntity>> GetByPageAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, string navigationPropertyPath);
        Task<Page<TEntity>> GetByPageAsync(int pageNumber, int pageSize, Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, params string[] navigationPropertyPaths);
        // GetProjectTo *
        Task<List<T>> GetProjectToAsync<T>(Expression<Func<TEntity, bool>> where);
        Task<List<T>> GetProjectToAsync<T>(Expression<Func<TEntity, bool>> where, string navigationPropertyPath);
        Task<List<T>> GetProjectToAsync<T>(Expression<Func<TEntity, bool>> where, params string[] navigationPropertyPaths);
        Task<List<T>> GetProjectToAsync<T>(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy);
        Task<List<T>> GetProjectToAsync<T>(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, string navigationPropertyPath);
        Task<List<T>> GetProjectToAsync<T>(Expression<Func<TEntity, bool>> where, Func<IQueryable<TEntity>, IQueryable<TEntity>> orderStrategy, params string[] navigationPropertyPaths);
        // GetFirstOrDefault *
        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> where);
        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> where, string navigationPropertyPath);
        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> where, params string[] navigationPropertyPaths);
        Task<TEntity> GetFirstOrDefaultAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where);
        Task<TEntity> GetFirstOrDefaultAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where, string navigationPropertyPath);
        Task<TEntity> GetFirstOrDefaultAsync(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> where, params string[] navigationPropertyPaths);
        Task<T> GetFirstOrDefaultProjectToAsync<T>(Expression<Func<TEntity, bool>> where);
        Task<T> GetFirstOrDefaultProjectToAsync<T>(Expression<Func<TEntity, bool>> where, string navigationPropertyPath);
        Task<T> GetFirstOrDefaultProjectToAsync<T>(Expression<Func<TEntity, bool>> where, params string[] navigationPropertyPaths);
        Task<List<TEntity>> GetWithDeletedAsync(Expression<Func<TEntity, bool>> where);
        Task InsertAsync(TEntity model);
        Task InsertAsync(IEnumerable<TEntity> models);
        Task UpdateAsync(TEntity model);
        Task UpdateAsync(IEnumerable<TEntity> models);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> where);
        Task ForcedDeleteAsync(TEntity model);
        Task ForcedDeleteAsync(IEnumerable<TEntity> models);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> where);
    }
}
