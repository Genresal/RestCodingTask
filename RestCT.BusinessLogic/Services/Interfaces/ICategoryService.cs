using RestCT.Shared.Models;
using RestCT.Shared.Requests;
using RestCT.Shared.Responses;

namespace RestCT.BusinessLogic.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<GetCategoryResponse> CreateCategory(CreateCategoryRequest request);
        Task<IEnumerable<GetCategoryResponse>> GetCategories();
        Task<GetCategoryResponse> GetCategoryById(int id);
        Task UpdateCategory(CreateCategoryRequest request);
        Task DeleteCategory(int id);
    }
}
