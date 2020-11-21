using Microsoft.Extensions.Configuration;
using Ploomes.Business.Interfaces.DbContext;
using Ploomes.Business.Interfaces.Repositories;
using Ploomes.Business.Models;

namespace Ploomes.Infra.Data.Repositories
{
    public class ClientRepository : BaseRepository<ClientModel>, IClientRepository
    {
        public ClientRepository(IConfiguration config, IDbContext context) : base(config, context)
        {
        }
    }
}
