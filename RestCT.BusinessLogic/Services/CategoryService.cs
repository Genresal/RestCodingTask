using Microsoft.Extensions.Caching.Memory;
using RestCT.BusinessLogic.Services.Interfaces;
using RestCT.DataAccess.Repositories.Interfaces;
using RestCT.Shared.Models;
using System.Linq;
using AutoMapper;
using RestCT.Shared.Requests;
using RestCT.Shared.Responses;


namespace RestCT.BusinessLogic.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepository<Category> _categoryRepository;
        private readonly IMemoryCache _cache;
        private readonly IMapper _mapper;

        public CategoryService(IRepository<Category> categoryRepository, IMemoryCache cache, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _cache = cache;
            _mapper = mapper;
        }
        public async Task<GetCategoryResponse> CreateCategory(CreateCategoryRequest request)
        {
            var category = _mapper.Map<Category>(request);
            await _categoryRepository.Create(category);
            var response = _mapper.Map<GetCategoryResponse>(category);
            return response;
        }

        public async Task DeleteCategory(int id)
        {
            await _categoryRepository.Delete(id);
        }

        public async Task<IEnumerable<GetCategoryResponse>> GetCategories()
        {
            var cacheKey = "categories";
            List<Category> categories = null;
            if (!_cache.TryGetValue(cacheKey, out categories))
            {
                categories = (await _categoryRepository.Get()).ToList();
                if (categories.Any())
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

            var responce = _mapper.Map<IEnumerable<GetCategoryResponse>>(categories);
            return responce;
        }

        public async Task<GetCategoryResponse> GetCategoryById(int id)
        {
            var cacheKey = "category";
            Category category = null;
            if (!_cache.TryGetValue(cacheKey, out category))
            {
                category = (await _categoryRepository.GetById(id));
                if (category is not null)
                {
                    var cacheExpiryOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                        Priority = CacheItemPriority.High,
                        SlidingExpiration = TimeSpan.FromMinutes(2)
                    };
                    _cache.Set(cacheKey, category, cacheExpiryOptions);
                }
            }

            var responce = _mapper.Map<GetCategoryResponse>(category);
            return responce;
        }

        public async Task UpdateCategory(CreateCategoryRequest request)
        {
            var category = _mapper.Map<Category>(request);
            await _categoryRepository.Update(category);
        }
    }
}
