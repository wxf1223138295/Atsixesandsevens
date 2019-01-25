using System;
using System.Collections.Generic;
using System.Text;
using SqlSugar;

namespace Shawn.dal
{
    public static class SqlSugarInit
    {
        public static string configConnectionName = string.Empty;
        public static SqlSugarClient Instance
        {
            get
            {
                SqlSugarClient sqlSugarClient = new SqlSugarClient(new ConnectionConfig()
                {
                    ConnectionString = configConnectionName,
                    DbType = DbType.SqlServer,
                    IsAutoCloseConnection = true
                });

                return sqlSugarClient;
            }
        }
        public static SqlSugarClient GetInstance()
        {
            SqlSugarClient db = Instance;
            return db;
        }
    }
}
