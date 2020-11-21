using Dapper;
using DbUp;
using Microsoft.Extensions.Configuration;
using Ploomes.API.Business.Interfaces.DbContext;
using Ploomes.API.Business.Interfaces.Repositories;
using Ploomes.API.Cross.Query;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ploomes.API.Infra.Data.Repositories
{
    public class DBUpRepository : AbstractRepository, IDBUpRepository
    {
        IDbContext _context;

        public DBUpRepository(IConfiguration config, IDbContext context) : base(config, context)
        {
            _context = context;
        }

        public Task<ResultListQuery<string>> GetAllScriptExecuted()
        {
            ResultListQuery<string> result = new ResultListQuery<string> { };

            StringBuilder sql = new StringBuilder();
            sql.AppendLine(" IF NOT EXISTS (SELECT 1 FROM SYS.TABLES WHERE OBJECT_ID = OBJECT_ID('SchemaVersions')) ");
            sql.AppendLine("   BEGIN ");
            sql.AppendLine("      CREATE TABLE SchemaVersions ( ");
            sql.AppendLine("             Id         INT IDENTITY(1,1) NOT NULL, ");
            sql.AppendLine("             ScriptName NVARCHAR(255) NOT NULL, ");
            sql.AppendLine("             Applied    DATETIME NOT NULL ");
            sql.AppendLine("      ); ");
            sql.AppendLine("    ");
            sql.AppendLine("      ALTER TABLE SchemaVersions ADD CONSTRAINT PK_SchemaVersions_Id PRIMARY KEY (Id); ");
            sql.AppendLine("   END ");
            sql.AppendLine(" SELECT ScriptName ");
            sql.AppendLine("   FROM SchemaVersions ");

            result.Data = (_context.Connection.Query<string>(sql.ToString())).AsList();

            return Task.FromResult(result);
        }

        public Task<ResultQuery<dynamic>> ExecuteScripts(Dictionary<string, bool> dicScriptsIgnorar)
        {
            ResultQuery<dynamic> result = new ResultQuery<dynamic> { };

            var upgrader = DeployChanges.To.
                SqlDatabase(_context.Connection.ConnectionString).
                WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly(), (string script) =>
                {
                    return !dicScriptsIgnorar.ContainsKey(script) && script.StartsWith("Ploomes.API.Infra.Data.Scripts");
                }).
                WithExecutionTimeout(TimeSpan.Zero).
                LogToConsole().
                Build();

            result.Data = upgrader.PerformUpgrade();

            return Task.FromResult(result);
        }
    }
}
