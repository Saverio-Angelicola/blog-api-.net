using blog_api.Models;
using Microsoft.EntityFrameworkCore;

namespace blog_api.DbContexts
{
    public class BlogContext : DbContext, IBlogContext
    {
        public DbSet<Article>? Articles { get; set; }

        public DbSet<User>? Users { get; set; }

        public DbSet<Category>? Categories { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }
    }
}
