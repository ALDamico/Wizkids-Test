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

        private static readonly string getMatchesQuery = @"
            SELECT Id, Value
            FROM Words
            WHERE LOWER(Value) LIKE ?
";

        public IEnumerable<Word> GetMatches(string partial)
        {
            var partialFixed = GetFixedPartialString(partial);
            var query = getMatchesQuery;
            using (var connection = GetConnection())
            {
                return connection.Query<Word>(query, new { Value = "%" + partialFixed + "%"});
            }

        }

        public async Task<IEnumerable<Word>> GetMatchesAsync(string partial)
        {
            var partialFixed = GetFixedPartialString(partial);
            var query = getMatchesQuery;
            using (var connection = GetConnection())
            {
                return await connection.QueryAsync<Word>(query, new { Value = "%" + partialFixed + "%" });
            }

        }

        private string GetFixedPartialString(string partial)
        {
            return partial?.ToLowerInvariant();
        }
    }
}
