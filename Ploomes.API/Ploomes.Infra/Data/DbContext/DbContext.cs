using Microsoft.Extensions.Configuration;
using Ploomes.Business.Interfaces.DbContext;
using System.Data;
using System.Data.SqlClient;

namespace Ploomes.Infra.Data.DbContext
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
