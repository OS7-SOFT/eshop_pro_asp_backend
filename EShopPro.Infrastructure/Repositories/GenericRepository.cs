using EShopPro.Application.Intrefaces;
using EShopPro.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopPro.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<T> Entities => _dbContext.Set<T>();

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async  Task<T> AddAsync(T entity)
        {
             await _dbContext.Set<T>().AddAsync(entity);

            return entity;
        }

        public Task UpdateAsync(Guid id,T entity)
        {
            T exist = _dbContext.Set<T>().Find(id);
            _dbContext.Entry(exist).CurrentValues.SetValues(entity);

            return Task.CompletedTask;
        }

        public  Task DeleteAsync(Guid id)
        {
           _dbContext.Set<T>().FindAsync(id);

            return Task.CompletedTask;
        }
    }
}
