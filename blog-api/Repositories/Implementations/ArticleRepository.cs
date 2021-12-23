using blog_api.DbContexts;
using blog_api.Models;
using blog_api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace blog_api.Repositories.Implementations
{
    public class ArticleRepository : Repository<Article, IBlogContext>, IArticleRepository
    {
        private readonly IBlogContext _context;
        public ArticleRepository(IBlogContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Article>> FindByCategory(int CategoryId)
        {
            List<Article> articles = await _context.Set<Article>().Where(a => a.CategoryId == CategoryId).Include(a => a.Category).ToListAsync();
            return articles;
        }
    }
}
