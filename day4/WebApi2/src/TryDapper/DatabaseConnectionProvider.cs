using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace TryDapper
{
    public class DatabaseConnectionProvider
    {
        public IDbConnection GetConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}
