using Microsoft.Extensions.DependencyInjection;
using Ploomes.API.Business.Interfaces.DbContext;
using Ploomes.API.Business.Interfaces.Repositories;
using Ploomes.API.Business.Interfaces.Services;
using Ploomes.API.Business.Services;
using Ploomes.API.Infra.Data.DbContext;
using Ploomes.API.Infra.Data.Repositories;

namespace Ploomes.API.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IDbContext, DbContext>();

            AddDependenciesServices(services);
            AddDependenciesRepositories(services);
        }

        private static void AddDependenciesServices(this IServiceCollection services)
        {
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IDBUpService, DBUpService>();
        }

        private static void AddDependenciesRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IDBUpRepository, DBUpRepository>();
        }
    }
}
