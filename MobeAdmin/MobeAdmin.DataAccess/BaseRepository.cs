using MobeAdmin.DataAccess.DbCore;
using MobeAdmin.DataAccess.DbCore.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Reflection;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MobeAdmin.DataAccess
{
    public abstract class BaseRepository<T> : DapperBase, IGenericRepository<T> where T : class
    {
        private string TableName { get; set; }
        private IEnumerable<PropertyInfo> GetProperties => typeof(T).GetProperties();
        public BaseRepository(IDbConnectionFactory dbConnectionFactory)
        {
            this._DbConnection = dbConnectionFactory.CreateDbConnection(EnumConnectionName.Master);
            this.TableName = typeof(T).Name;
        }
        public BaseRepository(string TableName, IDbConnectionFactory dbConnectionFactory)
        {
            this._DbConnection = dbConnectionFactory.CreateDbConnection(EnumConnectionName.Master);
            this.TableName = TableName;
        }

        public virtual async Task<int> DeleteAsync(object Id)
        {
            var key = typeof(T).GetType().GetProperties().FirstOrDefault(gt => gt.GetCustomAttributes().Any(a => ((KeyAttribute)a) != null));
            string mainsql = @$"Delete From {TableName} Where Id = @Id";
            return await ExecuteAsync(mainsql, Id);
        }

        public virtual async Task<T> GetOne(object Id)
        {
            string mainsql = @$"Select Top(1) * From {TableName} Where Id = @Id";
            return await QuerySingleOrDefaultAsync<T>(mainsql, Id);
        }

        public virtual async Task<IEnumerable<T>> ListedAllAsync()
        {
            string mainsql = @$"Select * From {TableName}";
            return await QueryAsync<T>(mainsql);
        }

        public virtual async Task<int> CreateAsync(T model)
        {
            string mainsql = @$"Select * From {TableName}";
            return await ExecuteAsync(mainsql);
        }


        public Task<int> UpdateAsync(T model)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 將 T 自動轉換成 SQL Insert 語法
        /// </summary>
        /// <returns>SQL string</returns>
        private string GenerateInsertSql()
        {
            StringBuilder mainsql = new StringBuilder($"Insert Into {TableName}");
            mainsql.Append("(");
            var Properties = GenerateListOfProperties(GetProperties);
            Properties.ForEach(p => mainsql.Append($"[{p}],"));

            mainsql
            .Remove(mainsql.Length - 1, 1)
            .Append(") VALUES (");

            Properties.ForEach(prop => { mainsql.Append($"@{prop},"); });

            mainsql.Remove(mainsql.Length - 1, 1).Append(")");

            return mainsql.ToString();
        }

        private string GenerateUpdateSql()
        {
            var updateQuery = new StringBuilder($"UPDATE {TableName} SET ");
            var properties = GenerateListOfProperties(GetProperties);

            properties.ForEach(property =>
            {
                if (!property.Equals("Id"))
                {
                    updateQuery.Append($"{property}=@{property},");
                }
            });

            updateQuery.Remove(updateQuery.Length - 1, 1); //remove last comma
            updateQuery.Append(" WHERE Id=@Id");

            return updateQuery.ToString();
        }

        private static List<string> GenerateListOfProperties(IEnumerable<PropertyInfo> listOfProperties)
        {
            return (from prop in listOfProperties
                    let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
                    where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
                    select prop.Name).ToList();
        }
    }
}
