using blog_api.Dtos.Categories;
using blog_api.Models;
using blog_api.Repositories.Interfaces;
using blog_api.Services.Interfaces.Categories;

namespace blog_api.Services.Implementations.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        public async Task<Category> Add(CategoryDto createdCategory)
        {
            Category category = new(createdCategory.Name);
            return await categoryRepository.Create(category);
        }

        public async Task<Category> Update(int id, CategoryDto category)
        {
            Category updatedCategory = categoryRepository.FindById(id);
            updatedCategory.Name = name;
            return await categoryRepository.Update(updatedCategory);
        }

        public async Task<Category> Delete(int id)
        {
            Category deletedCategory = categoryRepository.FindById(id);
            return await categoryRepository.Delete(deletedCategory);
        }

        public List<Category> GetAllCategories()
        {
            List<Category> categories = categoryRepository.FindAll();
            return categories;
        }

        public Category GetCategoryById(int id)
        {
            Category category = categoryRepository.FindById(id);
            return category;
        }
    }
}
