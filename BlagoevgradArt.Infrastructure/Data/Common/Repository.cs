using BlagoevgradArt.Data;
using Microsoft.EntityFrameworkCore;

namespace BlagoevgradArt.Infrastructure.Data.Common
{
    public class Repository : IRepository
    {
        private readonly ApplicationDbContext _context;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> AllAsync<T>() where T : class
            => DbSet<T>().AsNoTracking();

        public IQueryable<T> AllAsReadOnlyAsync<T>() where T : class
            => DbSet<T>();

        public async Task AddAsync<T>(T entity) where T : class
            => await _context.AddAsync(entity);

        public async Task<int> SaveChangesAsync()
            => await _context.SaveChangesAsync();

        public async Task<T?> GetByIdAsync<T>(object id) where T : class
            => await DbSet<T>().FindAsync(id);

        public void Remove<T>(T entity) where T : class
            => DbSet<T>().Remove(entity);

        private DbSet<T> DbSet<T>() where T : class
            => _context.Set<T>();
    }
}
