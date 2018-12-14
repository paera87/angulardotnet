using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hogstorp.Core.Entities;
using Hogstorp.Core.Interfaces;
using Hogstorp.Core.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Hogstorp.Infrastructure.Data
{
    public class EfRepository : IRepository
    {
        private readonly AppDbContext _dbContext;

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> GetByIdAsync<T>(int id) where T : BaseEntity
        {
            return await _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<List<T>> ListAsync<T>(Func<IQueryable<T>, IQueryable<T>> func = null) where T : BaseEntity
        {
            DbSet<T> result = _dbContext.Set<T>();
            if (func == null) return await _dbContext.Set<T>().ToListAsync();
            IQueryable<T> additionalQueries = func(result);
            return await additionalQueries.ToListAsync();

        }

        public async Task<T> AddAsync<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task DeleteAsync<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(T entity) where T : BaseEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
