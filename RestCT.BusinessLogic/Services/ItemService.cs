using RestCT.BusinessLogic.Services.Interfaces;
using RestCT.DataAccess.Repositories.Interfaces;
using RestCT.Shared.Models;

namespace RestCT.BusinessLogic.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task CreateItem(Item request)
        {
            await _itemRepository.CreateItem(request);
        }

        public async Task DeleteItem(int id)
        {
            await _itemRepository.DeleteItem(id);
        }

        public async Task<IEnumerable<Item>> GetItems()
        {
            return await _itemRepository.GetItems();
        }

        public async Task UpdateItem(Item request)
        {
            await _itemRepository.UpdateItem(request);
        }
    }
}