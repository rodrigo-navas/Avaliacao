using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using Ploomes.API.Business.Interfaces.DbContext;
using Ploomes.API.Business.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Ploomes.API.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : AbstractRepository, IRepository<TEntity> where TEntity : class, new()
    {
        readonly IDbContext _context;

        public BaseRepository(IConfiguration config, IDbContext context) : base(config, context)
        {
            _context = context;
        }

        public Task Remove(TEntity entity, SqlConnection conexao = null, SqlTransaction transacaoSqlBanco = null)
        {
            return Task.FromResult((conexao == null ? _context.Connection : conexao).Delete(entity, transaction: transacaoSqlBanco));
        }

        public Task Remove(int id, SqlConnection conexao = null, SqlTransaction transacaoSqlBanco = null)
        {
            if (conexao == null)
                return Task.FromResult(_context.Connection.Delete(_context.Connection.Get<TEntity>(id, transaction: transacaoSqlBanco)));
            else
                return Task.FromResult(conexao.Delete(conexao.Get<TEntity>(id, transaction: transacaoSqlBanco)));
        }

        public Task RemoveList(List<TEntity> lstEntity, SqlConnection conexao = null, SqlTransaction transacaoSqlBanco = null)
        {
            return Task.FromResult((conexao == null ? _context.Connection : conexao).Delete(lstEntity, transaction: transacaoSqlBanco));
        }

        public Task<List<TEntity>> GetAll(SqlConnection conexao = null)
        {
            return Task.FromResult((conexao == null ? _context.Connection : conexao).GetAll<TEntity>().ToList());
        }

        public Task<TEntity> GetById(object id, SqlConnection conexao = null)
        {
            return Task.FromResult((conexao == null ? _context.Connection : conexao).Get<TEntity>(id));
        }

        public Task Insert(TEntity entity, SqlConnection conexao = null, SqlTransaction transacaoSqlBanco = null)
        {
            return Task.FromResult((conexao == null ? _context.Connection : conexao).Insert(entity, transaction: transacaoSqlBanco));
        }

        public Task Update(TEntity entity, SqlConnection conexao = null, SqlTransaction transacaoSqlBanco = null)
        {
            return Task.FromResult((conexao == null ? _context.Connection : conexao).Update(entity, transaction: transacaoSqlBanco));
        }

        public Task<IEnumerable<TEntity>> Find(Func<TEntity, bool> predicate)
        {
            return Task.FromResult(_context.Connection.GetAll<TEntity>().Where(predicate));
        }

        public Task<int> Execute(string Sql, SqlConnection conexao = null, SqlTransaction transacaoSqlBanco = null)
        {
            return Task.FromResult((conexao == null ? _context.Connection : conexao).Execute(Sql, transaction: transacaoSqlBanco));
        }
    }
}
