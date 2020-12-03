using Avaliacao.API.Business.Commands;
using Avaliacao.API.Business.Queries;
using Avaliacao.API.Cross.Query;
using System;
using System.Threading.Tasks;

namespace Avaliacao.API.Business.Interfaces.Services
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
