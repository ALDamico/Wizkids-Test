using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wizkids_Test.ViewModels;

namespace Wizkids_Test
{
    /// <summary>
    /// Logica di interazione per MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;

            InitializeComponent();
            InputTextBox.TextChanged += InputTextBox_TextChangedFromDatabase;
            InputTextBox.TextChanged += InputTextBox_TextChangedFromWebService;
        }

        private MainWindowViewModel _viewModel;

        private void InputTextBox_TextChangedFromDatabase(object sender, TextChangedEventArgs e)
        {
            _viewModel.FetchFromDatabase();
        }

        private void InputTextBox_TextChangedFromWebService(object sender, TextChangedEventArgs e)
        {

        }
    }
}
