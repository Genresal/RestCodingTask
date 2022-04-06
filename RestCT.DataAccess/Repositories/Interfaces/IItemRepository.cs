using RestCT.Shared.Models;
using RestCT.Shared.Requests;

namespace RestCT.DataAccess.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Task CreateItem(Item request);
        Task<IEnumerable<Item>> GetItems(FilteringParameters parameters);
        Task UpdateItem(Item request);
        Task DeleteItem(int id);
    }
}
