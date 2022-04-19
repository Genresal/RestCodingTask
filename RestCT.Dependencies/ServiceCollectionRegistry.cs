using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestCT.BusinessLogic.Services;
using RestCT.BusinessLogic.Services.Interfaces;
using RestCT.DataAccess;
using RestCT.DataAccess.Repositories;
using RestCT.DataAccess.Repositories.Interfaces;
using RestCT.Shared.Models;
using SPWB.SportService.BFF.Profiles;

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
            services.AddTransient<IRepository<Category>, CategoryRepository>();
            services.AddTransient<IRepository<Item>, ItemRepository>();
        }

        public static void AddDatabaseConfigs(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RestCtDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("ConnectionString") ?? defaultConnectionString));
        }

        public static IServiceCollection AddApiAutoMapperProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));


            return services;
        }
    }
}
