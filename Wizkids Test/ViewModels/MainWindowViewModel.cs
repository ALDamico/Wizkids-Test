using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using Wizkids_Test.DataAdapter;
using Wizkids_Test.Services;
using Wizkids_Test.Services.Authentication;

namespace Wizkids_Test.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            DbWords = new ObservableCollection<WordViewModel>();
            WsWords = new ObservableCollection<WordViewModel>();
            var connectionString = ConfigurationManager.ConnectionStrings["AppConnectionString"].ConnectionString;
            DataAdapter = new WordDataAdapter(connectionString);
            var authenticationStrategy = GetDefaultAuthenticationStrategy();
            var endpoint = ConfigurationManager.AppSettings.Get("WordServiceEndpoint");
            
            var webService = new WordService(authenticationStrategy, endpoint);
            DataAdapter.AddService(webService);
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

        private IAuthenticationStrategy GetDefaultAuthenticationStrategy()
        {
            var bearerToken = ConfigurationManager.AppSettings.Get("BearerToken");
            var authenticationInfo = new AuthenticationInfo() { Token = bearerToken };
            return new BearerTokenAuthenticationStrategy(authenticationInfo);
        }

        public ObservableCollection<WordViewModel> DbWords { get; }
        public ObservableCollection<WordViewModel> WsWords { get; }
        public WordDataAdapter DataAdapter { get; set; }

        public void FetchFromDatabase()
        {
            var lastWord = Regex.Split(TargetString, @"\s", RegexOptions.Compiled | RegexOptions.CultureInvariant).LastOrDefault();
            var viewModels = DataAdapter.GetMatchesFromDb(lastWord);
            DbWords.Clear();
            if (viewModels != null)
            {
                foreach (var word in viewModels)
                {
                    DbWords.Add(word);
                }
            }
        }

        public async Task FetchFromWebService()
        {
            WsWords.Clear();
            var viewModels = await DataAdapter.GetMatchesFromWebService(TargetString, "en-GB");
            if (viewModels != null)
            {
                foreach (var word in viewModels)
                {
                    WsWords.Add(word);
                }
            }
        }
    }
}
