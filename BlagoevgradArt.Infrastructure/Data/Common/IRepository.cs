namespace BlagoevgradArt.Infrastructure.Data.Common
{
    public interface IRepository
    {
        IQueryable<T> AllAsync<T>() where T : class;

        IQueryable<T> AllAsReadOnlyAsync<T>() where T : class;

        Task AddAsync<T>(T entity) where T : class;

        Task<int> SaveChangesAsync();
    }
}
