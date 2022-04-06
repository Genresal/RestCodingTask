using RestCT.Shared.Models;

namespace RestCT.DataAccess.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        Task CreateCategory(Category request);
        Task<IEnumerable<Category>> GetCategories();
        Task UpdateCategory(Category request);
        Task DeleteCategory(int id);
    }
}
