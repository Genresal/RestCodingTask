using RestCT.Shared.Requests;
using RestCT.Shared.Responses;

namespace RestCT.BusinessLogic.Services.Interfaces
{
    public interface IItemService
    {
        Task<GetItemResponse> CreateItem(CreateItemRequest request);
        Task<IEnumerable<GetItemResponse>> GetItems(FilteringParameters parameters);
        Task<GetItemResponse> GetItemById(int id);
        Task UpdateItem(CreateItemRequest request);
        Task DeleteItem(int id);
    }
}
