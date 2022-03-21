using Dapper;
using MobeAdmin.DataAccess.DbCore.Base;
using MobeAdmin.DataAccess.Interface;
using MobeAdmin.DataAccess.Interface.AdminDb;
using MobeAdmin.Domain.Model.AdminDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.DataAccess.Repository.AdminDb
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {

        }

        public async Task<Tuple<int, IEnumerable<Department>>> PaginateAsync(int page, int itemsPerPage, string name)
        {
            //查詢總數
            string countsql = @"SELECT COUNT(*) FROM [Bridge].[dbo].[Department] where 1=1";
            //資料實體
            string mainsql = @"SELECT * FROM [Bridge].[dbo].[Department] where 1=1";

            DynamicParameters parameters = new DynamicParameters();

            //頁籤計算
            mainsql += @" ORDER BY CreateTime DESC" + @" OFFSET @skip ROWS" + @" FETCH NEXT @take ROWS ONLY";
            parameters.Add("skip", itemsPerPage * page);
            parameters.Add("take", itemsPerPage);

            var result = await this.QueryAsync<Department>(mainsql, parameters);
            int max = (await this.QueryAsync<int>(countsql)).FirstOrDefault();

            Tuple<int, IEnumerable<Department>> tuple = new Tuple<int, IEnumerable<Department>>(max, result);

            return tuple;
        }

        public async override Task<int> UpdateAsync(Department model)
        {
            string mainsql = @"UPDATE [dbo].[Department]
                               SET [DepartmentName] = @DepartmentName
                                  ,[DepartmentDescription] = @DepartmentDescription
                                  ,[Sort] = @Sort
                                  ,[UpdateTime] = @UpdateTime
                             WHERE Id = @Id";
            return await this.ExecuteAsync(mainsql, model); ;
        }
    }
}
