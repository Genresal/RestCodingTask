using AutoMapper;
using RestCT.BusinessLogic.Services.Interfaces;
using RestCT.DataAccess.Repositories.Interfaces;
using RestCT.Shared.Models;
using RestCT.Shared.Requests;
using RestCT.Shared.Responses;

namespace RestCT.BusinessLogic.Services
{
    public class ItemService : IItemService
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly IMapper _mapper;

        public ItemService(IRepository<Item> itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public async Task<GetItemResponse> CreateItem(CreateItemRequest request)
        {
            var item = _mapper.Map<Item>(request);
            await _itemRepository.Create(item);
            var response = _mapper.Map<GetItemResponse>(item);
            return response;
        }

        public async Task DeleteItem(int id)
        {
            await _itemRepository.Delete(id);
        }

        public async Task<IEnumerable<GetItemResponse>> GetItems(FilteringParameters parameters)
        {
            var start = parameters.PageSize * parameters.PageNumber;
            var data = await _itemRepository.Get();
            var result = data.Where(x => x.CategoryId == parameters.CategoryId || parameters.CategoryId == null)
                .Skip(start)
                .Take(parameters.PageSize)
                .ToList();

            return _mapper.Map<IEnumerable<GetItemResponse>>(result);
        }

        public async Task<GetItemResponse> GetItemById(int id)
        {
            var result = await _itemRepository.GetById(id);
            return _mapper.Map<GetItemResponse>(result);
        }

        public async Task UpdateItem(CreateItemRequest request)
        {
            var item = _mapper.Map<Item>(request);
            await _itemRepository.Update(item);
        }
    }
}
