using RestCT.DataAccess.Repositories.Interfaces;
using RestCT.Shared.Models;

namespace RestCT.DataAccess.Repositories
{
    public class ItemRepository : BaseRepository<Item>, IRepository<Item>
    {

        public ItemRepository(RestCtDbContext dbContext) : base(dbContext, dbContext.Items)
        {
        }
        //TODO
        //Move to service
        //обобщенный репозиторий!
    }
}