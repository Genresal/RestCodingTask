using RestCT.Shared.Models;

namespace RestCT.DataAccess.Repositories.Interfaces
{
    public interface IItemRepository
    {
        Task CreateItem(Item request);
        Task<IEnumerable<Item>> GetItems();
        Task UpdateItem(Item request);
        Task DeleteItem(int id);
    }
}
