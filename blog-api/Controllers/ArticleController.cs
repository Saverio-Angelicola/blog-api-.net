using blog_api.Dtos.Articles;
using blog_api.Models;
using blog_api.Services.Interfaces.Articles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace blog_api.Controllers
{
    [Route("api/v1/article")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        private readonly IArticleService articleService;
        private readonly ILogger<ArticleController> _logger;

        public ArticleController(IArticleService articleService, ILogger<ArticleController> logger)
        {
            this.articleService = articleService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<Article>> GetArticles()
        {
            try
            {
                return Ok(articleService.GetArticles());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Article> GetArticle([FromRoute(Name = "id")] int id)
        {
            try
            {
                return Ok(articleService.GetArticle(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("category/{categoryId}")]
        public async Task<ActionResult<List<Article>>> GetByCategory([FromRoute(Name = "categoryId")] int categoryId)
        {
            try
            {
                return Ok(await articleService.GetArticleByCategory(categoryId));
            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<Article>> AddArticle(CreateArticleDto newArticle)
        {
            try
            {
                Article createdArticle = await articleService.Create(newArticle);
                _logger.LogInformation("Successful article creation!");
                return Ok(createdArticle);
            }
            catch (Exception)
            {
                _logger.LogError("Failed to create a new article!");
                return BadRequest();
            }
        }

        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Article>> UpdateArticle([FromRoute(Name = "id")] int id, UpdateArticleDto article)
        {
            try
            {
                Article updatedArticle = await articleService.Update(id, article);
                _logger.LogInformation("Successful updated article");
                return Ok(updatedArticle);
            }
            catch (Exception)
            {
                _logger.LogError("Failed to update article with id!");
                return NotFound();
            }
        }

        [HttpDelete("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Article>> DeleteArticle([FromRoute(Name = "id")] int id)
        {
            try
            {
                Article deletedArticle = await articleService.Delete(id);
                _logger.LogInformation("successful deleted article");
                return Ok(deletedArticle);
            }
            catch (Exception)
            {
                _logger.LogError("Failed to delete article with id!");
                return NotFound();
            }
        }
    }
}
