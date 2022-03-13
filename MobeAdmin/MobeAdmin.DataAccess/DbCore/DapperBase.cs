using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.DataAccess.DbCore
{
    public abstract class DapperBase
    {
        public IDbConnection _DbConnection { get; set; }
        private IDbConnection CreateConnection()
        {
            return _DbConnection;
        }

        protected int Execute(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                return connection.Execute(sql, parameters);
            }
        }

        protected T QuerySingle<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                return connection.QuerySingle<T>(sql, parameters);
            }
        }

        protected List<T> Query<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                return connection.Query<T>(sql, parameters).ToList();
            }
        }

        protected async Task<List<T>> QueryAsync<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                return (await connection.QueryAsync<T>(sql, parameters)).ToList();
            }
        }

        protected async Task<int> ExecuteAsync(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                return (await connection.ExecuteAsync(sql, parameters));
            }
        }

        protected async Task<T> QuerySingleOrDefaultAsync<T>(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                return (await connection.QuerySingleOrDefaultAsync(sql, parameters));
            }
        }
    }
}
