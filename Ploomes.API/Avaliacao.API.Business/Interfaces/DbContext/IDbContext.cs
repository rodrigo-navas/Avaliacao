using System;
using System.Data;

namespace Avaliacao.API.Business.Interfaces.DbContext
{
    public interface IDbContext : IDisposable
    {
        IDbConnection Connection { get; }
    }
}
