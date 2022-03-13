using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.DataAccess.DbCore.Base
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateDbConnection(EnumConnectionName ConnectionName);
    }
}
