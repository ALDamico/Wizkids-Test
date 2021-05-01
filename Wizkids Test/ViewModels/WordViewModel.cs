using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wizkids_Test.ViewModels
{
    public class WordViewModel : ViewModelBase
    {
        private string _value;
        private string _locale;
        public string Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }
        public string Locale
        {
            get => _locale;
            set
            {
                _locale = value;
                OnPropertyChanged(nameof(Locale));
            }
        }
    }
}
