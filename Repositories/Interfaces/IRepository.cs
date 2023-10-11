namespace WebUser.Repositories.Interfaces
{
    public interface IRepository<TEntity> : IRepositoryBase<TEntity>
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByIdAsync(int id, string navigationPropertyPath);
        Task<TEntity> GetByIdAsync(int id, params string[] navigationPropertyPaths);
        Task<T> GetByIdProjectToAsync<T>(int id);
        Task<T> GetByIdProjectToAsync<T>(int id, string navigationPropertyPath);
        Task<T> GetByIdProjectToAsync<T>(int id, params string[] navigationPropertyPaths);
        Task<TEntity> GetByIdEvenDeletedAsync(int id);
        Task<bool> ExistsByIdAsync(int id);
    }
}
