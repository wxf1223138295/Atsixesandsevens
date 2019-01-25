using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UpdateHis
{
    public class ExcuteSql
    {
        public static bool UpdateSqlServerConfig(string connectstring,string sql)
        {
            using (SqlConnection conn = new SqlConnection(connectstring))
            {
                conn.Open();
                if (!(conn.State == ConnectionState.Open))
                {
                    return false;
                }

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    try
                    {
                       return cmd.ExecuteNonQuery()>=0?true:false;
                    }
                    catch(Exception e)
                    {
                        return false;
                    }
                }
            }
        }
    }
}
