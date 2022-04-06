using RestCT.Shared.Models;

namespace RestCT.BusinessLogic.Services.Interfaces
{
    public interface ICategoryService
    {
        Task CreateCategory(Category request);
        Task<IEnumerable<Category>> GetCategories();
        Task UpdateCategory(Category request);
        Task DeleteCategory(int id);
    }
}
