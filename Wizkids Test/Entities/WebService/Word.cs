using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizkids_Test.Entities.WebService
{
    public class Word : IWord
    {
        public string Locale { get; set; }
        public string Value { get; set; }
    }
}
