using Avaliacao.API.Cross.Query;
using System.Threading.Tasks;

namespace Avaliacao.API.Business.Interfaces.Services
{
    public interface IDBUpService
    {
        Task<ResultQuery<dynamic>> ExecuteScriptsAsync();
    }
}
