using Microsoft.EntityFrameworkCore;
using RestCT.DataAccess.Repositories.Interfaces;
using RestCT.Shared.Models;

namespace RestCT.DataAccess.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly RestCtDbContext _dbContext;

        public CategoryRepository(RestCtDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CreateCategory(Category request)
        {
            await _dbContext.Categories.AddAsync(request);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteCategory(int id)
        {
            var category = new Category() { Id = id };
            _dbContext.Categories.Attach(category);
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task UpdateCategory(Category request)
        {
            _dbContext.Categories.Attach(request);
            _dbContext.Entry(request).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}