using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wizkids_Test.DataAdapter;

namespace Wizkids_Test.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            DbWords = new ObservableCollection<WordViewModel>();
            var connectionString = ConfigurationManager.ConnectionStrings["AppConnectionString"].ConnectionString;
            DataAdapter = new WordDataAdapter(connectionString);
        }
        private string _targetString;
        public string TargetString
        {
            get => _targetString;
            set
            {
                _targetString = value;
                OnPropertyChanged(nameof(TargetString));
            }
        }

        public ObservableCollection<WordViewModel> DbWords { get; }
        public WordDataAdapter DataAdapter { get; set; }

        public void FetchFromDatabase()
        {
            var viewModels = DataAdapter.GetMatchesFromDb(TargetString);
            DbWords.Clear();
            foreach (var word in viewModels)
            {
                DbWords.Add(word);
            }
        }
    }
}
