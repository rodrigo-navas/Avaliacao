using Ploomes.API.Cross.Query;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ploomes.API.Business.Interfaces.Repositories
{
    public interface IDBUpRepository
    {
        Task<ResultListQuery<string>> GetAllScriptExecuted();
        Task<ResultQuery<dynamic>> ExecuteScripts(Dictionary<string, bool> dicScriptsIgnorar);
    }
}
