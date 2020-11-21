using System;
using System.Data;

namespace Ploomes.API.Business.Interfaces.DbContext
{
    public interface IDbContext : IDisposable
    {
        IDbConnection Connection { get; }
    }
}
