using System;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;

namespace PI.Views
{
    /// <summary>
    /// Створює зв'язок між Cabinet.xaml та CabinetViewModel.
    /// </summary>
    public partial class Cabinet : Page
    {
        public Cabinet()
        {
            InitializeComponent();
        }
        public Cabinet(string login)
        {
            InitializeComponent();
            Login = login;
            DataContext = new ViewModel.CabinetViewModel(Login);
        }
        public string Login { get; set; }
    }
}
