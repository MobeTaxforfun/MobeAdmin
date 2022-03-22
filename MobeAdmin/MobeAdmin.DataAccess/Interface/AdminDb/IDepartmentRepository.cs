using MobeAdmin.Domain.Model.AdminDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.DataAccess.Interface.AdminDb
{
    public interface IDepartmentRepository : IGenericRepository<Department>
    {
        public Task<Tuple<int, IEnumerable<Department>>> PaginateAsync(int page, int itemsPerPage, int IsEnable, string DepartmentName);
        public Task<int> SetDepartmentEnableById(int Id, int Enable);
    }
}
