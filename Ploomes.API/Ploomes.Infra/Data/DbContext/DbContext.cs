using Microsoft.Extensions.Configuration;
using Ploomes.API.Business.Interfaces.DbContext;
using System.Data;
using System.Data.SqlClient;

namespace Ploomes.API.Infra.Data.DbContext
{
    public class DbContext : IDbContext
    {
        readonly IConfiguration _config;
        public IDbConnection Connection { get; set; }

        public DbContext(IConfiguration config)
        {
            _config = config;
            Connection = new SqlConnection(_config.GetConnectionString("PloomesConnection"));
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}
