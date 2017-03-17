using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Profile.Data
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        private DataContext<TEntity> context;

        public IQueryable<TEntity> Table
        {
            get { return context.Set<TEntity>().AsQueryable(); }
        }

        public Repository()
        {
            context = new DataContext<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> AllAsync()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync<TKey>(TKey id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await context.Set<TEntity>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            context.Set<TEntity>().Update(entity);
            await context.SaveChangesAsync();
        }

        #region IDisposable Members
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            Dispose(true);
        }
        #endregion
    }
}
