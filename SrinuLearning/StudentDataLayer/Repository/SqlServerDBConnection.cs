using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace StudentDataLayer.Repository
{
    public static class SqlServerDBConnection
    {
        static private SqlConnection dbConnection = null;

        static public SqlConnection GetSqlServerDBConnection(string connectionString)
        {
            if(dbConnection ==null)
            {
                dbConnection = new SqlConnection(connectionString);
                
            }
            return dbConnection;
        }
    }
}
