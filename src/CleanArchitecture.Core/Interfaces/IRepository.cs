using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hogstorp.Core.Entities;
using Hogstorp.Core.SharedKernel;

namespace Hogstorp.Core.Interfaces
{
    public interface IRepository
    {
        Task<T> FindAsync<T>(int id) where T : BaseEntity;
        Task<List<T>> ListAsync<T>(Func<IQueryable<T>, IQueryable<T>> func = null) where T : BaseEntity;
        Task<T> AddAsync<T>(T entity) where T : BaseEntity;
        Task UpdateAsync<T>(T entity) where T : BaseEntity;
        Task DeleteAsync<T>(T entity) where T : BaseEntity;
    }
}
