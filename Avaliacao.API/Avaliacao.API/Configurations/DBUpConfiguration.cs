using Microsoft.Extensions.Configuration;
using Avaliacao.API.Business.Interfaces.Services;
using System.Threading.Tasks;

namespace Avaliacao.API.Configurations
{
    public class DBUpConfiguration
    {
        public static async Task Inicializacao(IDBUpService dBUpService, IConfiguration config)
        {
            await dBUpService.ExecuteScriptsAsync();
        }
    }
}
