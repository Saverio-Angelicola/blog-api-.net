using blog_api.Models;
using blog_api.Repositories.Interfaces;
using blog_api.Services.Interfaces.Categories;

namespace blog_api.Services.Implementations.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository repository)
        {
            this._categoryRepository = repository;
        }

        public async Task<Category> Add(string name)
        {
            Category category = new(name);
            return await _categoryRepository.Create(category);
        }

        public async Task<Category> Update(int id, string name)
        {
            Category updatedCategory = _categoryRepository.FindById(id);
            updatedCategory.Name = name;
            return await _categoryRepository.Update(updatedCategory);
        }

        public async Task<Category> Delete(int id)
        {
            Category deletedCategory = _categoryRepository.FindById(id);
            return await _categoryRepository.Delete(deletedCategory);
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categories = _categoryRepository.FindAll();
            return categories;
        }

        public Category GetCategoryById(int id)
        {
            Category category = _categoryRepository.FindById(id);
            return category;
        }
    }
}
