using blog_api.Models;
using Microsoft.EntityFrameworkCore;

namespace blog_api.DbContexts
{
    public interface IBlogContext
    {
        DbSet<Article>? Articles { get; set; }
        DbSet<User>? Users { get; set; }
        DbSet<Category>? Categories { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
