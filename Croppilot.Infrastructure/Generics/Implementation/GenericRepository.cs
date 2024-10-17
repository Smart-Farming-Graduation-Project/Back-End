using Croppilot.Infrastructure.Data;
using Croppilot.Infrastructure.Generics.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Reflection.Metadata.Ecma335;

namespace Croppilot.Infrastructure.Generics.Implementation
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _context;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }


        public async Task<bool> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return await SaveChanges();
        }

        public async Task<bool> Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return await SaveChanges();
        }


        public async Task<bool> Delete(T entity)
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
