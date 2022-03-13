using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobeAdmin.DataAccess.DbCore.Base
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IDictionary<EnumConnectionName, string> _ConnectStringDic;
        public IDbConnection CreateDbConnection(EnumConnectionName ConnectionName)
        {
            if (_ConnectStringDic.TryGetValue(ConnectionName, out string ConnectionString))
                return new SqlConnection(ConnectionString);
            throw new ArgumentNullException("找不到此 Database 連線資訊，請確認 ConfigFile 是否包含其定義。");
        }
    }
}
