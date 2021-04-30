using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizkids_Test.Entities.Db;

namespace Wizkids_Test.Repositories
{
    public class WordRepository : RepositoryBase
    {
        public WordRepository(string connectionString) : base(connectionString)
        {
        }

        public IEnumerable<Word> GetMatches(string partial)
        {
            var partialFixed = partial.ToLowerInvariant();
            var query = @"
                SELECT Id, Value
                FROM Words
                WHERE LOWER(Value) LIKE ?
";
            using (var connection = GetConnection())
            {
                return connection.Query<Word>(query, new { Value = "%" + partialFixed + "%"});
            }

        }
    }
}
