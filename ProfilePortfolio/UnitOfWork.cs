using System;
using Profile.Data;
using Autofac;

namespace ProfilePortfolio
{
    public class UnitOfWork : IUnitOfWork
    {
        private IComponentContext context;
        public UnitOfWork(IComponentContext context)
        {
            this.context = context;
        }

        public IRepository<TEntity> Get<TEntity>() where TEntity : class
        {
            return context.Resolve<IRepository<TEntity>>();
        }
    }
}
