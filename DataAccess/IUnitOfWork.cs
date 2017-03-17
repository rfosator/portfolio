namespace Profile.Data
{
    public interface IUnitOfWork
    {
        IRepository<TEntity> Get<TEntity>()
            where TEntity : class;
    }
}
