using Microsoft.Extensions.Caching.Memory;
using RestCT.BusinessLogic.Services.Interfaces;
using RestCT.DataAccess.Repositories.Interfaces;
using RestCT.Shared.Models;

namespace RestCT.BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private IMemoryCache _cache;

        public CategoryService(ICategoryRepository categoryRepository, IMemoryCache cache)
        {
            _categoryRepository = categoryRepository;
            _cache = cache;
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
            var cacheKey = "categories";
            IEnumerable<Category> categories = null;
            if (!_cache.TryGetValue(cacheKey, out categories))
            {
                categories = await _categoryRepository.GetCategories();
                if (categories is not null)
                {
                    var cacheExpiryOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                        Priority = CacheItemPriority.High,
                        SlidingExpiration = TimeSpan.FromMinutes(2)
                    };
                    _cache.Set(cacheKey, categories, cacheExpiryOptions);
                }
            }

            return categories;
        }

        public async Task UpdateCategory(Category request)
        {
            await _categoryRepository.UpdateCategory(request);
        }
    }
}
