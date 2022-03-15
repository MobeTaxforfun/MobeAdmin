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
using System.ComponentModel.DataAnnotations.Schema;

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
            string Condition = GenerateListOfPropertiesGetCondition(GetProperties);
            string mainsql = @$"Delete From {TableName} Where {Condition} = @Id";
            return await ExecuteAsync(mainsql, Id);
        }

        public virtual async Task<T> GetOne(object Id)
        {
            string Condition = GenerateListOfPropertiesGetCondition(GetProperties);
            string mainsql = @$"Select Top(1) * From {TableName} Where {Condition} = @Id";
            return await QuerySingleOrDefaultAsync<T>(mainsql, Id);
        }

        public virtual async Task<IEnumerable<T>> ListedAllAsync()
        {
            string mainsql = @$"Select * From {TableName}";
            return await QueryAsync<T>(mainsql);
        }

        public virtual async Task<int> CreateAsync(T model)
        {
            string mainsql = GenerateInsertSql();
            return await ExecuteAsync(mainsql, model);
        }

        public virtual async Task<int> UpdateAsync(T model)
        {
            string mainsql = GenerateUpdateSql();
            return await ExecuteAsync(mainsql, model);
        }

        /// <summary>
        /// 將 T 自動轉換成 SQL Insert 語法
        /// </summary>
        /// <returns>SQL string</returns>
        private string GenerateInsertSql()
        {
            var Properties = GenerateListOfPropertiesUseToInsert(GetProperties);

            string TableField = string.Concat(Properties.Select(i => string.Format("[{0}],", i)));
            TableField = TableField.Remove(TableField.Length - 1);
            string TableValues = string.Concat(Properties.Select(i => string.Format("@{0},", i)));
            TableValues = TableValues.Remove(TableValues.Length - 1);
            StringBuilder mainsql = new StringBuilder($"Insert Into {TableName} ({TableField}) Values ({ TableValues} ) ");
            return mainsql.ToString();
        }

        private string GenerateUpdateSql()
        {
            var Properties = GenerateListOfPropertiesUseToUpdate(GetProperties);
            string TableValues = string.Concat(Properties.Select(i => string.Format($"{i}=@{i},", i)));
            TableValues = TableValues.Remove(TableValues.Length - 1);
            string Condition = GenerateListOfPropertiesGetCondition(GetProperties);
            var mainsql = new StringBuilder($"UPDATE {TableName} SET {TableValues} Where {Condition} = @{Condition} ");
            return mainsql.ToString();
        }

        /// <summary>
        /// 擷取 TModel 產生 Insert 語法 
        /// </summary>
        /// <param name="ListOfProperties"></param>
        /// <returns></returns>
        private List<string> GenerateListOfPropertiesUseToInsert(IEnumerable<PropertyInfo> ListOfProperties)
        {
            List<string> Result = new List<string>();
            foreach (var propertyInfo in ListOfProperties)
            {
                object[] Attrs = propertyInfo.GetCustomAttributes(true);
                //如果是 Identity 不加入,如果是 Key 會加入
                if (Attrs.Length <= 0)
                {
                    Result.Add(propertyInfo.Name);
                }
                else
                {
                    if (propertyInfo.GetCustomAttributes(typeof(DatabaseGeneratedAttribute), false) != null)
                        continue; //DatabaseGeneratedOption 還沒判斷
                    if (propertyInfo.GetCustomAttributes(typeof(KeyAttribute), false) != null)
                        Result.Add(propertyInfo.Name);
                }

            }
            return Result; //看看之後要不要改成 Linq
            //return (from prop in ListOfProperties
            //        let attributes = prop.GetCustomAttributes(typeof(DescriptionAttribute), false)
            //        where attributes.Length <= 0 || (attributes[0] as DescriptionAttribute)?.Description != "ignore"
            //        select prop.Name).ToList();
        }

        /// <summary>
        /// 擷取 TModel 產生 Update 語法 
        /// </summary>
        /// <param name="ListOfProperties"></param>
        /// <returns></returns>
        private List<string> GenerateListOfPropertiesUseToUpdate(IEnumerable<PropertyInfo> ListOfProperties)
        {
            List<string> Result = new List<string>();
            foreach (var propertyInfo in ListOfProperties)
            {
                object[] Attrs = propertyInfo.GetCustomAttributes(true);
                //如果是 Identity 不加入,如果是 Key 會加入
                if (Attrs.Length <= 0)
                {
                    Result.Add(propertyInfo.Name);
                }
            }
            return Result; //看看之後要不要改成 Linq
        }

        /// <summary>
        /// 回傳被標記為 Key 的 Field
        /// </summary>
        /// <param name="ListOfProperties"></param>
        /// <returns></returns>
        private string GenerateListOfPropertiesGetCondition(IEnumerable<PropertyInfo> ListOfProperties)
        {
            var result = (from propertyInfo in ListOfProperties
                          let attributes = propertyInfo.GetCustomAttributes(typeof(KeyAttribute), false)
                          select propertyInfo.Name);
            if(result == null)
            {
                throw new Exception("快速方法需要一個 Key 值");
            }

            if (result.Count() > 1)
            {
                throw new Exception("快速方法不支援多組 Key");
            }

            return result.FirstOrDefault();
        }
    }
}
