using Microsoft.Extensions.DependencyInjection;
using Ploomes.Business.Interfaces.DbContext;
using Ploomes.Business.Interfaces.Repositories;
using Ploomes.Business.Interfaces.Services;
using Ploomes.Business.Services;
using Ploomes.Infra.Data.DbContext;
using Ploomes.Infra.Data.Repositories;

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
        }

        private static void AddDependenciesRepositories(this IServiceCollection services)
        {
            services.AddScoped<IClientRepository, ClientRepository>();
        }
    }
}
