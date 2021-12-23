using blog_api.Models;

namespace blog_api.Services.Interfaces.Categories
{
    public interface ICategoryService
    {
        Task<Category> Add(string name);
        Task<Category> Delete(int id);
        Task<Category> Update(int id, string name);
        List<Category> GetAllCategories();
        Category GetCategoryById(int id);
    }
}
