using Microsoft.Extensions.DependencyInjection;
using Avaliacao.API.Business.Interfaces.DbContext;
using Avaliacao.API.Business.Interfaces.Repositories;
using Avaliacao.API.Business.Interfaces.Services;
using Avaliacao.API.Business.Services;
using Avaliacao.API.Infra.Data.DbContext;
using Avaliacao.API.Infra.Data.Repositories;

namespace Avaliacao.API.Extensions
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
