using Croppilot.Infrastructure.Data;
using Croppilot.Infrastructure.Generics.Interfaces;

namespace Croppilot.Infrastructure.Generics.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public virtual async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }


        public virtual async Task<bool> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await SaveChanges();
        }

        public virtual async Task<bool> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return await SaveChanges();
        }


        public virtual async Task<bool> Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return await SaveChanges();
        }

        protected async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
