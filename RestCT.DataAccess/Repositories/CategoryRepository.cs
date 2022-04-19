using RestCT.DataAccess.Repositories.Interfaces;
using RestCT.Shared.Models;

namespace RestCT.DataAccess.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, IRepository<Category>
    {

        public CategoryRepository(RestCtDbContext dbContext) : base(dbContext, dbContext.Categories)
        {
        }
    }
}