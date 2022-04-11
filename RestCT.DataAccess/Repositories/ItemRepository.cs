using Microsoft.EntityFrameworkCore;
using RestCT.DataAccess.Repositories.Interfaces;
using RestCT.Shared.Models;
using RestCT.Shared.Requests;

namespace RestCT.DataAccess.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private readonly RestCtDbContext _dbContext;

        public ItemRepository(RestCtDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateItem(Item request)
        {
            await _dbContext.Items.AddAsync(request);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteItem(int id)
        {
            var item = new Item() { Id = id };
            _dbContext.Items.Attach(item);
            _dbContext.Items.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> GetItems(FilteringParameters parameters)
        {
            var start = parameters.PageSize * parameters.PageNumber;
            return await _dbContext.Items
                .Where(x => x.CategoryId == parameters.CategoryId || parameters.CategoryId == null)
                .Skip(start)
                .Take(parameters.PageSize)
                .ToListAsync();
        }

        public async Task UpdateItem(Item request)
        {
            _dbContext.Items.Attach(request);
            _dbContext.Entry(request).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}