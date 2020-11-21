using Microsoft.Extensions.Configuration;
using Ploomes.API.Business.Interfaces.DbContext;
using Ploomes.API.Business.Interfaces.Repositories;
using Ploomes.API.Business.Models;

namespace Ploomes.API.Infra.Data.Repositories
{
    public class ClientRepository : BaseRepository<ClientModel>, IClientRepository
    {
        public ClientRepository(IConfiguration config, IDbContext context) : base(config, context)
        {
        }
    }
}
