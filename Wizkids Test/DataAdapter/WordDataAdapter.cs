using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizkids_Test.Repositories;
using Wizkids_Test.ViewModels;
using Wizkids_Test.Converters;

namespace Wizkids_Test.DataAdapter
{
    public class WordDataAdapter
    {
        public WordDataAdapter(string connectionString)
        {
            _repository = new WordRepository(connectionString);
        }
        private WordRepository _repository;
        public IEnumerable<WordViewModel> GetMatchesFromDb(string partial)
        {
            var entities = _repository.GetMatches(partial);
            var output = new List<WordViewModel>();
            foreach (var entity in entities)
            {
                output.Add(WordConverter.ConvertFromEntity(entity));
            }
            return output;
        }
    }
}
