using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Profile.Data
{
    public interface IRepository<TEntity> : IDisposable 
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> AllAsync();
        Task<TEntity> GetByIdAsync<TKey>(TKey id);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
    }
}