using RestCT.Shared.Models;
using RestCT.Shared.Requests;

namespace RestCT.BusinessLogic.Services.Interfaces
{
    public interface IItemService
    {
        Task CreateItem(Item request);
        Task<IEnumerable<Item>> GetItems(FilteringParameters parameters);
        Task UpdateItem(Item request);
        Task DeleteItem(int id);
    }
}
