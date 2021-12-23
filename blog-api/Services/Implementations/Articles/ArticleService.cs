using blog_api.Dtos.Articles;
using blog_api.Models;
using blog_api.Repositories.Interfaces;
using blog_api.Services.Interfaces.Articles;
using blog_api.Services.Interfaces.Categories;

namespace blog_api.Services.Implementations.Users
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly ICategoryService _categoryService;

        public ArticleService(IArticleRepository articleRepository, ICategoryService categoryService)
        {
            _articleRepository = articleRepository;
            _categoryService = categoryService;
        }

        public async Task<Article> Create(CreateArticleDto newArticle)
        {
            try
            {
                Category category = _categoryService.GetCategoryById(newArticle.CategoryId);
                Article article = new(newArticle.Title, newArticle.Content, newArticle.Author);
                article.Category = category;
                Article createdArticle = await _articleRepository.Create(article);
                return createdArticle;
            }
            catch (Exception)
            {
                throw new Exception("Article creation failed!");
            }

        }

        public async Task<Article> Delete(int id)
        {
            Article article = _articleRepository.FindById(id);

            return await _articleRepository.Delete(article);
        }

        public Article GetArticle(int id)
        {
            try
            {
                return _articleRepository.FindById(id);
            }
            catch (Exception)
            {
                throw new Exception("Article with id " + id + " not found !");
            }

        }

        public async Task<List<Article>> GetArticleByCategory(int CategoryId)
        {
            return await _articleRepository.FindByCategory(CategoryId);
        }

        public List<Article> GetArticles()
        {
            return _articleRepository.FindAll();
        }

        public async Task<Article> Update(int id, UpdateArticleDto updatedArticle)
        {
            Article currentArticle = _articleRepository.FindById(id);
            if (currentArticle != null)
            {
                if (updatedArticle.Title != null && updatedArticle.Title.Length > 0 && updatedArticle.Title != currentArticle.Title)
                {
                    currentArticle.Title = updatedArticle.Title;
                }

                if (updatedArticle.Content != null && updatedArticle.Content.Length > 0 && updatedArticle.Content != currentArticle.Content)
                {
                    currentArticle.Content = updatedArticle.Content;
                }

                if (updatedArticle.CategoryId != null && updatedArticle.CategoryId > 0 && updatedArticle.CategoryId != currentArticle.CategoryId)
                {
                    Category? category = _categoryService.GetCategoryById((int)updatedArticle.CategoryId);

                    if (category != null)
                    {
                        currentArticle.Category = category;
                    }
                    else
                    {
                        throw new Exception("Category doesn't exist!");
                    }
                }

                currentArticle.UpdatedDate = DateTime.UtcNow;
                return await _articleRepository.Update(currentArticle);
            }
            throw new Exception("Article with id " + id + " not found ");
        }
    }
}
