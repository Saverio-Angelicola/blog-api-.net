using blog_api.Models;

namespace blog_api.Repositories.Interfaces
{
    public interface IArticleRepository : IRepository<Article>
    {
        Task<List<Article>> FindByCategory(int CategoryId);
    }
}
