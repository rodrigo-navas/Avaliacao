using Ploomes.API.Business.Interfaces.Repositories;
using Ploomes.API.Business.Interfaces.Services;
using Ploomes.API.Cross.Query;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Ploomes.API.Business.Services
{
    public class DBUpService : IDBUpService
    {
        IDBUpRepository _dBUpRepository;

        public DBUpService(IDBUpRepository dBUpRepository)
        {
            _dBUpRepository = dBUpRepository;
        }

        public async Task<ResultQuery<dynamic>> ExecuteScriptsAsync()
        {
            Dictionary<string, bool> dicScripts = new Dictionary<string, bool>();

            var scripts = (await _dBUpRepository.GetAllScriptExecuted());

            scripts.Data.ForEach(script =>
            {
                dicScripts.Add(script, false);
            });

            return await _dBUpRepository.ExecuteScripts(dicScripts);
        }
    }
}
