using RestCT.Shared.Models;

namespace RestCT.BusinessLogic.Services.Interfaces
{
    public interface IItemService
    {
        Task CreateItem(Item request);
        Task<IEnumerable<Item>> GetItems();
        Task UpdateItem(Item request);
        Task DeleteItem(int id);
    }
}
