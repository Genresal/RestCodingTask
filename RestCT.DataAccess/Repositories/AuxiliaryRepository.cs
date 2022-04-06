using Microsoft.EntityFrameworkCore;
using RandomGen;
using RestCT.DataAccess.Repositories.Interfaces;
using RestCT.Shared.Models;

namespace RestCT.DataAccess.Repositories
{
    public class AuxiliaryRepository : IAuxiliaryRepository
    {
        private readonly RestCtDbContext _dbContext;

        public AuxiliaryRepository(RestCtDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddDefaultData()
        {
            for (var i = 0; i < 9; i++)
            {
                _dbContext.Categories.Add(new Category()
                {
                    Name = Gen.Random.Text.Words()(),
                    Image = Gen.Random.Internet.Urls()(),
                });
            }
            await _dbContext.SaveChangesAsync();

            var categoryIds = await _dbContext.Categories.Select(x => x.Id).ToListAsync();
            var random = new Random();

            for (var i = 0; i < 20; i++)
            {
                _dbContext.Items.Add(new Item()
                {
                    Name = Gen.Random.Text.Words()(),
                    Description = Gen.Random.Text.Short()(),
                    Image = Gen.Random.Internet.Urls()(),
                    Price = Gen.Random.Numbers.Decimals(1, 100)(),
                    Amount = Gen.Random.Numbers.UnsignedIntegers(1, 100)(),
                    CategoryId = categoryIds[random.Next(categoryIds.Count)],
                });
            }

            await _dbContext.SaveChangesAsync();
        }

        public void Clear()
        {
            _dbContext.Database.ExecuteSqlRaw(@$"
                DELETE FROM [Categories]
                DELETE FROM [{nameof(Item)}s]");
        }
    }
}