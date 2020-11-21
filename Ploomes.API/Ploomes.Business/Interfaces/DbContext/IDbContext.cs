using System;
using System.Data;

namespace Ploomes.Business.Interfaces.DbContext
{
    public interface IDbContext : IDisposable
    {
        IDbConnection Connection { get; }
    }
}
