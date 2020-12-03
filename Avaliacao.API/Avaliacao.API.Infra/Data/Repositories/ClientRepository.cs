using Microsoft.Extensions.Configuration;
using Avaliacao.API.Business.Interfaces.DbContext;
using Avaliacao.API.Business.Interfaces.Repositories;
using Avaliacao.API.Business.Models;

namespace Avaliacao.API.Infra.Data.Repositories
{
    public class ClientRepository : BaseRepository<ClientModel>, IClientRepository
    {
        public ClientRepository(IConfiguration config, IDbContext context) : base(config, context)
        {
        }
    }
}
