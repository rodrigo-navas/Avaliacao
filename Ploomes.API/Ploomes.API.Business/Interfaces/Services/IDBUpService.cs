using Ploomes.API.Cross.Query;
using System.Threading.Tasks;

namespace Ploomes.API.Business.Interfaces.Services
{
    public interface IDBUpService
    {
        Task<ResultQuery<dynamic>> ExecuteScriptsAsync();
    }
}
