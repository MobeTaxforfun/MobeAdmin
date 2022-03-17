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
    public class DepartmentRepository : BaseRepository<Department> ,IDepartmentRepository
    {
        public DepartmentRepository(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {

        }
    }
}
