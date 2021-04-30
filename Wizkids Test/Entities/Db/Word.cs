using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizkids_Test.Entities.Db
{
    public class Word : IWord
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
