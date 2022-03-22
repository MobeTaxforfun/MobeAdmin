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

        public async Task<Tuple<int, IEnumerable<Department>>> PaginateAsync(int page, int itemsPerPage, int IsEnable, string DepartmentName)
        {
            //查詢總數
            string countsql = @"SELECT COUNT(*) FROM [MobeAdmindb].[dbo].[Department] where 1=1";
            //資料實體
            string searchsql = @"SELECT * FROM  [MobeAdmindb].[dbo].[Department] where 1=1";


            DynamicParameters parameters = new DynamicParameters();

            if (IsEnable != 0)
            {
                countsql += @"AND [IsEnable] = @IsEnable";
                searchsql += @"AND [IsEnable] = @IsEnable";

                if (IsEnable == 1)
                {
                    parameters.Add("IsEnable", true);
                }
                else if (IsEnable == 2)
                {
                    parameters.Add("IsEnable", false);
                }
            }

            if (!string.IsNullOrEmpty(DepartmentName))
            {
                countsql += " AND DepartmentName like '%' + @DepartmentName + '%'";
                searchsql += " AND DepartmentName like '%' + @DepartmentName + '%'";
                parameters.Add("DepartmentName", DepartmentName);
            }

            //頁籤計算
            searchsql += @" ORDER BY Sort DESC" + @" OFFSET @skip ROWS" + @" FETCH NEXT @take ROWS ONLY";
            parameters.Add("skip", itemsPerPage * page);
            parameters.Add("take", itemsPerPage);

            //資料實體
            var result = await this.QueryAsync<Department>(searchsql, parameters);
            //資料總數
            int max = (await this.QueryAsync<int>(countsql, parameters)).FirstOrDefault();

            Tuple<int, IEnumerable<Department>> tuple = new Tuple<int, IEnumerable<Department>>(max, result);

            return tuple;
        }

        public async Task<int> SetDepartmentEnableById(int Id, int Enable)
        {
            string mainsql = @"UPDATE [MobeAdmindb].[dbo].[Department]
                               SET [IsEnable] = @IsEnable
                             WHERE Id = @Id";
            bool IsEnable;
            if (Enable == 1)
            {
                IsEnable = true;
            }
            else if (Enable == 2)
            {
                IsEnable = false;
            }
            else
            {
                throw new Exception("SetDepartmentEnableById > 不合法的操作，未知的 Enable Type");
            }

            return await this.ExecuteAsync(mainsql, new { Id, IsEnable }); ;
        }

        public async override Task<int> UpdateAsync(Department model)
        {
            string mainsql = @"UPDATE [MobeAdmindb].[dbo].[Department]
                               SET [DepartmentName] = @DepartmentName
                                  ,[DepartmentDescription] = @DepartmentDescription
                                  ,[Sort] = @Sort
                                  ,[UpdateTime] = @UpdateTime
                             WHERE Id = @Id";
            return await this.ExecuteAsync(mainsql, model); ;
        }
    }
}
