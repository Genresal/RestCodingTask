using Microsoft.EntityFrameworkCore;
using RestCT.Shared.Models;

namespace RestCT.DataAccess.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    {
        private readonly RestCtDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(RestCtDbContext dbContext, DbSet<T> dbSet)
        {
            _dbContext = dbContext;
            _dbSet = dbSet;
        }
        public async Task Create(T request)
        {
            await _dbSet.AddAsync(request);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var item = Activator.CreateInstance<T>();
            item.Id = id;
            _dbSet.Attach(item);
            _dbSet.Remove(item);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> Get()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Update(T request)
        {
            _dbSet.Attach(request);
            _dbContext.Entry(request).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}