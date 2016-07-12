using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

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
