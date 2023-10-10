using Microsoft.EntityFrameworkCore;
using ShopABC.AppDbContext;
using ShopABC.Interfaces;

namespace ShopABC.Repositories
{
    public class GenericRepository<T> : IGenericRespository<T> where T : class
    {
        private readonly ShopABCContext _context;

        public GenericRepository(ShopABCContext context)
        {
            _context = context;
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task<T> DeleteAsync(int id)
        {
            var entity = _context.Set<T>().FindAsync(id);
            var isDelete = _context.Set<T>().Remove(entity.Result);
            await _context.SaveChangesAsync();
            return isDelete.Entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            var entityEntry = _context.Set<T>().Update(entity);
            return entityEntry.Entity;
        }
    }

}
