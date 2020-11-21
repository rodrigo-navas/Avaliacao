using Microsoft.Extensions.Configuration;
using Ploomes.API.Business.Interfaces.Services;
using System.Threading.Tasks;

namespace Ploomes.API.Configurations
{
    public class DBUpConfiguration
    {
        public static async Task Inicializacao(IDBUpService dBUpService, IConfiguration config)
        {
            await dBUpService.ExecuteScriptsAsync();
        }
    }
}
