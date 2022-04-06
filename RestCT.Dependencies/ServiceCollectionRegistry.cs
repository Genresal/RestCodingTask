using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestCT.BusinessLogic.Services;
using RestCT.BusinessLogic.Services.Interfaces;
using RestCT.DataAccess;
using RestCT.DataAccess.Repositories;
using RestCT.DataAccess.Repositories.Interfaces;

namespace SPWB.Planning.Dependencies
{
    public static class ServiceCollectionRegistry
    {
        private const string defaultConnectionString = "Server=(local);Database=RestCtDb;Trusted_Connection=True;Encrypt=False;";
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IAuxiliaryService, AuxiliaryService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IItemService, ItemService>();
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAuxiliaryRepository, AuxiliaryRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<IItemRepository, ItemRepository>();
        }

        public static void AddDatabaseConfigs(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RestCtDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("ConnectionString") ?? defaultConnectionString));
        }
    }
}
