using blog_api.DbContexts;
using blog_api.Models;
using blog_api.Repositories.Interfaces;

namespace blog_api.Repositories.Implementations
{
    public class CategoryRepository : Repository<Category, IBlogContext>, ICategoryRepository
    {
        public CategoryRepository(IBlogContext context) : base(context) { }
    }
}
