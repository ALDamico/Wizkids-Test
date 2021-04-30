using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizkids_Test.Repositories
{
    public class RepositoryBase
    {
        public RepositoryBase(string connectionString)
        {
            ConnectionString = connectionString;
        }
        protected string ConnectionString { get; }
        protected SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(ConnectionString);
        }
    }
}
