using Microsoft.Extensions.Configuration;
using Ploomes.API.Business.Interfaces.DbContext;

namespace Ploomes.API.Infra.Data.Repositories
{
    public abstract class AbstractRepository
    {
        private readonly IConfiguration _config;
        readonly IDbContext _context;

        protected AbstractRepository(IConfiguration config, IDbContext context)
        {
            _config = config;
            _context = context;
        }

        protected string ConnectionString => _config.GetConnectionString("PloomesConnection");
    }
}
