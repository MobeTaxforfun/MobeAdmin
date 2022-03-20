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
            string mainsql = @"";
            Tuple<int, IEnumerable<Department>> tuple = new Tuple<int, IEnumerable<Department>>(10, null);
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
