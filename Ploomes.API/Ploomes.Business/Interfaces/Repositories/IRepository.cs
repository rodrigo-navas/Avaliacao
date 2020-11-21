using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Ploomes.API.Business.Interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Remove(TEntity entity, SqlConnection conexao = null, SqlTransaction transacaoSqlBanco = null);
        Task Remove(int id, SqlConnection conexao = null, SqlTransaction transacaoSqlBanco = null);
        Task RemoveList(List<TEntity> lstEntity, SqlConnection conexao = null, SqlTransaction transacaoSqlBanco = null);
        Task Insert(TEntity entity, SqlConnection conexao = null, SqlTransaction transacaoSqlBanco = null);
        Task Update(TEntity entity, SqlConnection conexao = null, SqlTransaction transacaoSqlBanco = null);
        public Task<TEntity> GetById(object id, SqlConnection conexao = null);
        Task<List<TEntity>> GetAll(SqlConnection conexao = null);
        Task<IEnumerable<TEntity>> Find(Func<TEntity, bool> predicate);
        Task<int> Execute(string Sql, SqlConnection conexao = null, SqlTransaction transacaoSqlBanco = null);
    }
}
