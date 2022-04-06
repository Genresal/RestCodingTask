using RestCT.BusinessLogic.Services.Interfaces;
using RestCT.DataAccess.Repositories.Interfaces;
using RestCT.Shared.Models;
using RestCT.Shared.Requests;

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

        public async Task<IEnumerable<Item>> GetItems(FilteringParameters parameters)
        {
            return await _itemRepository.GetItems(parameters);
        }

        public async Task UpdateItem(Item request)
        {
            await _itemRepository.UpdateItem(request);
        }
    }
}
