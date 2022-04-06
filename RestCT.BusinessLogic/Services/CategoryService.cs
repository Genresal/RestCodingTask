using RestCT.BusinessLogic.Services.Interfaces;
using RestCT.DataAccess.Repositories.Interfaces;
using RestCT.Shared.Models;

namespace RestCT.BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task CreateCategory(Category request)
        {
            await _categoryRepository.CreateCategory(request);
        }

        public async Task DeleteCategory(int id)
        {
            await _categoryRepository.DeleteCategory(id);
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _categoryRepository.GetCategories();
        }

        public async Task UpdateCategory(Category request)
        {
            await _categoryRepository.UpdateCategory(request);
        }
    }
}