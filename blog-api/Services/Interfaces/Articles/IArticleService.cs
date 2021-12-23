using blog_api.Dtos.Articles;
using blog_api.Models;

namespace blog_api.Services.Interfaces.Articles
{
    public interface IArticleService
    {
        List<Article> GetArticles();
        Article GetArticle(int id);
        Task<List<Article>> GetArticleByCategory(int CategoryId);
        Task<Article> Create(CreateArticleDto newArticle);
        Task<Article> Update(int id, UpdateArticleDto updatedArticle);
        Task<Article> Delete(int id);
    }
}
