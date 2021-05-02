using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizkids_Test.Repositories;
using Wizkids_Test.ViewModels;
using Wizkids_Test.Converters;
using Wizkids_Test.Services;
using Wizkids_Test.Entities;
using Wizkids_Test.Entities.WebService;

namespace Wizkids_Test.DataAdapter
{
    public class WordDataAdapter
    {
        public WordDataAdapter(string connectionString)
        {
            _repository = new WordRepository(connectionString);
        }
        private WordRepository _repository;
        private WordService _service;

        public void AddService(WordService service)
        {
            _service = service;
        }

        public IEnumerable<WordViewModel> GetMatchesFromDb(string partial)
        {
            if (string.IsNullOrEmpty(partial))
            {
                return null;
            }
            var entities = _repository.GetMatches(partial);
            var output = new List<WordViewModel>();
            foreach (var entity in entities)
            {
                output.Add(WordConverter.ConvertFromEntity(entity));
            }
            return output;
        }

        public async Task<IEnumerable<WordViewModel>> GetMatchesFromWebService(string partial, string locale)
        {
            if (string.IsNullOrEmpty(partial))
            {
                return null;
            }

            var entities = await _service.GetAsync(partial, locale);
            var output = new List<WordViewModel>();
            foreach (var entity in entities)
            {
                output.Add(WordConverter.ConvertFromWebService(entity as Word));
            }

            return output;
        }
    }
}
