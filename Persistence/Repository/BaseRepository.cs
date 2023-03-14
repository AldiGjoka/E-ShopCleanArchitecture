using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ECommerceDbContext _context;
        public BaseRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync(int id)
        {
            T? entity = await _context.Set<T>().FindAsync(id);

            if (entity != null)
                _context.Set<T>().Remove(entity);

            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            T? entity = await _context.Set<T>().FindAsync(id);

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);

            await _context.SaveChangesAsync();
        }
    }
}
