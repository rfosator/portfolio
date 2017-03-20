using Microsoft.EntityFrameworkCore;

namespace Profile.Data
{
    public class DataContext<TEntity> : DbContext where TEntity : class
    {        
        public DataContext()
        {
        }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAGASH\SQLEXPRESS;Initial Catalog=profile;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TEntity>();
        }
    }    
}
