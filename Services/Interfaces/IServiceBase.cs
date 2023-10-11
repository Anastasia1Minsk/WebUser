namespace WebUser.Services.Interfaces
{
    public interface IServiceBase<TEntity>
    {
        Task<List<TEntity>> GetAllAsync();
        Task InsertAsync(TEntity model);
        Task InsertAsync(IEnumerable<TEntity> models);
        Task UpdateAsync(TEntity model);
        Task UpdateAsync(IEnumerable<TEntity> models);
    }
}
