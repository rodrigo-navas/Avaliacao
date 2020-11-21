using Ploomes.Business.Commands;
using Ploomes.Business.Queries;
using Ploomes.Cross.Query;
using System;
using System.Threading.Tasks;

namespace Ploomes.Business.Interfaces.Services
{
    public interface IClientService
    {
        Task<ResultListQuery<ClientQuery>> GetAllAsync();
        Task<ResultQuery<ClientQuery>> GetByIdAsync(Guid idClient);
        Task<ResultQuery> PostAsync(ClientCommand client);
        Task<ResultQuery> PutAsync(ClientCommand client);
        Task<ResultQuery> DeleteAsync(Guid idClient);
    }
}
