using blog_api.Dtos.Categories;
using blog_api.Models;

namespace blog_api.Services.Interfaces.Categories
{
    public interface ICategoryService
    {
        Task<Category> Add(CategoryDto createdCategory);
        Task<Category> Delete(int id);
        Task<Category> Update(int id, CategoryDto category);
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
    }
}
