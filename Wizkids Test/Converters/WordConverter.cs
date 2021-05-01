using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wizkids_Test.Entities;
using Wizkids_Test.Entities.WebService;
using Wizkids_Test.ViewModels;

namespace Wizkids_Test.Converters
{
    public static class WordConverter
    {
        public static WordViewModel ConvertFromEntity(IWord word)
        {
            return new WordViewModel
            {
                Value = word.Value
            };
        }

        public static WordViewModel ConvertFromWebService(Word word)
        {
            return new WordViewModel
            {
                Value = word.Value,
                Locale = word.Locale
            };
        }
    }
}
