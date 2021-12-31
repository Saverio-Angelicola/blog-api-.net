using blog_api.Dtos.Categories;
using blog_api.Models;
using blog_api.Services.Interfaces.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace blog_api.Controllers
{
    [Route("api/v1/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<List<Category>> GetAllCategories()
        {
            try
            {
                return Ok(categoryService.GetAllCategories().ToList());
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<ActionResult<Category>> AddCategory(CategoryDto category)
        {
            try
            {
                return Ok(await categoryService.Add(category));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<Category>> UpdateCategory([FromRoute(Name = "id")] int id, CategoryDto category)
        {
            try
            {
                return await categoryService.Update(id, category.Name);
            }
            catch(Exception)
            {
                return NotFound();
            }
            
        }
    }
}
